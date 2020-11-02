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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        public DataTable table { get; set; }

        private void Form2_Load(object sender, EventArgs e) {
            dataGridView1.DataSource = table;
            dataGridView1.Rows[0].Selected = true;
        }

        private void inputMerchandiseToolStripMenuItem_Click(object sender, EventArgs e)
        {
         
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonSearchQuantity_Click(object sender, EventArgs e) {
            // Reset all filtered results on datagridview before searching again
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = table;
            // Loop and check for rows of with "quantity" > user input then hide them to display the remaining rows
            // as result
            int quantity = Int32.Parse(textQuantity.Text);
            int i;
            for(i = 0; i < dataGridView1.Rows.Count - 1; i = i + 1) {
                if (Int32.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString()) > quantity) {
                    dataGridView1.Rows[i].Visible = false;
                }
            }
        }
    }
}
