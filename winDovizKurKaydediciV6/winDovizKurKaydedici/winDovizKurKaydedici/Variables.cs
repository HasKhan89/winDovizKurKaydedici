using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace winDovizKurKaydedici
{
    public static class Variables
    {
        public static string ChartCaption = "{{ChartCaption}}";
        public static string ChartLabels = "{{ChartLabels}}";
        public static string ChartSeries = "{{ChartSeries}}";

        public static string SeriesLabel = "{{SeriesLabel}}";
        public static string SeriesR = "{{SeriesR}}";
        public static string SeriesG = "{{SeriesG}}";
        public static string SeriesB = "{{SeriesB}}";
        public static string SeriesData = "{{SeriesData}}";


        public static string CiftTirnakIcineAl(string s)
        {
            return "\"" + s + "\"";
        }

        // Extension Methods..
        // Kurallar: 
        //      Extension bir metot yazıyorsanız;
        //      1. Static bir class içinde yazmalısınız.(Class adının önemi yok)
        //      2. Static bir metot olmalı.
        //      3. this keyword 'ünü metodu eklemek istediğiniz tip parametrenin önüne yazın.
        //      4. this keyword 'ünü içeren parametre ilk önce yazılmalı ve bir tane olmalı.
        //      5. Extension method static bir tip için yazılamaz.

        public static string CiftTirnakla(this string s)
        {
            return "\"" + s + "\"";
        }

        public static string Virgul(this string s)
        {
            return s + ",";
        }

        public static string Satir(this string s)
        {
            return s + Environment.NewLine;
        }

        public static string CharEkle(this string s, char c)
        {
            return s + c.ToString();
        }

        public static string CharEkle(this string s, char c1, char c2)
        {
            return c1.ToString() + s + c2.ToString();
        }
    }
}
