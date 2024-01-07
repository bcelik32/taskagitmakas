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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
        string secim = "yok";
        string secim2 = "yok";
        bool hazir= false;
        bool hazir2 = false;


        private void button1_Click(object sender, EventArgs e)
        {
            secim = "Taş";
            button1.FlatAppearance.BorderColor = Color.Red;
            button1.FlatAppearance.BorderSize = 2;


            button2.FlatAppearance.BorderColor = SystemColors.Control;
            button2.FlatAppearance.BorderSize = 2;
            button3.FlatAppearance.BorderColor = SystemColors.Control;
            button3.FlatAppearance.BorderSize = 2;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            secim = "Kağıt";
            button2.FlatAppearance.BorderColor = Color.Red;
            button2.FlatAppearance.BorderSize = 2;


            button1.FlatAppearance.BorderColor = SystemColors.Control;
            button1.FlatAppearance.BorderSize = 2;
            button3.FlatAppearance.BorderColor = SystemColors.Control;
            button3.FlatAppearance.BorderSize = 2;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            secim = "Makas";
            button3.FlatAppearance.BorderColor = Color.Red;
            button3.FlatAppearance.BorderSize = 2;

            button1.FlatAppearance.BorderColor = SystemColors.Control;
            button1.FlatAppearance.BorderSize = 2;
            button2.FlatAppearance.BorderColor = SystemColors.Control;
            button2.FlatAppearance.BorderSize = 2;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            hazir = true;
        
            if (timer1.Enabled != true)
            {
                timer1.Start();
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            secim2 = "Taş";
            button5.FlatAppearance.BorderColor = SystemColors.Control;
            button5.FlatAppearance.BorderSize = 2;
            button4.FlatAppearance.BorderColor = SystemColors.Control;
            button4.FlatAppearance.BorderSize = 2;

            button6.FlatAppearance.BorderColor = Color.Red;
            button6.FlatAppearance.BorderSize = 2;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            secim2 = "Kağıt";
            button5.FlatAppearance.BorderColor = Color.Red;
            button5.FlatAppearance.BorderSize = 2;


            button4.FlatAppearance.BorderColor = SystemColors.Control;
            button4.FlatAppearance.BorderSize = 2;
            button6.FlatAppearance.BorderColor = SystemColors.Control;
            button6.FlatAppearance.BorderSize = 2;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            secim2 = "Makas";
            button4.FlatAppearance.BorderColor = Color.Red;
            button4.FlatAppearance.BorderSize = 2;

            button5.FlatAppearance.BorderColor = SystemColors.Control;
            button5.FlatAppearance.BorderSize = 2;

            button6.FlatAppearance.BorderColor = SystemColors.Control;
            button6.FlatAppearance.BorderSize = 2;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            hazir2 = true;
            if (timer1.Enabled != true)
            {
                timer1.Start();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (hazir == true && hazir2 == true)
            {
               

                if (secim == "Taş" && secim2 == "Taş")
                {
                    label3.Text = "Berabere!";
                }
                else if (secim == "Taş" && secim2 == "Kağıt")
                {
                    label3.Text = "2. Oyuncu Kazandı";
                }
                else if (secim == "Taş" && secim2 == "Makas")
                {
                    label3.Text = "1. Oyuncu Kazandı!";
                }
                else if (secim == "Kağıt" && secim2 == "Kağıt")
                {
                    label3.Text = "Berabere!";
                }
                else if (secim == "Kağıt" && secim2 == "Makas")
                {
                    label3.Text = "2. Oyuncu Kazandı!";
                }
                else if (secim == "Kağıt" && secim2 == "Taş")
                {
                    label3.Text = "1. Oyuncu Kazandı!";
                }
                else if (secim == "Makas" &&    secim2 == "Makas")
                {
                    label3.Text = "Berabere!!";
                }
                else if (secim == "Makas" && secim2 == "Kağıt")
                {
                    label3.Text = "1. Oyuncu Kazandı!";
                }
                else if (secim == "Makas" && secim2 == "Taş")
                {
                    label3.Text = "2. Oyuncu Kazandı!";
                }
                timer1.Stop();
                hazir = false;
                hazir2 = false;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Form2 anamenu= new Form2();
            Hide();
            anamenu.Show();
        }
    }
}
