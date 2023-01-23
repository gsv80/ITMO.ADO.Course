using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Runtime.CompilerServices;
using System.Configuration;

namespace task1_5
{
    
    public partial class Form1 : Form
    {
        OleDbConnection connection = new OleDbConnection();

        //string testConnect = @"Provider=MSOLEDBSQL; Server=(localdb)\MSSQLLocalDB;Trusted_Connection=Yes; AttachDbFileName=C:\Users\sergey\NORTHWND.MDF; Database=Northwnd";


        
        public Form1()
        {
            InitializeComponent();
            this.connection.StateChange += new StateChangeEventHandler(this.connection_StateChange);
        }

        static string GetConnectionStringByName(string name)
        {
            string returnValue = null;
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings[name];
            if(settings != null)
            {
                returnValue = settings.ConnectionString;
            }
            return returnValue;
        }

        string testConnect = GetConnectionStringByName("NorthwndDb");
        private void connection_StateChange(object sender, StateChangeEventArgs e)
        {
            connectToDBToolStripMenuItem.Enabled = (e.CurrentState == ConnectionState.Closed);
            connectToDBToolStripMenuItem.Enabled = (e.CurrentState == ConnectionState.Open);
        }

        private void connectToDBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try 
            {
                if(connection.State != ConnectionState.Open)
                {
                    connection.ConnectionString = testConnect;
                    connection.Open();
                    MessageBox.Show("Connection has been set up successefully");
                }
                else
                {
                    MessageBox.Show("Connection already set");
                }
            }
            catch(OleDbException ex)
            {
                foreach( OleDbError se in ex.Errors)
                {
                    MessageBox.Show(se.Message, "SQL error: " + se.NativeError, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            

            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
                MessageBox.Show("Connection closed");
            }
            else
            {
                MessageBox.Show("Connection alredy closed");
            }
        }

        private void connectionsListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConnectionStringSettingsCollection settings = ConfigurationManager.ConnectionStrings;
            if(settings !=null)
            {
                foreach(ConnectionStringSettings s in settings)
                {
                    MessageBox.Show($"name = {s.Name} , providerName = {s.ProviderName} ,connectionString = {s.ConnectionString} ");
                }
            }
        }
    }
}
