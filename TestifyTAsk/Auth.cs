using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestifyTAsk
{
    public partial class FormAuth : Form
    {
        public FormAuth()
        {
            InitializeComponent();
        }

        private void buttonGoTo_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormMain main= new FormMain();
            main.ShowDialog();
        }
    }
}
