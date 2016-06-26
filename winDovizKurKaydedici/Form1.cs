using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace winDovizKurKaydedici
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnWebSorgula_Click(object sender, EventArgs e)
        {
            // tarih1 ve tarih2 bugünden büyük seçilemez.

            // Eğer tarih1, tarih2'den büyükse hiçbirşey yapmadan kullanıcıya uyarı vermeli. Tarihleri değiştirmeye zorlamalı.

            // tarih1'den itibaren 1 er gün olarak tarih arttırılarak döviz kuru ilgili url oluşturularak xml çekilmeli. XML içinden tüm kurlar okunarak veritabanına insert edilir.
            // Veritabanından günler çekilir ve kullanıcının seçtiği günler elimizdeki günlerde yoksa veriler netten çekilir.(Aynı zamanda haftasonu değilse..)

            XDocument xDoc = XDocument.Load("http://www.tcmb.gov.tr/kurlar/today.xml");

            XElement tarih_date = xDoc.Root;
            DateTime tarih = DateTime.Parse(tarih_date.Attribute("Tarih").Value);

            XElement usd = (from c in tarih_date.Elements("Currency")
                            where c.Attribute("Kod").Value == "USD"
                            select c).FirstOrDefault();

            Kur kurNesnesi = new Kur()
            {
                Tarih = tarih,
                Kod = usd.Attribute("Kod").Value,
                Isim = usd.Element("Isim").Value,
                CurrencyName = usd.Element("CurrencyName").Value,
                Unit = int.Parse(usd.Element("Unit").Value),
        ForexBuying = decimal.Parse(usd.Element("ForexBuying").Value.Replace(".",",")),
        ForexSelling = decimal.Parse(usd.Element("ForexSelling").Value.Replace(".", ",")),
        BanknoteBuying = decimal.Parse(usd.Element("BanknoteBuying").Value.Replace(".", ",")),
        BanknoteSelling = decimal.Parse(usd.Element("BanknoteSelling").Value.Replace(".", ","))
            };

            //kurNesnesi.Isim = null;
            //kurNesnesi.CurrencyName += "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";

            DovizDBContext db = new DovizDBContext();
            db.Kurlar.Add(kurNesnesi);

            // Eğer bir hata varsa liste olarak verir.
            var errorList = db.GetValidationErrors();  

            if(errorList.Count() > 0)
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
    }
}
