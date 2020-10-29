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
            dataGridView1.DataSource = table;
            dataGridView1.Rows[0].Selected = true;
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            indexRow = e.RowIndex; 
            DataGridViewRow row = dataGridView1.Rows[indexRow];

            txtID.Text = row.Cells[0].Value.ToString();   //add index number for each row 
            txtName.Text = row.Cells[1].Value.ToString();
            txtQuantity.Text = row.Cells[2].Value.ToString();
            txtPrice.Text = row.Cells[3].Value.ToString();
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
            checkQuantity.Show();          
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printBill.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
