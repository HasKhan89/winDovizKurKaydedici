using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace winDovizKurKaydedici
{
    // CodeFirst de CompositeKey(2 kolonun primarykey olması).

    public class Kur
    {
        [Key(), Column(Order = 0)]
        public DateTime Tarih { get; set; }

        [Key(), Column(Order = 1)]
        public string Kod { get; set; }

        [Required(ErrorMessage = "İsim boş geçilemez."), 
         StringLength(25, ErrorMessage = "İsim 25 karakterden fazla olamaz.")]
        public string Isim { get; set; }

        [Required(ErrorMessage = "Yabancı isim boş geçilemez."), 
         StringLength(25, ErrorMessage = "Yabancı isim 25 karakterden fazla olamaz.")]
        public string CurrencyName { get; set; }

        public int Unit { get; set; }
        public decimal ForexBuying { get; set; }
        public decimal ForexSelling { get; set; }
        public decimal BanknoteBuying { get; set; }
        public decimal BanknoteSelling { get; set; }

        public Kur()
        {
            // Kur new'lendiğinde(instance oluşturulduğunda) Unit = 1 olarak başlangıç değeri atanır.
            Unit = 1;
        }
    }
}
