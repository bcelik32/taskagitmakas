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
namespace taskagitmakas
{
    public partial class player : Form
    {
        public player()
        {
            InitializeComponent();
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            client = new FireSharp.FirebaseClient(config);

            // Eğer hata var ise null döner
            if (client == null)
            {
                MessageBox.Show("Bağlantı hatası.");
                return;
            }

            // Belirtilen yoldaki mevcut veriyi çek
            FirebaseResponse getResponse = await client.GetAsync(odalar.secilenoda + "/" + "birinci");
            Data currentData = getResponse.ResultAs<Data>();

            // Güncellenecek veriyi hazırla ve sadece "hazir2db" alanını güncelle
            var newData = new Data
            {
                biraktif = "on",
                hazir1db = currentData.hazir1db,
                // Diğer alanları mevcut değerlerle aynı bırakmak için aşağıdaki satırları ekleyebilirsiniz
                secim1db = currentData.secim1db
                
            };

            // Veriyi Firebase Realtime Database'de güncelle
            FirebaseResponse updateResponse = await client.UpdateAsync(odalar.secilenoda + "/" + "birinci", newData);
            timer1.Stop();
            Form3 ikioyunculu = new Form3();
            Hide();
            ikioyunculu.Show();
        }

        IFirebaseConfig config = new FirebaseConfig
        {
            BasePath = "https://csharpfirebase-492fb-default-rtdb.europe-west1.firebasedatabase.app/",
            AuthSecret = "y9KUFGNMTqX76Dky75qIpHmuNtpEAoZQrDk84axj"
        };
        IFirebaseClient client;

        public class Data
        {
            public string biraktif { get; set; }
            public string ikiaktif { get; set; }
            public string hazir1db { get; set; }
            public string hazir2db { get; set; }
            public string secim1db { get; set; }
            public string secim2db { get; set; }
            

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            client = new FireSharp.FirebaseClient(config);

            // Eğer hata var ise null döner
            if (client == null)
            {
                MessageBox.Show("Bağlantı hatası.");
                return;
            }

            // Belirtilen yoldaki mevcut veriyi çek
            FirebaseResponse getResponse = await client.GetAsync(odalar.secilenoda + "/" +"ikinci");
            Data currentData = getResponse.ResultAs<Data>();

            // Güncellenecek veriyi hazırla ve sadece "hazir2db" alanını güncelle
            var newData = new Data
            {
                ikiaktif = "on",
                hazir2db = currentData.hazir2db,
                // Diğer alanları mevcut değerlerle aynı bırakmak için aşağıdaki satırları ekleyebilirsiniz
                secim2db = currentData.secim2db

            };

            // Veriyi Firebase Realtime Database'de güncelle
            FirebaseResponse updateResponse = await client.UpdateAsync(odalar.secilenoda + "/" +"ikinci", newData);

            timer1.Stop();
            player2 ikioyunculu = new player2();
            Hide();
            ikioyunculu.Show();
        }

        private async void timer1_Tick(object sender, EventArgs e)
        {
            client = new FireSharp.FirebaseClient(config);

            // Eğer hata var ise null döner
            if (client == null)
                MessageBox.Show("Bağlantı hatası.");

            // Firebase database'i oluştururken directory oluşturmadığımız için GetAsync içerisini boş bıraktık
            string pathToGetBirinciData = odalar.secilenoda + "/" +"birinci";
            FirebaseResponse birinciResponse = await client.GetAsync(pathToGetBirinciData);
            Data result = birinciResponse.ResultAs<Data>();

            string pathToGetIkinciData = odalar.secilenoda + "/" + "ikinci";
            FirebaseResponse ikinciResponse = await client.GetAsync(pathToGetIkinciData);
            Data ikinciresult = ikinciResponse.ResultAs<Data>();
            // Sonuçları ekrandaki textBox'lara yazdırdık
            //button1.Text = result.ikiaktif;
            if (ikinciresult.ikiaktif == "on")
            {
                button1.Enabled = false;
            }
            else
            {
                button1.Enabled = true;
            }


            if (result.biraktif == "on")
            {
                button3.Enabled = false;
            }
            else
            {
                button3.Enabled = true;
            }
        }

        private void player_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}
