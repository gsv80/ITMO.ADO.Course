using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace task4_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void GetCustomersButton_Click(object sender, EventArgs e)
        {
            DataSet1 NorthwindDataset1 = new DataSet1();

            DataSet1TableAdapters.CustomersTableAdapter CustomersTableAdapter1 =new DataSet1TableAdapters.CustomersTableAdapter();

            CustomersTableAdapter1.Fill(NorthwindDataset1.Customers);

            foreach (DataSet1.CustomersRow NWCustomer in
                             NorthwindDataset1.Customers.Rows)
            {
                CustomersListBox.Items.Add(NWCustomer.CompanyName);
            }

        }
    }
}
