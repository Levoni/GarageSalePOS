using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Item
    {
        public Item(String p,float amount)
        {
            person = p;
            price = amount;
            note = "";
        }

        public Item(String p, float amount, String tempNote)
        {
            person = p;
            price = amount;
            note = tempNote;
        }
        public string person;
        public float price;
        public string note;
        

    }
}
