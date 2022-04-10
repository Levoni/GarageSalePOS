using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
   class FileIO
   {
      //StreamReader reader = new StreamReader("test.txt");
      public void WriteOrder(Order order)
      {
         DateTime today = DateTime.Today;
         int index = 0;
         string fileString = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),"Garage Sale");
         if(!Directory.Exists(fileString))
         {
            Directory.CreateDirectory(fileString);
         }
         Item tempItem = order.GetItem(index);
         while (tempItem != null)
         {
            using (StreamWriter writer = File.AppendText(fileString + "\\" + today.ToString("MM") + "_" + today.ToString("dd") + "_" + today.ToString("yyyy") + "-" + tempItem.person + ".txt"))
            {
               writer.WriteLine(tempItem.price.ToString() + "," + tempItem.note);
            }
            index++;
            tempItem = order.GetItem(index);
         }
      }

      public float sumTextFile(string Textfile)
      {
         float sum = 0;
         string tempString = "";
         using (StreamReader reader = new StreamReader(Textfile))
         {
            tempString = reader.ReadLine();
            while (tempString != null)
            {
               if (tempString.Substring(0, 1) != "T")
               {
                  string[] tempStringArray = tempString.Split(',');
                  sum += float.Parse(tempStringArray[0]);
               }
               tempString = reader.ReadLine();
            }
         }
         //using (StreamWriter writer = File.AppendText(Textfile))
         //{
         //    writer.WriteLine("Total: " + sum.ToString());
         //}
         return sum;
      }

      public Order CreateOrderFromFile(string textFile)
      {
         Order tempOrder = null;
         string tempString = "";
         //string name = "";

         //string[] fileDirectorySpliter = textFile.Split('-');
         //fileDirectorySpliter = fileDirectorySpliter[1].Split('.');
         //name = fileDirectorySpliter[0];
         if (textFile != "")
         {
            try
            {
               using (StreamReader reader = new StreamReader(textFile))
               {
                  tempOrder = new Order();
                  tempString = reader.ReadLine();
                  while (tempString != null)
                  {
                     if (tempString.Substring(0, 1) != "T")
                     {
                        string[] tempStringArray = tempString.Split(',');
                        tempOrder.add("", float.Parse(tempStringArray[0]), tempStringArray[1]);
                     }
                     tempString = reader.ReadLine();
                  }
               }
            }
            catch(Exception e)
            {
               return null;
            }
         }
         return tempOrder;
      }

      public Order SumFiles(string start, string end)
      {
         string[] dateCreater = start.Split('_');
         Date startDate = new Date(int.Parse(dateCreater[0]), int.Parse(dateCreater[1]), int.Parse(dateCreater[2]));
         dateCreater = end.Split('_');
         Date endDate = new Date(int.Parse(dateCreater[0]), int.Parse(dateCreater[1]), int.Parse(dateCreater[2]));

         float tempFloat = 0;
         Stack<string> stack;
         string[] files;
         //string[] directories;
         string dir;
         string path = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Garage Sale") + "\\";

         string[] people = new string[10];
         for (int i = 0; i < 10; i++)
         {
            people[i] = "";
         }
         float[] prices = new float[10];
         for (int i = 0; i < 10; i++)
         {
            prices[i] = 0;
         }
         bool hasBeenUsed = false;

         stack = new Stack<string>();
         stack.Push(path);

         while (stack.Count > 0)
         {
            dir = stack.Pop();

            files = Directory.GetFiles(dir);
            foreach (string file in files)
            {
               string[] tempStringArray = file.Split('\\');
               string[] tempImportantStrings = tempStringArray[5].Split('-');
               string[] tempNameSeperator = tempImportantStrings[1].Split('.');
               string[] tempDateArray = tempImportantStrings[0].Split('_');
               Date tempDate = new Date(int.Parse(tempDateArray[0]), int.Parse(tempDateArray[1]), int.Parse(tempDateArray[2]));
               string tempName = tempNameSeperator[0];
               if (tempDate.CompareDate(startDate) >= 0
                  && tempDate.CompareDate(endDate) <= 0)
               {
                  hasBeenUsed = false;
                  for (int i = 0; i < 10; i++)
                  {
                     if (tempName == people[i])
                     {
                        prices[i] += sumTextFile(file);
                        hasBeenUsed = true;
                     }
                  }
                  if (!hasBeenUsed)
                  {
                     for (int i = 0; i < 10; i++)
                     {
                        if (!hasBeenUsed && people[i] == "")
                        {
                           people[i] = tempName;
                           hasBeenUsed = true;
                           prices[i] += sumTextFile(file);
                        }
                     }
                  }
                  tempFloat += sumTextFile(file);
               }


            }
            //To search all sub-directories
            /*
            directories = Directory.GetDirectories(dir);
            foreach( string directory in directories)
            {
                //push each directory on stack
                stack.Push(directory);
            }
            */
         }

         Order tempOrder = new Order();
         int count = 0;
         while (people[count] != "")
         {
            tempOrder.add(people[count], prices[count], "");
            count++;
         }
         tempOrder.add("Total", tempFloat, "");
         return tempOrder;

      }

      public Order SumFiles(string start, string end, string name)
      {
         string[] dateCreater = start.Split('_');
         Date startDate = new Date(int.Parse(dateCreater[0]), int.Parse(dateCreater[1]), int.Parse(dateCreater[2]));
         dateCreater = end.Split('_');
         Date endDate = new Date(int.Parse(dateCreater[0]), int.Parse(dateCreater[1]), int.Parse(dateCreater[2]));

         Order tempOrder = new Order();
         float tempFloat = 0;
         Stack<string> stack;
         string[] files;
         string[] directories;
         string dir;
         string path = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Garage Sale") + "\\"; ;
         int numberOfOrders = 0;


         stack = new Stack<string>();
         stack.Push(path);

         while (stack.Count > 0)
         {
            dir = stack.Pop();

            files = Directory.GetFiles(dir);
            foreach (string file in files)
            {
               string[] tempStringArray = file.Split('\\');
               string[] tempImportantStrings = tempStringArray[5].Split('-');
               string[] tempNameSeperator = tempImportantStrings[1].Split('.');
               string[] tempDateArray = tempImportantStrings[0].Split('_');
               Date tempDate = new Date(int.Parse(tempDateArray[0]), int.Parse(tempDateArray[1]), int.Parse(tempDateArray[2]));
               string tempName = tempNameSeperator[0];
               if (tempDate.CompareDate(startDate) >= 0
                  && tempDate.CompareDate(endDate) <= 0
                  && tempName == name)
               {
                  tempOrder.add(tempDate.ToString() + ": ", sumTextFile(file), "");
                  tempOrder.CombineOrder(CreateOrderFromFile(file));
                  tempFloat += sumTextFile(file);
                  numberOfOrders++;
               }

            }
            //to search all sub-directories
            /*
            directories = Directory.GetDirectories(dir);
            foreach (string directory in directories)
            {
                //push each directory on stack
                stack.Push(directory);
            }
            */
         }
         tempOrder.add("Items: ", tempOrder.GetTotalItems() - numberOfOrders, "");
         tempOrder.add("Total: ", tempFloat, "");
         return tempOrder;
      }
   }
}
