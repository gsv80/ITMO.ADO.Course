using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;
using CodeFirst;
using static CodeFirst.Model;

namespace task9_1
{
    public partial class Form1 : Form
    {
        SampleContext context =new SampleContext();
        byte[] Ph;
        public Form1()
        {
            InitializeComponent();
            
        }
        

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Customer customer = new Customer
                {
                    Name = this.textBoxName.Text,
                    //LastName= this.textBoxLastName.Text,
                    Email = this.textBoxMail.Text,
                    Age = Int32.Parse(this.textBoxAge.Text),
                    Photo = Ph
                };
                context.Customers.Add(customer);
                context.SaveChanges();
                textBoxName.Text = String.Empty;
                textBoxLastName.Text = String.Empty;
                textBoxMail.Text = String.Empty;
                textBoxAge.Text = String.Empty;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.ToString());
            }
            
        }

        private void buttonFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog diag = new OpenFileDialog();
            if (diag.ShowDialog() == DialogResult.OK)
            {
                Image bm = new Bitmap(diag.OpenFile());

                ImageConverter converter = new ImageConverter();
                Ph = (byte[])converter.ConvertTo(bm, typeof(byte[]));
            }

        }
    }
}
