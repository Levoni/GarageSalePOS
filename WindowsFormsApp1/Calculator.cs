using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Calculator
    {
        float change = 0;
        float sum = 0;
        int oneHundreds = 0;
        int fiftys = 0;
        int twentys = 0;
        int tens = 0;
        int fives = 0;
        int ones = 0;
        int quarters = 0;
        int dimes = 0;
        int nickles = 0;
        int pennies = 0;

        public Calculator() { }

        public float Sum(Order order)
        {
            int index = 0;
            sum = 0;
            Item tempItem = order.GetItem(index);
            while (tempItem != null)
            {
                sum += tempItem.price;
                index++;
                tempItem = order.GetItem(index);
            }
            sum = (float)Math.Round(sum, 2);
            return sum;
        }

        public void Add(float amount)
        {
            sum += amount;
            sum = (float)Math.Round(sum, 2);
        }

        public void Subtract(float amount)
        {
            sum -= amount;
            sum = (float)Math.Round(sum, 2);
        }

        public float Change(float amount)
        {
            change = amount - sum;
            change = (float)Math.Round(change, 2);
            return change;
        }

        public void CalculateBills()
        {
            double tempTotal = change;

            oneHundreds = (int)(tempTotal / 100);
            tempTotal = tempTotal % 100;

            fiftys = (int)(tempTotal / 50);
            tempTotal = tempTotal % 50;

            twentys = (int)(tempTotal / 20);
            tempTotal = tempTotal % 20;

            tens = (int)(tempTotal / 10);
            tempTotal = tempTotal % 10;

            fives = (int)(tempTotal / 5);
            tempTotal = tempTotal % 5;

            ones = (int)(tempTotal / 1);
            tempTotal = tempTotal % 1;

            quarters = (int)(tempTotal / .25);
            tempTotal = tempTotal % .25;

            dimes = (int)(tempTotal / .10);
            tempTotal = tempTotal % .10;

            nickles = (int)(tempTotal / .05);
            tempTotal = tempTotal % .05;

            tempTotal = Math.Round(tempTotal,2);
            pennies = (int)(tempTotal / .01);
        }

        public void ResetSum()
        {
            sum = 0;
        }
        public int GetOneHundreds()
        {
            return oneHundreds;
        }

        public int GetFifties()
        {
            return fiftys;
        }

        public int GetTwenties()
        {
            return twentys;
        }

        public int GetTens()
        {
            return tens;
        }

        public int GetFives()
        {
            return fives;
        }

        public int GetOnes()
        {
            return ones;
        }

        public int GetQuarters()
        {
            return quarters;
        }

        public int GetDimes()
        {
            return dimes;
        }

        public int GetNickles()
        {
            return nickles;
        }

        public int GetPennies()
        {
            return pennies;
        }

        public float GetChange()
        {
            return change;
        }

        public float GetSum()
        {
            return sum;
        }
    }
}
