using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace taskagitmakas
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 tekoyuncu=new Form1();
            Hide();
            tekoyuncu.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            odalar online= new odalar();
            Hide();
            online.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }
        private bool mouseDown;
        private Point lastLocation;
        private void player1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseDown = true;
                lastLocation = e.Location;
            }
        }

        private void player1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                Location = new Point(
                    (Location.X - lastLocation.X) + e.X,
                    (Location.Y - lastLocation.Y) + e.Y);

                Update();
            }
        }

        private void player1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseDown = false;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/bcelik32/");
        }

        private void label2_MouseEnter(object sender, EventArgs e)
        {
            label2.ForeColor = Color.Red;
        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            label2.ForeColor = Color.Black;

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
