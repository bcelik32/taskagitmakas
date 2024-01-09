using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace taskagitmakas
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }


        IFirebaseConfig config = new FirebaseConfig
        {
            BasePath = "https://csharpfirebase-492fb-default-rtdb.europe-west1.firebasedatabase.app/",
            AuthSecret = "y9KUFGNMTqX76Dky75qIpHmuNtpEAoZQrDk84axj"
        };
        IFirebaseClient client;

        private void Form3_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        public class Data
        {
            public string secim1db { get; set; }
            public string hazir1db { get; set; }
            public string hazir2db { get; set; }
            public string secim2db { get; set; }
            public string biraktif { get; set; }
            public string ikiaktif { get; set; }

        }

        string secim = "yok";
        string secim2 = "yok";
        string hazir = "false";
        string hazir2 = "false";
        int o1sayac = 0;
        int o2sayac = 0;

        private async void button1_Click(object sender, EventArgs e)
        {
            secim = "Taş";
            button1.FlatAppearance.BorderColor = Color.Red;
            button1.FlatAppearance.BorderSize = 2;


            button2.FlatAppearance.BorderColor = SystemColors.Control;
            button2.FlatAppearance.BorderSize = 2;
            button3.FlatAppearance.BorderColor = SystemColors.Control;
            button3.FlatAppearance.BorderSize = 2;

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
                hazir1db = currentData.hazir1db,
                // Diğer alanları mevcut değerlerle aynı bırakmak için aşağıdaki satırları ekleyebilirsiniz
                secim1db = secim,
                biraktif = currentData.biraktif

            };

            // Veriyi Firebase Realtime Database'de güncelle
            FirebaseResponse updateResponse = await client.UpdateAsync(odalar.secilenoda + "/" + "birinci", newData);

        }

        private async void button2_Click(object sender, EventArgs e)
        {
            secim = "Kağıt";
            button2.FlatAppearance.BorderColor = Color.Red;
            button2.FlatAppearance.BorderSize = 2;


            button1.FlatAppearance.BorderColor = SystemColors.Control;
            button1.FlatAppearance.BorderSize = 2;
            button3.FlatAppearance.BorderColor = SystemColors.Control;
            button3.FlatAppearance.BorderSize = 2;

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
                hazir1db = currentData.hazir1db,
                // Diğer alanları mevcut değerlerle aynı bırakmak için aşağıdaki satırları ekleyebilirsiniz
                secim1db = secim,
                biraktif = currentData.biraktif

            };

            // Veriyi Firebase Realtime Database'de güncelle
            FirebaseResponse updateResponse = await client.UpdateAsync(odalar.secilenoda + "/" + "birinci", newData);
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            secim = "Makas";
            button3.FlatAppearance.BorderColor = Color.Red;
            button3.FlatAppearance.BorderSize = 2;

            button1.FlatAppearance.BorderColor = SystemColors.Control;
            button1.FlatAppearance.BorderSize = 2;
            button2.FlatAppearance.BorderColor = SystemColors.Control;
            button2.FlatAppearance.BorderSize = 2;

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
                hazir1db = currentData.hazir1db,
                // Diğer alanları mevcut değerlerle aynı bırakmak için aşağıdaki satırları ekleyebilirsiniz
                secim1db = secim,
                biraktif = currentData.biraktif

            };

            // Veriyi Firebase Realtime Database'de güncelle
            FirebaseResponse updateResponse = await client.UpdateAsync(odalar.secilenoda + "/" + "birinci", newData);
        }

        private async void button7_Click(object sender, EventArgs e)
        {
            if (secim == "yok")
            {
                label3.Text = "Lütfen Birini Seçiniz";
            }
            else
            {
                hazir = "true";
                client = new FireSharp.FirebaseClient(config);
                button7.Image = Properties.Resources.rsz_check; // "secondImage" adındaki görüntüyü projenizdeki Resources klasöründen alıyoruz.
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
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
                    hazir1db = "true",
                    // Diğer alanları mevcut değerlerle aynı bırakmak için aşağıdaki satırları ekleyebilirsiniz
                    secim1db = currentData.secim1db,
                    biraktif = currentData.biraktif

                };

                // Veriyi Firebase Realtime Database'de güncelle
                FirebaseResponse updateResponse = await client.UpdateAsync(odalar.secilenoda + "/" + "birinci", newData);
                timer1.Start();
            }
        }



        private async void timer1_Tick(object sender, EventArgs e)
        {
           // label3.Text = "timer çalışıyor";
            // Butona basıldığında Firebase Client bağlantısı açılır
            // Butona basıldığında Firebase Client bağlantısı açılır
            client = new FireSharp.FirebaseClient(config);

            // Eğer hata var ise null döner
            if (client == null)
                MessageBox.Show("Bağlantı hatası.");

            // Firebase database'i oluştururken directory oluşturmadığımız için GetAsync içerisini boş bıraktık
            string pathToGetBirinciData = odalar.secilenoda + "/" + "birinci";
            FirebaseResponse birinciResponse = await client.GetAsync(pathToGetBirinciData);
            Data result = birinciResponse.ResultAs<Data>();

            string pathToGetIkinciData = odalar.secilenoda + "/" + "ikinci";
            FirebaseResponse ikinciResponse = await client.GetAsync(pathToGetIkinciData);
            Data ikinciresult = ikinciResponse.ResultAs<Data>();
            // Sonuçları ekrandaki textBox'lara yazdırdık

            //label3.Text = result.hazir2db;
           // label7.Text = hazir;



            if (ikinciresult.hazir2db == "true" && hazir == "true")
            {
                // label3.Text = result.secim1db;
                //  label7.Text = result.secim2db;

                if (result.secim1db == "Taş" && ikinciresult.secim2db == "Taş")
                {
                    label3.Text = "Berabere!";
                }
                else if (result.secim1db == "Taş" && ikinciresult.secim2db == "Kağıt")
                {
                    label3.Text = "Rakip Kazandı";
                    o2sayac += 1;
                    label6.Text = o2sayac.ToString();
                }
                else if (result.secim1db == "Taş" && ikinciresult.secim2db == "Makas")
                {
                    label3.Text = "Kazandın!";
                    o1sayac += 1;
                    label4.Text = o1sayac.ToString();
                }
                else if (result.secim1db == "Kağıt" && ikinciresult.secim2db == "Kağıt")
                {
                    label3.Text = "Berabere!";
                }
                else if (result.secim1db == "Kağıt" && ikinciresult.secim2db == "Makas")
                {
                    label3.Text = "Rakip Kazandı";
                    o2sayac += 1;
                    label6.Text = o2sayac.ToString();
                }
                else if (result.secim1db == "Kağıt" && ikinciresult.secim2db == "Taş")
                {
                    label3.Text = "Kazandın!";
                    o1sayac += 1;
                    label4.Text = o1sayac.ToString();
                }
                else if (result.secim1db == "Makas" && ikinciresult.secim2db == "Makas")
                {
                    label3.Text = "Berabere!";
                }
                else if (result.secim1db == "Makas" && ikinciresult.secim2db == "Kağıt")
                {
                    label3.Text = "Kazandın!";
                    o1sayac += 1;
                    label4.Text = o1sayac.ToString();
                }
                else if (result.secim1db == "Makas" && ikinciresult.secim2db == "Taş")
                {
                    label3.Text = "Rakip Kazandı";
                    o2sayac += 1;
                    label6.Text = o2sayac.ToString();
                }
                hazir = "false";
                hazir2 = "false";
                button3.Visible = true;
                button2.Visible = true;
                button1.Visible = true;
                button6.Visible = true;
                button5.Visible = true;
                button4.Visible = true;
                timer1.Stop();
                button7.Image = Properties.Resources.imageedit_2_8445694588; // "secondImage" adındaki görüntüyü projenizdeki Resources klasöründen alıyoruz.
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;

                if (ikinciresult.secim2db == "Taş")
                {
                    button5.FlatAppearance.BorderColor = SystemColors.Control;
                    button5.FlatAppearance.BorderSize = 2;
                    button4.FlatAppearance.BorderColor = SystemColors.Control;
                    button4.FlatAppearance.BorderSize = 2;

                    button6.FlatAppearance.BorderColor = Color.Red;
                    button6.FlatAppearance.BorderSize = 2;
                }
                else if (ikinciresult.secim2db == "Kağıt")
                {
                    button5.FlatAppearance.BorderColor = Color.Red;
                    button5.FlatAppearance.BorderSize = 2;


                    button4.FlatAppearance.BorderColor = SystemColors.Control;
                    button4.FlatAppearance.BorderSize = 2;
                    button6.FlatAppearance.BorderColor = SystemColors.Control;
                    button6.FlatAppearance.BorderSize = 2;
                }
                else if (ikinciresult.secim2db == "Makas")
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

        private void button9_Click(object sender, EventArgs e)
        {
            //timer1.Start();
        }

        private async void button10_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            // Firebase Client bağlantısı aç
            client = new FireSharp.FirebaseClient(config);

            // Eğer hata var ise null döner
            if (client == null)
            {
                MessageBox.Show("Bağlantı hatası.");
                return;
            }

            // "birinci" kümesinden mevcut veriyi çek
            FirebaseResponse getResponseBirinci = await client.GetAsync(odalar.secilenoda + "/" + "birinci");
            Data currentDataBirinci = getResponseBirinci.ResultAs<Data>();

            // "ikinci" kümesinden mevcut veriyi çek
            FirebaseResponse getResponseIkinci = await client.GetAsync(odalar.secilenoda + "/" + "ikinci");
            Data currentDataIkinci = getResponseIkinci.ResultAs<Data>();

            // "birinci" kümesini güncelle ve sadece "hazir1db" ve "secim1db" alanlarını değiştir
            var newDataBirinci = new Data
            {
                hazir1db = "false",
                secim1db = "yok",
                biraktif = "off"
                
            };
            FirebaseResponse updateResponseBirinci = await client.UpdateAsync(odalar.secilenoda + "/" + "birinci", newDataBirinci);

            // "ikinci" kümesini güncelle ve sadece "hazir2db" ve "secim2db" alanlarını değiştir
            var newDataIkinci = new Data
            {
                hazir2db = "false",
                secim2db = "yok",
            ikiaktif = "off"
            };
            FirebaseResponse updateResponseIkinci = await client.UpdateAsync(odalar.secilenoda + "/" + "ikinci", newDataIkinci);
            if (odalar.secilenoda != "Bekir ÇELİK - jr_cyberbot")
            {
                DialogResult result = MessageBox.Show("Odayı Silmek İstermisiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {

                    client = new FireSharp.FirebaseClient(config);

                    if (client == null)
                    {
                        MessageBox.Show("Bağlantı hatası.");
                        return;
                    }

                    // Silmek istediğiniz koleksiyonun tam yolu
                    string silinecekDugumYolu = odalar.secilenoda;

                    // Firebase Realtime Database'den belirtilen düğümü sil
                    FirebaseResponse deleteResponse = await client.DeleteAsync(silinecekDugumYolu);
                    Form2 anamenu = new Form2();
                    Hide();
                    anamenu.Show();
                }
                else
                {

                    Form2 anamenu = new Form2();
                    Hide();
                    anamenu.Show();
                }
            }
            else
            {
                Form2 anamenu = new Form2();
                Hide();
                anamenu.Show();
            }
        }
    }
}
