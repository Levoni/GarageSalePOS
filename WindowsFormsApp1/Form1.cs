using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsApp1
{
   public partial class Form1 : Form
   {
      private Calculator calc = new Calculator();
      private Order Order = new Order();
      private FileIO file = new FileIO();
      public Form1()
      {
         InitializeComponent();
         calc = new Calculator();
      }

      private void button11_Click(object sender, EventArgs e)
      {
         addItem();
      }

      private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
      {

      }

      private void Form1_KeyUp(object sender, KeyEventArgs e)
      {

      }

      private void listBox1_KeyUp(object sender, KeyEventArgs e)
      {
         if (e.KeyCode == Keys.Delete)
            if (listBox1.SelectedIndex != -1)
            {
               calc.Subtract(Order.GetItem(listBox1.SelectedIndex).price);
               lblTotal.Text = "Total: " + calc.GetSum().ToString();
               Order.remove(listBox1.SelectedIndex);
               displayItems();
            }
         if (e.KeyCode == Keys.C)
         {
            clearOrder();
         }

      }

      private void button2_Click(object sender, EventArgs e)
      {
         txtPrice.AppendText("8");
         txtPrice.Focus();
      }

      private void txtPrice_TextChanged(object sender, EventArgs e)
      {

      }

      private void btn7_Click(object sender, EventArgs e)
      {
         txtPrice.AppendText("7");
         txtPrice.Focus();
      }

      private void btn9_Click(object sender, EventArgs e)
      {
         txtPrice.AppendText("9");
         txtPrice.Focus();
      }

      private void btn4_Click(object sender, EventArgs e)
      {
         txtPrice.AppendText("4");
         txtPrice.Focus();
      }

      private void btn5_Click(object sender, EventArgs e)
      {
         txtPrice.AppendText("5");
         txtPrice.Focus();
      }

      private void btn6_Click(object sender, EventArgs e)
      {
         txtPrice.AppendText("6");
         txtPrice.Focus();
      }

      private void btn1_Click(object sender, EventArgs e)
      {
         txtPrice.AppendText("1");
         txtPrice.Focus();
      }

      private void btn2_Click(object sender, EventArgs e)
      {
         txtPrice.AppendText("2");
         txtPrice.Focus();
      }

      private void btn3_Click(object sender, EventArgs e)
      {
         txtPrice.AppendText("3");
         txtPrice.Focus();
      }

      private void btn0_Click(object sender, EventArgs e)
      {
         txtPrice.AppendText("0");
         txtPrice.Focus();
      }

      private void txtPrice_KeyUp(object sender, KeyEventArgs e)
      {
         if (e.KeyCode == Keys.Enter)
            addItem();
         if (e.KeyCode == Keys.N)
            txtNote.Focus();
         if (e.KeyCode == Keys.L)
            rbtnLevon.Checked = true;
         if (e.KeyCode == Keys.D)
            rbtnDeacon.Checked = true;
         if (e.KeyCode == Keys.A)
            rbtnAubrey.Checked = true;
         if (e.KeyCode == Keys.S)
            rbtnSashia.Checked = true;
         if (e.KeyCode == Keys.O)
            rbtnOther.Checked = true;
         if (e.KeyCode == Keys.B)
            rbtnBonnie.Checked = true;
         if (e.KeyCode == Keys.G)
            rbtnGloria.Checked = true;
      }

      private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
      {
         if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
            (e.KeyChar != '.'))
         {
            e.Handled = true;
         }

         // only allow one decimal point
         if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
         {
            e.Handled = true;
         }
      }

      private void btnDecimal_Click(object sender, EventArgs e)
      {
         txtPrice.AppendText(".");
         txtPrice.Focus();
      }

      private void btnCheckout_Click(object sender, EventArgs e)
      {
         Checkout();
      }

      private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
      {
         if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
            (e.KeyChar != '.') && (e.KeyChar == '-'))
         {
            e.Handled = true;
         }

         // only allow one decimal point
         if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
         {
            e.Handled = true;
         }
      }

      private void txtPayment_KeyUp(object sender, KeyEventArgs e)
      {
         if (e.KeyCode == Keys.Enter)
         {
            Checkout();
         }
         if (e.KeyCode == Keys.C)
         {
            clearOrder();
         }
      }

      private void btnFinish_Click(object sender, EventArgs e)
      {
         file.WriteOrder(Order);
         clearOrder();
      }


      private void textBox2_KeyUp(object sender, KeyEventArgs e)
      {
         if (e.KeyCode == Keys.Enter)
            addItem();
      }

      private void label1_Click(object sender, EventArgs e)
      {

      }

      private void Registor_Click(object sender, EventArgs e)
      {

      }

      private void btnOpenFile_Click(object sender, EventArgs e)
      {
         listBox2.Items.Clear();
         openFileDialog1.InitialDirectory = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Garage Sale") + "\\";
         openFileDialog1.FileName = "";
            openFileDialog1.ShowDialog();
         Order tempOrder = file.CreateOrderFromFile(openFileDialog1.FileName);
         if (tempOrder != null)
         {
            int tempInt = 0;
            Item tempItem = tempOrder.GetItem(tempInt++);
            while (tempItem != null)
            {
               if (tempItem.note == "")
                  listBox2.Items.Add(tempItem.price.ToString());
               else
                  listBox2.Items.Add(tempItem.price.ToString() + " // " + tempItem.note);
               tempItem = tempOrder.GetItem(tempInt++);
            }
            listBox2.Items.Add("Total: " + file.sumTextFile(openFileDialog1.FileName));
            listBox2.Items.Add("Items Sold: " + tempOrder.GetTotalItems().ToString());
         }
      }

      private void btnNegative_Click(object sender, EventArgs e)
      {
         txtPrice.Text = "-" + txtPrice.Text;
      }

      private void txtNote_KeyDown(object sender, KeyEventArgs e)
      {
         if (e.KeyCode == Keys.Enter)
            addItem();
      }

      private void btnSumDate_Click(object sender, EventArgs e)
      {
         PrintDateTotal();
      }

      private void btnSumPerson_Click(object sender, EventArgs e)
      {
         PrintPersonTotal();
      }

      private void button1_Click(object sender, EventArgs e)
      {
         DateTime tempTime = DateTime.Today;
         txtStartMonth.Text = tempTime.ToString("MM");
         txtStartDay.Text = tempTime.ToString("dd");
         txtStartYear.Text = tempTime.ToString("yyyy");
         txtEndMonth.Text = tempTime.ToString("MM");
         txtEndDay.Text = tempTime.ToString("dd");
         txtEndYear.Text = tempTime.ToString("yyyy");

      }

      private void txtName_KeyDown(object sender, KeyEventArgs e)
      {
         if (e.KeyCode == Keys.Enter)
         {
            PrintPersonTotal();
         }
      }

      //user functions
      private void addItem()
      {
         String Person = "";
         if (rbtnLevon.Checked == true)
            Person = "Levon";
         if (rbtnDeacon.Checked == true)
            Person = "Deacon";
         if (rbtnSashia.Checked == true)
            Person = "Sashia";
         if (rbtnAubrey.Checked == true)
            Person = "Aubrey";
         if (rbtnGloria.Checked == true)
            Person = "Gloria";
         if (rbtnBonnie.Checked == true)
            Person = "Bonnie";
         if (rbtnOther.Checked == true)
            Person = textBox2.Text;

         if (txtPrice.Text != "" && float.Parse(txtPrice.Text) != 0)
         {
            Order.add(Person, float.Parse(txtPrice.Text), txtNote.Text);
            Item tempItem = Order.GetItem(listBox1.Items.Count);
            if (txtNote.Text == "")
               listBox1.Items.Add(tempItem.person + " $" + tempItem.price.ToString());
            else
               listBox1.Items.Add(tempItem.person + " $" + tempItem.price.ToString() + " // " + txtNote.Text);
            calc.Add(tempItem.price);
         }
         lblTotal.Text = "Total: " + calc.GetSum().ToString();
         txtPrice.Text = "";
         txtNote.Text = "";
         txtPrice.Focus();
         displayItems();
      }


      private void displayItems()
      {
         listBox1.Items.Clear();
         int index = 0;
         Item tempItem = Order.GetItem(index);
         while (tempItem != null)
         {
            if (tempItem.note == "")
               listBox1.Items.Add(tempItem.person + " $" + tempItem.price.ToString());
            else
               listBox1.Items.Add(tempItem.person + " $" + tempItem.price.ToString() + " // " + tempItem.note);
            index++;
            tempItem = Order.GetItem(index);
         }
      }

      private void Checkout()
      {
         calc.Sum(Order);
         if (txtPayment.Text != "")
            calc.Change(float.Parse(txtPayment.Text));
         else
            calc.Change(calc.GetSum());
         calc.CalculateBills();

         richTextBox1.Clear();
         richTextBox1.AppendText("Total: " + calc.GetSum() + '\n');
         richTextBox1.AppendText("Change: " + calc.GetChange() + '\n');
         richTextBox1.AppendText("Hundreds: " + calc.GetOneHundreds().ToString() + '\n');
         richTextBox1.AppendText("Fifties: " + calc.GetFifties().ToString() + '\n');
         richTextBox1.AppendText("Twenties: " + calc.GetTwenties().ToString() + '\n');
         richTextBox1.AppendText("Tens: " + calc.GetTens().ToString() + '\n');
         richTextBox1.AppendText("Fives: " + calc.GetFives().ToString() + '\n');
         richTextBox1.AppendText("Ones: " + calc.GetOnes().ToString() + '\n');
         richTextBox1.AppendText("Quarters: " + calc.GetQuarters().ToString() + '\n');
         richTextBox1.AppendText("Dimes: " + calc.GetDimes().ToString() + '\n');
         richTextBox1.AppendText("Nickles: " + calc.GetNickles().ToString() + '\n');
         richTextBox1.AppendText("Pennies: " + calc.GetPennies().ToString() + '\n');
      }

      private void clearOrder()
      {
         Order.Clear();
         listBox1.Items.Clear();
         txtPayment.Clear();
         txtPrice.Clear();
         lblTotal.Text = "Total: 0.00";
         richTextBox1.Clear();
         calc.ResetSum();
      }

      private void PrintDateTotal()
      {
         listBox2.Items.Clear();
         Order tempOrder = new Order();
         if (txtStartMonth.Text != "" && txtStartDay.Text != "" && txtStartYear.Text != ""
            && txtEndMonth.Text != "" && txtEndDay.Text != "" && txtEndYear.Text != "")
         {
            string tempStartDate = txtStartMonth.Text + "_" + txtStartDay.Text + "_" + txtStartYear.Text;
            string tempEndDate = txtEndMonth.Text + "_" + txtEndDay.Text + "_" + txtEndYear.Text;
            tempOrder = file.SumFiles(tempStartDate, tempEndDate);
            for (int i = 0; i < tempOrder.GetTotalItems(); i++)
            {
               listBox2.Items.Add(tempOrder.GetItem(i).person + ": " + tempOrder.GetItem(i).price.ToString());
            }

         }
      }

      private void PrintPersonTotal()
      {
         listBox2.Items.Clear();
         Order tempOrder = new Order();
         if (txtStartMonth.Text != "" && txtStartDay.Text != "" && txtStartYear.Text != ""
             && txtEndMonth.Text != "" && txtEndDay.Text != "" && txtEndYear.Text != ""
             && txtName.Text != "")
         {
            string tempStartDate = txtStartMonth.Text + "_" + txtStartDay.Text + "_" + txtStartYear.Text;
            string tempEndDate = txtEndMonth.Text + "_" + txtEndDay.Text + "_" + txtEndYear.Text;
            tempOrder = file.SumFiles(tempStartDate, tempEndDate, txtName.Text);
            for (int i = 0; i < tempOrder.GetTotalItems(); i++)
            {
               listBox2.Items.Add(tempOrder.GetItem(i).person + tempOrder.GetItem(i).price.ToString());
            }
         }
      }
   }
}

