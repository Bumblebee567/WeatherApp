using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp
{
    class IntensivityParser
    {
        public static string ParseIntensivity(string intensivity)
        {
            if (intensivity == "Brak")
            {
                return "0";
            }
            else if (intensivity == "Słabe" || intensivity == "Słaby" || intensivity == "Małe")
            {
                return "1";
            }
            else if (intensivity == "Umiarkowane" || intensivity == "Umiarkowany")
            {
                return "2";
            }
            else if (intensivity == "Intensywne" || intensivity == "Silny" || intensivity == "Duże")
            {
                return "3";
            }
            else if (intensivity == "Bardzo intensywne" || intensivity == "Bardzo silny" || intensivity == "Całkowite")
            {
                return "4";
            }
            else
                return "0";
        }
    }
}
