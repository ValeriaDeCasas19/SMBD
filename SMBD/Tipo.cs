using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMBD
{

    public partial class Tipo : Form
    {
        public Tipo()
        {
            InitializeComponent();
        }

      

        private void Tipo_Load(object sender, EventArgs e)
        {

        }
        public int valor;

       

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
                valor = 0;
            else if (radioButton2.Checked == true)
                valor = 1;
            else if (radioButton3.Checked == true)
                valor = 2;
            else if (radioButton4.Checked == true)
                valor = 3;
            else
                valor = 4;
            this.Close();
        }
    }
}
