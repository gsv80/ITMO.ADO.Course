using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConnectionLocalDB
{
    public partial class ConnectLocalDB : Form
    {
        List<Territory> territories = new List<Territory>();
        public ConnectLocalDB()
        {
            InitializeComponent();
            UpdateBinding();   
        }

        private void UpdateBinding()
        {
            territoriesListBox.DataSource = territories;
            territoriesListBox.DisplayMember = "FullInfo";

        }
        private void searchBtn_Click(object sender, EventArgs e)
        {  
            DataAccess db = new DataAccess();
            territories =  db.GetTerritory(territoryDescTextBox.Text);
            UpdateBinding(); 
            
        }
    }
}
