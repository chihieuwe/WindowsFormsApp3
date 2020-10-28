using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
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


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

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

        
        private void button1_Click(object sender, EventArgs e)
        {
            
            table.Rows.Add(txtID.Text, txtName.Text, txtQuantity.Text, txtPrice.Text);
            dataGridView1.DataSource = table;
        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripLabel2_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataGridViewRow newDataRow = dataGridView1.Rows[indexRow];
            newDataRow.Cells[0].Value = txtID.Text;
            newDataRow.Cells[1].Value = txtName.Text;
            newDataRow.Cells[2].Value = txtQuantity.Text;
            newDataRow.Cells[3].Value = txtPrice.Text;

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int rowIndex = dataGridView1.CurrentCell.RowIndex;
            dataGridView1.Rows.RemoveAt(rowIndex);         // remove value of a row
        }

        private void button4_Click(object sender, EventArgs e)
        {
           
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void checkQuantityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
           
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
