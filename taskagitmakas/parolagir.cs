using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace taskagitmakas
{
    public partial class parolagir : Form
    {
        public parolagir()
        {
            InitializeComponent();
        }

        private void parolagir_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
        }

        public class Data
        {
            public string odaparola { get; set; }
        }
        IFirebaseConfig config = new FirebaseConfig
        {
            BasePath = "https://csharpfirebase-492fb-default-rtdb.europe-west1.firebasedatabase.app/",
            AuthSecret = "y9KUFGNMTqX76Dky75qIpHmuNtpEAoZQrDk84axj"
        };
        IFirebaseClient client;
        public static string odaparolasi = "";


        private async void sifregonder() 
        {
            client = new FireSharp.FirebaseClient(config);

            // Eğer hata var ise null döner
            if (client == null)
                MessageBox.Show("Bağlantı hatası.");

            // Firebase database'i oluştururken directory oluşturmadığımız için GetAsync içerisini boş bıraktık
            FirebaseResponse response = await client.GetAsync(odalar.secilenoda);

            // Response ile dönen sonuçları Data sınıfına aktardık
            Data result = response.ResultAs<Data>();
            if (textBox1.Text == result.odaparola)
            {
                odaparolasi = result.odaparola;
                player osece = new player();
                Hide();
                osece.Show();
            }
            else
            {
                // textBox1.Text = result.odaparola;

                odalar online = new odalar();
                Hide();
                online.Show();
                MessageBox.Show("Parola Yanlış!", "Taş-Kağıt-Makas Online PC");

            }
        }
        private async void button1_Click(object sender, EventArgs e)
        {

            sifregonder();

        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Parola")
            {
                textBox1.Text = "";
            }

        }
      

       
        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Parola";
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            // Eğer Enter tuşuna basıldıysa
            if (e.KeyCode == Keys.Enter)
            {
                // Enter tuşuna basılınca çalışmasını istediğiniz fonksiyonu çağırın
                sifregonder();
            }
        }
    }
}
