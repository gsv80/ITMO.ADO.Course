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

namespace task1_4
{
    
    public partial class Form1 : Form
    {
        OleDbConnection connection = new OleDbConnection();
        string testConnect = @"Provider=MSOLEDBSQL; Server=(localdb)\MSSQLLocalDB;Trusted_Connection=Yes; AttachDbFileName=C:\Users\sergey\NORTHWND.MDF; Database=Northwnd";
       
        public Form1()
        {
            InitializeComponent();
            this.connection.StateChange += new StateChangeEventHandler(this.connection_StateChange);
        }

        private void connection_StateChange(object sender, StateChangeEventArgs e)
        {
            
            openToolStripMenuItem.Enabled = (e.CurrentState == ConnectionState.Closed);
            closeToolStripMenuItem.Enabled = e.CurrentState == ConnectionState.Open;
        }

        private void connectToDBToolStripMenuItem_Click(object sender, EventArgs e)
        {   
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (connection.State != ConnectionState.Open)
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
            catch (OleDbException ex)
            {
                foreach (OleDbError se in ex.Errors)
                {
                    MessageBox.Show(se.Message, "SQL error: " + se.NativeError, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
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
    }
}
