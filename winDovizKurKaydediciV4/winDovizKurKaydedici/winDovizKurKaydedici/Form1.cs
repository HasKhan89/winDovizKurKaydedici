using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

namespace winDovizKurKaydedici
{
    public partial class Form1 : Form
    {
        #region Fields

        private string ad = "";
        private string soyad = "";


        #endregion Fields

        #region Constructors

        public Form1()
        {
            InitializeComponent();
        }

        #endregion Constructors

        #region Properties

        public string AppName { get; set; }

        #endregion Properties

        #region Methods

        private void btnWebSorgula_Click(object sender, EventArgs e)
        {

            // Eğer tarih1, tarih2'den büyükse hiçbirşey yapmadan kullanıcıya uyarı vermeli. Tarihleri değiştirmeye zorlamalı.
            if (dtpBasTar.Value.Date > dtpBitTar.Value.Date)
            {
                MessageBox.Show($"Başlangıç tarihi {dtpBasTar.Value.ToShortDateString()}, bitiş tarihinden {dtpBitTar.Value.ToShortDateString()} büyük olamaz!");

                return;
            }

            // tarih1 ve tarih2 bugünden büyük seçilemez.
            if (dtpBasTar.Value.Date > DateTime.Now.Date || dtpBitTar.Value.Date > DateTime.Now.Date)
            {
                MessageBox.Show($"Seçilen tarihler bugünden büyük olamaz!");
                return;
            }


            // tarih1'den itibaren 1 er gün olarak tarih arttırılarak döviz kuru ilgili url oluşturularak xml çekilmeli. XML içinden tüm kurlar okunarak veritabanına insert edilir.
            // Veritabanından günler çekilir ve kullanıcının seçtiği günler elimizdeki günlerde yoksa veriler netten çekilir.(Aynı zamanda haftasonu değilse..)
            string url_today = "http://www.tcmb.gov.tr/kurlar/today.xml";

            DateTime baslangic = dtpBasTar.Value.Date;
            DateTime bitis = dtpBitTar.Value.Date;

            do
            {
                string url = string.Empty;

                // Haftasonu ise gün ü bir arttır ve dönmeye devam et.
                if (baslangic.DayOfWeek == DayOfWeek.Sunday ||
                    baslangic.DayOfWeek == DayOfWeek.Saturday)
                {
                    baslangic = baslangic.AddDays(1);
                    continue;
                }

                // baslangic tarihi kontrol edilir database'de var mı diye..
                if (HasDateToDatabase(baslangic) == true)
                {
                    baslangic = baslangic.AddDays(1);
                    continue;
                }

                if (baslangic == DateTime.Now.Date)
                {
                    url = url_today;
                }
                else
                {
                    //url = $"http://www.tcmb.gov.tr/kurlar/{baslangic.Year}{baslangic.Month}/{baslangic.Day}{baslangic.Month}{baslangic.Year}.xml";

                    //url = "http://www.tcmb.gov.tr/kurlar/" + 
                    //    baslangic.ToString("{0:yyyyMM/ddMMyyyy}") + ".xml";

                    url = "http://www.tcmb.gov.tr/kurlar/" +
                        baslangic.ToString("yyyyMM") + "/" +
                        baslangic.ToString("ddMMyyyy") + ".xml";
                }

                KurVerisiCek(url);

                baslangic = baslangic.AddDays(1);

            } while (baslangic <= bitis);

            MessageBox.Show("Veriler kaydedilmiştir.");
        }

        private bool HasDateToDatabase(DateTime baslangic)
        {
            bool result = false;

            DovizDBContext db = new DovizDBContext();

            #region 1.Yöntem
            //List<DateTime> tarihler = (from k in db.Kurlar
            //                           select k.Tarih).Distinct().ToList();

            //foreach (DateTime tarih in tarihler)
            //{
            //    if (tarih.Date == baslangic.Date)
            //    {
            //        result = true;
            //    }
            //} 
            #endregion

            #region 2.Yöntem

            DateTime tarih = (from k in db.Kurlar
                               where k.Tarih == baslangic
                               select k.Tarih).FirstOrDefault();

            if (tarih != DateTime.MinValue)
                result = true;

            #endregion

            return result;
        }

        private void KurVerisiCek(string url)
        {
            XDocument xDoc = null;

            try
            {
                xDoc = XDocument.Load(url);
            }
            catch (System.Net.WebException wex)
            {
                if (wex.Message.Contains("404") == true)
                {
                    // Tatil günü hatası..
                }

                return;
            }
            catch (Exception ex)
            {
                return;
            }

            // TODO : Burada verinin doğru gelip gelmediği kontrol edilecek.

            XElement tarih_date = xDoc.Root;
            DateTime tarih = DateTime.Parse(tarih_date.Attribute("Tarih").Value);

            List<XElement> kurlar = (from c in tarih_date.Elements("Currency")
                                     select c).ToList();

            DovizDBContext db = new DovizDBContext();

            foreach (XElement kur in kurlar)
            {
                string kod = kur.Attribute("Kod").Value;
                string isim = kur.Element("Isim").Value;
                string cname = kur.Element("CurrencyName").Value;
                string unit = kur.Element("Unit").Value;
                string fb = kur.Element("ForexBuying").Value.Replace(".", ",");
                string fs = kur.Element("ForexSelling").Value.Replace(".", ",");
                string bb = kur.Element("BanknoteBuying").Value.Replace(".", ",");
                string bs = kur.Element("BanknoteSelling").Value.Replace(".", ",");

                isim = (string.IsNullOrEmpty(isim)) ? "..." : isim;
                cname = (string.IsNullOrEmpty(cname)) ? "..." : cname;
                unit = (string.IsNullOrEmpty(unit)) ? "0" : unit;
                fb = (string.IsNullOrEmpty(fb)) ? "0" : fb;
                fs = (string.IsNullOrEmpty(fs)) ? "0" : fs;
                bb = (string.IsNullOrEmpty(bb)) ? "0" : bb;
                bs = (string.IsNullOrEmpty(bs)) ? "0" : bs;

                Kur kurNesnesi = new Kur()
                {
                    Tarih = tarih,
                    Kod = kod,
                    Isim = isim,
                    CurrencyName = cname,
                    Unit = int.Parse(unit),
                    ForexBuying = decimal.Parse(fb),
                    ForexSelling = decimal.Parse(fs),
                    BanknoteBuying = decimal.Parse(bb),
                    BanknoteSelling = decimal.Parse(bs)
                };

                db.Kurlar.Add(kurNesnesi);
            }

            // Eğer bir hata varsa liste olarak verir.
            var errorList = db.GetValidationErrors();

            if (errorList.Count() > 0)
            {
                // Hata var demektir.
                foreach (var err in errorList)
                {
                    foreach (var item in err.ValidationErrors)
                    {
                        // Hataların hepsi gösterilir.
                        //MessageBox.Show(
                        //    item.PropertyName + Environment.NewLine + item.ErrorMessage);
                        MessageBox.Show(item.ErrorMessage);
                    }
                }

                // Hata olduğu için insert zaten edemez.
                return;
            }

            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            KurIsimVeKodlariKaydet();
            KurTipleriniYukle();
        }

        private void KurIsimVeKodlariKaydet()
        {
            DovizDBContext db = new DovizDBContext();

            if (db.KurTipleri.Count() == 0)
            {
                XDocument xDoc = XDocument.Load("http://www.tcmb.gov.tr/kurlar/today.xml");
                XElement tarih_date = xDoc.Root;

                foreach (XElement cur in tarih_date.Elements("Currency"))
                {
                    string kod = cur.Attribute("Kod").Value;
                    string isim = cur.Element("Isim").Value;

                    // isim == null ise "..." koyar.
                    //isim = isim ?? "...";

                    // Kısa if.. => (koşul) ? {doğru ise} : {aksi halde}
                    isim = (string.IsNullOrEmpty(isim) == true) ? "..." : isim;

                    // old-version :  string ad = string.Format("adınız : {0}", isim);
                    // new-version :  ad = $"adınız : {isim}";

                    if (string.IsNullOrEmpty(kod) == false)
                    {
                        KurTipi kt = new KurTipi()
                        {
                            Kod = kod,
                            Isim = isim
                        };

                        db.KurTipleri.Add(kt);
                    }
                }

                db.SaveChanges();
            }
        }

        private void KurTipleriniYukle()
        {
            clbKurlar.Items.Clear();

            DovizDBContext db = new DovizDBContext();

            IEnumerable<KurTipi> kurtipleri = from kt in db.KurTipleri
                                              orderby kt.Isim ascending
                                              select kt;

            //kurtipleri = kurtipleri.Take(10);

            foreach (KurTipi kt in kurtipleri)
            {
                clbKurlar.Items.Add(kt);
            }
        }

        #endregion Methods

        private void btnVtSorgula_Click(object sender, EventArgs e)
        {
            DovizDBContext db = new DovizDBContext();

            List<string> secilenKodlar = new List<string>();

            foreach (var item in clbKurlar.CheckedItems)
            {
                KurTipi kt = item as KurTipi;
                secilenKodlar.Add(kt.Kod);
            }

            var sonuclar = from k in db.Kurlar
                           where k.Tarih >= dtpBasTar.Value.Date &&
                           k.Tarih <= dtpBitTar.Value.Date &&
                           secilenKodlar.Contains(k.Kod)
                           select k;

            dgvSonuclar.DataSource = sonuclar.ToList();

        }
    }
}