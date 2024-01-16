using FireSharp.Config;
using FireSharp.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace taskagitmakas
{
    public partial class odabilgisi : Form
    {
        public odabilgisi()
        {
            InitializeComponent();
        }

        private void odabilgisi_Load(object sender, EventArgs e)
        {
            label2.Text = odalar.secilenoda;
            label4.Text = odalar.bilgiodaidstr;
            label5.Text = parolagir.odaparolasi;
            if(parolagir.odaparolasi=="Oda Parolası")
            {
                label5.Visible = false;
            }
            this.TopMost = true;
        }




        public class Data
        {
            public string odaparola { get; set; }

        }
        private void button10_Click(object sender, EventArgs e)
        {
            Form3.odabilgisiflag = false;
            player2.odabilgisiflag2 = false;
            Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
