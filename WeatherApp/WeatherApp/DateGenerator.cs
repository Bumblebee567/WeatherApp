using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp
{
    public class DateGenerator
    {
        public string[] GenerateDateItemsToCombobox()
        {
            var n = DateTime.Now;
            string[] table = new string[14];
            for (int i = 0; i < table.Length; i++)
            {
                table[i] = n.AddDays(Convert.ToDouble(i * (-1))).ToShortDateString();
            }
            return table;
        }
    }
}
