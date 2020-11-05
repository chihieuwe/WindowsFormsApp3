using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }
        DataTable table = new DataTable();
        int indexRow;
        DataRow dataRow;
        Form2 checkQuantity = new Form2();
        Form3 printBill = new Form3();

        public bool isEmpty() {
            if (txtID.Text == "" || txtName.Text == "" || txtPrice.Text == "" || txtQuantity.Text == "") {
                return true;
            }
            else { return false; }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            table.Columns.Add("ID", typeof(int));  // add column values for data table 
            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("Quantity", typeof(int));
            table.Columns.Add("Price", typeof(int));
            dataRow = table.NewRow();
            dataRow["ID"] = 1;
            dataRow["Name"] = "CocaCola";
            dataRow["Quantity"] = 55;
            dataRow["Price"] = 7000;
            table.Rows.Add(dataRow);
            DataRow dataRow2 = table.NewRow();
            dataRow2["ID"] = 2;
            dataRow2["Name"] = "Pepsi";
            dataRow2["Quantity"] = 80;
            dataRow2["Price"] = 7500;
            table.Rows.Add(dataRow2);

            DataRow dataRow3 = table.NewRow();
            dataRow3["ID"] = 4;
            dataRow3["Name"] = "Colgate Toothpaste";
            dataRow3["Quantity"] = 170;
            dataRow3["Price"] = 20000;
            table.Rows.Add(dataRow3);

            DataRow dataRow4 = table.NewRow();
            dataRow4["ID"] = 3;
            dataRow4["Name"] = "Iphone";
            dataRow4["Quantity"] = 10;
            dataRow4["Price"] = 7000000;
            table.Rows.Add(dataRow4);

            DataRow dataRow5 = table.NewRow();
            dataRow5["ID"] = 5;
            dataRow5["Name"] = "Sugar(1kg bag)";
            dataRow5["Quantity"] = 50;
            dataRow5["Price"] = 45000;
            table.Rows.Add(dataRow5);

            DataRow dataRow6 = table.NewRow();
            dataRow6["ID"] = 6;
            dataRow6["Name"] = "Heinz Ketchup";
            dataRow6["Quantity"] = 210;
            dataRow6["Price"] = 35000;
            table.Rows.Add(dataRow6);

            dataGridView1.DataSource = table;

        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {

        }

        
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (isEmpty() == false) {
                table.Rows.Add(txtID.Text, txtName.Text, txtQuantity.Text, txtPrice.Text);
                dataGridView1.DataSource = table;
            }
            else { MessageBox.Show("All spaces must not be empty, please try again."); }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if(isEmpty() == false) {
                DataGridViewRow newDataRow = dataGridView1.Rows[indexRow];
                newDataRow.Cells[0].Value = txtID.Text;
                newDataRow.Cells[1].Value = txtName.Text;
                newDataRow.Cells[2].Value = txtQuantity.Text;
                newDataRow.Cells[3].Value = txtPrice.Text;
            }
            else { MessageBox.Show("All spaces must not be empty, please try again."); }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            int rowIndex = dataGridView1.CurrentCell.RowIndex;
            dataGridView1.Rows.RemoveAt(rowIndex);         // remove value of a row
        }

        private void checkQuantityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 checkQuantity = new Form2();
            checkQuantity.table = table;
            checkQuantity.Show();          
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 printBill = new Form3();
            printBill.f1table = table;
            printBill.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e) {
            if (e.StateChanged != DataGridViewElementStates.Selected) return;
            int rowIndex = dataGridView1.CurrentCell.RowIndex;

            txtID.Text = dataGridView1.Rows[rowIndex].Cells[0].Value.ToString();
            txtName.Text = dataGridView1.Rows[rowIndex].Cells[0].Value.ToString();
            txtQuantity.Text = dataGridView1.Rows[rowIndex].Cells[0].Value.ToString();
            txtPrice.Text = dataGridView1.Rows[rowIndex].Cells[0].Value.ToString();
        }
    }
}
