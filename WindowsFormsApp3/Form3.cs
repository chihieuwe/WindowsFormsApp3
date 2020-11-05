using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        DataTable table = new DataTable();
        DataTable orderTable = new DataTable();
        public DataTable f1table { get; set; }

        public float discount(int original, int percentage) {
            float result = 0;
            result = original - (percentage * original / 100);
            return result;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form3_Load(object sender, EventArgs e) {
            // Add columns and rows for customer table
            table.Columns.Add("ID", typeof(int));  // add column values for data table 
            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("OrderID", typeof(int));
            table.Columns.Add("Date", typeof(DateTime));
            table.Columns.Add("Total", typeof(int));
            table.Columns.Add("AfterSaveOff", typeof(int));

            DataRow dataRow = table.NewRow();
            dataRow["ID"] = 1;
            dataRow["Name"] = "Mark";
            dataRow["OrderID"] = 215;
            dataRow["Date"] = "12-10-2020 12:00:00 PM";


            table.Rows.Add(dataRow);

            DataRow dataRow1 = table.NewRow();
            dataRow1["ID"] = 2;
            dataRow1["Name"] = "Lisa";
            dataRow1["OrderID"] = 216;
            dataRow1["Date"] = "5-8-2020 03:00:00 PM";
            table.Rows.Add(dataRow1);

            DataRow dataRow2 = table.NewRow();
            dataRow2["ID"] = 3;
            dataRow2["Name"] = "Andy";
            dataRow2["OrderID"] = 217;
            dataRow2["Date"] = "1-10-2020 01:00:00 PM";
            table.Rows.Add(dataRow2);

            DataRow dataRow3 = table.NewRow();
            dataRow3["ID"] = 4;
            dataRow3["Name"] = "Hairy";
            dataRow3["OrderID"] = 218;
            dataRow3["Date"] = "2-2-2020 05:00:00 PM";
            table.Rows.Add(dataRow3);

            // Add columns and rows for order table
            orderTable.Columns.Add("OrderIdCode", typeof(int));
            orderTable.Columns.Add("ProductName", typeof(string));
            orderTable.Columns.Add("Quantity", typeof(int));
            orderTable.Columns.Add("Price", typeof(int));

            DataRow orderRow1 = orderTable.NewRow();
            orderRow1["OrderIdCode"] = 215;
            orderRow1["ProductName"] = "CocaCola";
            orderRow1["Quantity"] = 3;
            orderRow1["Price"] = 2000;
            orderTable.Rows.Add(orderRow1);

            DataRow orderRow2 = orderTable.NewRow();
            orderRow2["OrderIdCode"] = 216;
            orderRow2["ProductName"] = "Pepsi";
            orderRow2["Quantity"] = 5;
            orderRow2["Price"] = 2500;
            orderTable.Rows.Add(orderRow2);

            DataRow orderRow3 = orderTable.NewRow();
            orderRow3["OrderIdCode"] = 217;
            orderRow3["ProductName"] = "Colgate Toothpaste";
            orderRow3["Quantity"] = 5;
            orderRow3["Price"] = 20000;
            orderTable.Rows.Add(orderRow3);

            DataRow orderRow4 = orderTable.NewRow();
            orderRow4["OrderIdCode"] = 217;
            orderRow4["ProductName"] = "Iphone";
            orderRow4["Quantity"] = 2;
            orderRow4["Price"] = 7000000;
            orderTable.Rows.Add(orderRow4);

            DataRow orderRow5 = orderTable.NewRow();
            orderRow5["OrderIdCode"] = 218;
            orderRow5["ProductName"] = "Sugar(1kg bag)";
            orderRow5["Quantity"] = 2;
            orderRow5["Price"] = 45000;
            orderTable.Rows.Add(orderRow5);

            DataRow orderRow6 = orderTable.NewRow();
            orderRow6["OrderIdCode"] = 218;
            orderRow6["ProductName"] = "Heinz Ketchup";
            orderRow6["Quantity"] = 3;
            orderRow6["Price"] = 35000;
            orderTable.Rows.Add(orderRow6);

            dataGridView1.DataSource = orderTable;
        }

        private void buttonSearch_Click(object sender, EventArgs e) {

            

            dataGridView1.DataSource = null;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = orderTable;

            string str = textId.Text;

            string name, orderId, date;
            name = orderId = date = "";
            int total = 0;

            // Loop through each row in table to find the matching customerID then print out data from the corresponding row
            foreach (DataRow row in table.Rows) {
                if (row["ID"].ToString().Equals(str)) {

                    name = row["Name"].ToString();
                    orderId = row["OrderID"].ToString();
                    date = row["Date"].ToString();

                    textName.Text = name;
                    textOrderId.Text = orderId;
                    textDate.Text = date;

                    // Loop through each row in table to find the matching orderID then print them out on grid
                    // by hiding the unmatched rows
                    for (int i = 0; i < dataGridView1.Rows.Count - 1; i = i + 1) {
                        if (dataGridView1.Rows[i].Cells[0].Value.ToString() != orderId) {
                            // The "CurrencyManager" code lines fix an error, don't know how that works so don't bother asking
                            CurrencyManager currencyManager = (CurrencyManager)BindingContext[dataGridView1.DataSource];
                            currencyManager.SuspendBinding();
                            dataGridView1.Rows[i].Visible = false;
                            currencyManager.ResumeBinding();
                        }
                    }

                    // Loop through each row in table to calculate the total cost of order
                    for (int i = 0; i < dataGridView1.Rows.Count - 1; i = i + 1) {
                        if (dataGridView1.Rows[i].Cells[0].Value.ToString() == orderId) {
                            total = total + (Int32.Parse(dataGridView1.Rows[i].Cells["Price"].Value.ToString()) * Int32.Parse(dataGridView1.Rows[i].Cells["Quantity"].Value.ToString()));
                        }
                    }
                    textTotal.Text = total.ToString();

                    // Calculate total cost after discount
                    if (total > 1000000) { textAfterSave.Text = discount(total, 30).ToString(); }
                    else if (total > 500000 && total <= 1000000) { textAfterSave.Text = discount(total, 10).ToString(); }
                    else { textAfterSave.Text = discount(total, 0).ToString(); }
                }
            }

        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e) {
            string product = orderTable.Rows[e.RowIndex].Field<string>(1);
            int quantity = orderTable.Rows[e.RowIndex].Field<int>(2);
            int productPrice = 0;
            int totalPrice;

            for (int i = 0; i < f1table.Rows.Count; i = i + 1) {
                if (f1table.Rows[i].Field<string>(1).ToString() == product) {
                    productPrice = f1table.Rows[i].Field<int>(3);
                    break;
                }
            }

            totalPrice = quantity * productPrice;
            orderTable.Rows[e.RowIndex][3] = totalPrice;
        }
    }
}
