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

namespace task2_3
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
            openToolStripMenuItem.Enabled = e.CurrentState == ConnectionState.Closed;
            closeToolStripMenuItem.Enabled= e.CurrentState == ConnectionState.Open;
        }

        private void connectToDBToolStripMenuItem_Click(object sender, EventArgs e)
        {           
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

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {

                    connection.ConnectionString = testConnect;                       

                    connection.Open();
                    MessageBox.Show("Connection has been set up successfully");
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (connection.State == ConnectionState.Closed)
            {
                MessageBox.Show("Сначала подключитесь к базе");
                return;
            }

            OleDbCommand command = new OleDbCommand();
            command.Connection = connection;
            command.CommandText = "SELECT COUNT(*) FROM Products";
            int number = (int)command.ExecuteScalar();
            label1.Text = number.ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (connection.State == ConnectionState.Closed)
            {
                MessageBox.Show("Сначала подключитесь к базе");
                return;
            }

            OleDbCommand command = connection.CreateCommand();

            command.CommandText = "select ProductName from Products";
            OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                listView1.Items.Add(reader["ProductName"].ToString());
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            

            using (OleDbConnection connection = new OleDbConnection(testConnect))
            {
                connection.Open();

                OleDbTransaction transaction = connection.BeginTransaction();
                OleDbCommand command = connection.CreateCommand();

                command.Transaction = transaction;

                try
                {
                    command.CommandText = "insert into Products (ProductName) values ('Wrong Size')";
                    command.ExecuteNonQuery();

                    command.CommandText = "insert into Products (ProductName) values ('Wrong Color')";
                    command.ExecuteNonQuery();

                    transaction.Commit();
                    MessageBox.Show("Both records were written to database");

                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                    try
                    {
                        transaction.Rollback();
                    }
                    catch (Exception exRollback)
                    {
                        MessageBox.Show(exRollback.Message);
                    }
                }
            }
            

            

        }
    }
}
