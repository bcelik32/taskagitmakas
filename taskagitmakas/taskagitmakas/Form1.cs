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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string secim = "yok";
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
            if (secim == "yok")
            {
                label3.Text = "Lütfen Birini Seçiniz.";
            }
            else
            {
                button7.FlatAppearance.BorderColor = Color.Red;
                button7.FlatAppearance.BorderSize = 2;
                string[] secenekler = { "Taş", "Kağıt", "Makas" };

                // Random nesnesi oluşturun
                Random random = new Random();

                // Diziden rasgele bir string seçin
                string rasgeleSecim = secenekler[random.Next(secenekler.Length)];

                if (secim == "Taş" && rasgeleSecim == "Taş")
                {
                    label3.Text = "Berabere!";
                }
                else if (secim == "Taş" && rasgeleSecim == "Kağıt")
                {
                    label3.Text = "Kaybettin";
                }
                else if (secim == "Taş" && rasgeleSecim == "Makas")
                {
                    label3.Text = "Kazandın";
                }
                else if (secim == "Kağıt" && rasgeleSecim == "Kağıt")
                {
                    label3.Text = "Berabere!";
                }
                else if (secim == "Kağıt" && rasgeleSecim == "Makas")
                {
                    label3.Text = "Bilgisayar Kazandı!";
                }
                else if (secim == "Kağıt" && rasgeleSecim == "Taş")
                {
                    label3.Text = "Kazandın!";
                }
                else if (secim == "Makas" && rasgeleSecim == "Makas")
                {
                    label3.Text = "Berabere!!";
                }
                else if (secim == "Makas" && rasgeleSecim == "Kağıt")
                {
                    label3.Text = "Kazandın!";
                }
                else if (secim == "Makas" && rasgeleSecim == "Taş")
                {
                    label3.Text = "Bilgisayar Kazandı!";
                }

                if (rasgeleSecim == "Taş")
                {
                    button5.FlatAppearance.BorderColor = SystemColors.Control;
                    button5.FlatAppearance.BorderSize = 2;
                    button4.FlatAppearance.BorderColor = SystemColors.Control;
                    button4.FlatAppearance.BorderSize = 2;

                    button6.FlatAppearance.BorderColor = Color.Red;
                    button6.FlatAppearance.BorderSize = 2;
                }
                else if (rasgeleSecim == "Kağıt")
                {
                    button5.FlatAppearance.BorderColor = Color.Red;
                    button5.FlatAppearance.BorderSize = 2;


                    button4.FlatAppearance.BorderColor = SystemColors.Control;
                    button4.FlatAppearance.BorderSize = 2;
                    button6.FlatAppearance.BorderColor = SystemColors.Control;
                    button6.FlatAppearance.BorderSize = 2;

                }
                else
                {
                    button4.FlatAppearance.BorderColor = Color.Red;
                    button4.FlatAppearance.BorderSize = 2;

                    button5.FlatAppearance.BorderColor = SystemColors.Control;
                    button5.FlatAppearance.BorderSize = 2;

                    button6.FlatAppearance.BorderColor = SystemColors.Control;
                    button6.FlatAppearance.BorderSize = 2;
                }
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Form2 anamenu = new Form2();
            Hide();
            anamenu.Show();
        }
    }
}
