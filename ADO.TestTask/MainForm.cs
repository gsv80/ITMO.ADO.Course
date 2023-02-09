using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ADO.TestTask
{
    public partial class MainForm : Form
    {


        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            CustomersDataGridView.DataSource = northwindDataSet1.Customers;
            CustomersDataGridView.MultiSelect = false;
            CustomersDataGridView.SelectionMode = DataGridViewSelectionMode.CellSelect;
            CustomersDataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void buttonGetData_Click(object sender, EventArgs e)
        {
            sqlDataAdapter1.Fill(northwindDataSet1.Customers);
        }

        private void AddRowButton_Click(object sender, EventArgs e)
        {
            NorthwindDataSet.CustomersRow NewRow = (NorthwindDataSet.CustomersRow)northwindDataSet1.Customers.NewRow();

            //NewRow.CustomerID = "WINGT";
            //NewRow.CompanyName = "Wingtip Toys";
            //NewRow.ContactName = "Steve Lasker";
            //NewRow.ContactTitle = "CEO";
            //NewRow.Address = "1234 Main Street";
            //NewRow.City = "Buffalo";
            //NewRow.Region = "NY";
            //NewRow.PostalCode = "98052";
            //NewRow.Country = "USA";
            //NewRow.Phone = "206-555-0111";
            //NewRow.Fax = "206-555-0112";

            try
            {
                northwindDataSet1.Customers.Rows.Add(NewRow);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Add Row Failed");
            }



        }

        private NorthwindDataSet.CustomersRow GetSelectedRow()
        {
            String SelectedCustomerID = CustomersDataGridView.CurrentRow.Cells["CustomerID"].Value.ToString();
            NorthwindDataSet.CustomersRow SelectedRow = northwindDataSet1.Customers.FindByCustomerID(SelectedCustomerID);
            return SelectedRow;
        }

        private void DeleteRowButton_Click(object sender, EventArgs e)
        {
            GetSelectedRow().Delete();
        }
    }
}
