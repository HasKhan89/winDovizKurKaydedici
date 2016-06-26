using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace winDovizKurKaydedici
{
    public class KurTipi
    {
        [Key, StringLength(4)]
        public string Kod { get; set; }

        [Required, StringLength(25)]
        public string Isim { get; set; }

        public override string ToString()
        {
            return Isim;
        }
    }
}
