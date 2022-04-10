using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Date
    {
        private int year;
        private int month;
        private int day;

        public Date(int m, int d, int y)
        {
            year = y;
            month = m;
            day = d;
        }

        // return 1 if original date is later, return -1 if argument date is later,
        // and 0 if dates are the same
        public int CompareDate(Date tempDate)
        {
            if (year > tempDate.year)
                return 1;
            else if (year < tempDate.year)
                return -1;
            if (month > tempDate.month)
                return 1;
            else if (month < tempDate.month)
                return -1;
            if (day > tempDate.day)
                return 1;
            else if (day < tempDate.day)
                return -1;
            return 0;
        }

        override public string ToString()
        {
            return month.ToString() + "/" + day.ToString() + "/" + year.ToString();
        }
    }
}
