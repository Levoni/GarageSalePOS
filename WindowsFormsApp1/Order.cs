using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Order
    {
        private Item[] items = new Item[10];
        private int count = 0;
        private int maxItems = 10;

        public Order() {; }

        public void add(string p, float amount, string tempString)
        {
            if (count >= maxItems)
                grow();
            items[count++] = new Item(p, amount,tempString);

        }

        public void add(Item item)
        {
            if (count >= maxItems)
                grow();
            items[count++] = item;

        }

        public void remove(int index)
        {
            if (index >= 0)
            {
                while (index < count - 1)
                {
                    items[index] = items[index + 1];
                    index++;
                }
                count--;
            }
        }

        public int findIndex(string p, float amount)
        {
            for (int i = 0; i < count; i++)
            {
                if (items[i].person == p && items[i].price == amount)
                    return i;
            }
            return -1;
        }

        public Item GetItem(int index)
        {
            if (index >= 0 && index < count)
                return items[index];
            return null;
        }

        public void Clear()
        {
            count--;
            for(;count>=0;count--)
            {
                items[count] = null;
            }
            count = 0;
        }

        public int GetTotalItems()
        {
            int tempInt = 0;
            for(int i = 0; i < count; i++)
            {
                if (items[i].price < 0)
                    tempInt--;
                else
                    tempInt++;
            }
            return tempInt;
        }

        private void grow()
        {
            maxItems += 5;
            Item[] temp = new Item[maxItems];
            for (int i = 0; i < count; i++)
            {
                temp[i] = items[i];
            }
            items = temp;
        }

        public void CombineOrder(Order cOrder)
        {
            Item tempItem;
            int count = 0;
            tempItem = cOrder.GetItem(count);
            while(tempItem != null)
            {
                add(tempItem);
                tempItem = cOrder.GetItem(++count);
            }
        }
    }
}
