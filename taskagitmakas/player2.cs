using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace taskagitmakas
{
    public partial class player2 : Form
    {
        public player2()
        {
            InitializeComponent();
        }

        private void player2_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
        IFirebaseConfig config = new FirebaseConfig
        {
            BasePath = "https://csharpfirebase-492fb-default-rtdb.europe-west1.firebasedatabase.app/",
            AuthSecret = "y9KUFGNMTqX76Dky75qIpHmuNtpEAoZQrDk84axj"
        };
        IFirebaseClient client;



        public class Data
        {
            public string secim1db { get; set; }
            public string hazir1db { get; set; }
            public string hazir2db { get; set; }
            public string secim2db { get; set; }
            public string biraktif{ get; set; }
            public string ikiaktif{ get; set; }


        }

        string secim = "yok";
        string secim2 = "yok";
        string hazir = "false";
        string hazir2 = "false";
        int o1sayac = 0;
        int o2sayac = 0;





        private async void button6_Click(object sender, EventArgs e)
        {
            secim2 = "Taş";
            button5.FlatAppearance.BorderColor = SystemColors.Control;
            button5.FlatAppearance.BorderSize = 2;
            button4.FlatAppearance.BorderColor = SystemColors.Control;
            button4.FlatAppearance.BorderSize = 2;

            button6.FlatAppearance.BorderColor = Color.Red;
            button6.FlatAppearance.BorderSize = 2;
            client = new FireSharp.FirebaseClient(config);

            // Eğer hata var ise null döner
            if (client == null)
            {
                MessageBox.Show("Bağlantı hatası.");
                return;
            }

            // Belirtilen yoldaki mevcut veriyi çek
            FirebaseResponse getResponse = await client.GetAsync(odalar.secilenoda+"/"+"ikinci");
            Data currentData = getResponse.ResultAs<Data>();

            // Güncellenecek veriyi hazırla ve sadece "hazir2db" alanını güncelle
            var newData = new Data
            {
                hazir2db = currentData.hazir2db,
                    ikiaktif = currentData.ikiaktif,

                // Diğer alanları mevcut değerlerle aynı bırakmak için aşağıdaki satırları ekleyebilirsiniz
                secim2db = secim2
            };

            // Veriyi Firebase Realtime Database'de güncelle
            FirebaseResponse updateResponse = await client.UpdateAsync(odalar.secilenoda + "/" + "ikinci", newData);
        }

        private async void button5_Click(object sender, EventArgs e)
        {
            secim2 = "Kağıt";
            button5.FlatAppearance.BorderColor = Color.Red;
            button5.FlatAppearance.BorderSize = 2;


            button4.FlatAppearance.BorderColor = SystemColors.Control;
            button4.FlatAppearance.BorderSize = 2;
            button6.FlatAppearance.BorderColor = SystemColors.Control;
            button6.FlatAppearance.BorderSize = 2;
            client = new FireSharp.FirebaseClient(config);

            // Eğer hata var ise null döner
            if (client == null)
            {
                MessageBox.Show("Bağlantı hatası.");
                return;
            }

            // Belirtilen yoldaki mevcut veriyi çek
            FirebaseResponse getResponse = await client.GetAsync(odalar.secilenoda + "/" + "ikinci");
            Data currentData = getResponse.ResultAs<Data>();

            // Güncellenecek veriyi hazırla ve sadece "hazir2db" alanını güncelle
            var newData = new Data
            {
                hazir2db = currentData.hazir2db,
                // Diğer alanları mevcut değerlerle aynı bırakmak için aşağıdaki satırları ekleyebilirsiniz
                    ikiaktif = currentData.ikiaktif,
                secim2db = secim2

            };

            // Veriyi Firebase Realtime Database'de güncelle
            FirebaseResponse updateResponse = await client.UpdateAsync(odalar.secilenoda + "/" + "ikinci", newData);

        }

        private async void button4_Click(object sender, EventArgs e)
        {
            secim2 = "Makas";
            button4.FlatAppearance.BorderColor = Color.Red;
            button4.FlatAppearance.BorderSize = 2;

            button5.FlatAppearance.BorderColor = SystemColors.Control;
            button5.FlatAppearance.BorderSize = 2;

            button6.FlatAppearance.BorderColor = SystemColors.Control;
            button6.FlatAppearance.BorderSize = 2;

            client = new FireSharp.FirebaseClient(config);

            // Eğer hata var ise null döner
            if (client == null)
            {
                MessageBox.Show("Bağlantı hatası.");
                return;
            }

            // Belirtilen yoldaki mevcut veriyi çek
            FirebaseResponse getResponse = await client.GetAsync(odalar.secilenoda + "/" + "ikinci");
            Data currentData = getResponse.ResultAs<Data>();

            // Güncellenecek veriyi hazırla ve sadece "hazir2db" alanını güncelle
            var newData = new Data
            {
                hazir2db = currentData.hazir2db,
                ikiaktif = currentData.ikiaktif,

                // Diğer alanları mevcut değerlerle aynı bırakmak için aşağıdaki satırları ekleyebilirsiniz
                secim2db = secim2
            };

            // Veriyi Firebase Realtime Database'de güncelle
            FirebaseResponse updateResponse = await client.UpdateAsync(odalar.secilenoda + "/" + "ikinci", newData);

        }

        private async void button8_Click(object sender, EventArgs e)
        {

            if (secim2 == "yok")
            {
                label3.Text = "Lütfen Birini Seçiniz";
            }
            else
            {
                label3.Text = "";

                hazir = "true";
                button8.Image = Properties.Resources.rsz_check; // "secondImage" adındaki görüntüyü projenizdeki Resources klasöründen alıyoruz.
                button6.Enabled = false;
                button5.Enabled = false;
                button4.Enabled = false;
                // Firebase Client bağlantısı aç
                client = new FireSharp.FirebaseClient(config);

                // Eğer hata var ise null döner
                if (client == null)
                {
                    MessageBox.Show("Bağlantı hatası.");
                    return;
                }

                // Belirtilen yoldaki mevcut veriyi çek
                FirebaseResponse getResponse = await client.GetAsync(odalar.secilenoda + "/" + "ikinci");
                Data currentData = getResponse.ResultAs<Data>();

                // Güncellenecek veriyi hazırla ve sadece "hazir2db" alanını güncelle
                var newData = new Data
                {
                    hazir2db = "true",
                    // Diğer alanları mevcut değerlerle aynı bırakmak için aşağıdaki satırları ekleyebilirsiniz
                    secim2db = currentData.secim2db,
                    ikiaktif = currentData.ikiaktif
                };

                // Veriyi Firebase Realtime Database'de güncelle
                FirebaseResponse updateResponse = await client.UpdateAsync(odalar.secilenoda + "/" + "ikinci", newData);
                timer1.Start();

                // Güncelleme işlemi başarılıysa ve timer başlatılmamışsa timer'ı başlat
            }
        }

        string secimdb = "boş";
        string secim2db = "boş";

        private async void timer1_Tick(object sender, EventArgs e)
        {
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
           
            //label3.Text = result.secim1db;
            if (result.hazir1db == "true" && hazir == "true")
            {
                // label3.Text = result.secim1db;
                //  label7.Text = result.secim2db;

                if (result.secim1db == "Taş" && ikinciresult.secim2db == "Taş")
                {
                    label3.Text = "Berabere!";
                }
                else if (result.secim1db == "Taş" && ikinciresult.secim2db == "Kağıt")
                {
                    label3.Text = "Kazandın!";
                    o2sayac += 1;
                    label6.Text = o2sayac.ToString();
                }
                else if (result.secim1db == "Taş" && ikinciresult.secim2db == "Makas")
                {
                    label3.Text = "Rakip Kazandı!";
                    o1sayac += 1;
                    label4.Text = o1sayac.ToString();
                }
                else if (result.secim1db == "Kağıt" && ikinciresult.secim2db == "Kağıt")
                {
                    label3.Text = "Berabere!";
                }
                else if (result.secim1db == "Kağıt" && ikinciresult.secim2db == "Makas")
                {
                    label3.Text = "Kazandın!";
                    o2sayac += 1;
                    label6.Text = o2sayac.ToString();
                }
                else if (result.secim1db == "Kağıt" && ikinciresult.secim2db == "Taş")
                {
                    label3.Text = "Rakip Kazandı!";
                    o1sayac += 1;
                    label4.Text = o1sayac.ToString();
                }
                else if (result.secim1db == "Makas" && ikinciresult.secim2db == "Makas")
                {
                    label3.Text = "Berabere!";
                }
                else if (result.secim1db == "Makas" && ikinciresult.secim2db == "Kağıt")
                {
                    label3.Text = "Rakip Kazandı!";
                    o1sayac += 1;
                    label4.Text = o1sayac.ToString();
                }
                else if (result.secim1db == "Makas" && ikinciresult.secim2db == "Taş")
                {
                    label3.Text = "Kazandın!";
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
                button8.Image = Properties.Resources.imageedit_2_8445694588; // "secondImage" adındaki görüntüyü projenizdeki Resources klasöründen alıyoruz.
                button6.Enabled = true;
                button5.Enabled = true;
                button4.Enabled = true;

                timer1.Stop();
                if (result.secim1db == "Taş")
                {
                    button1.FlatAppearance.BorderColor = Color.Red;
                    button1.FlatAppearance.BorderSize = 2;


                    button2.FlatAppearance.BorderColor = SystemColors.Control;
                    button2.FlatAppearance.BorderSize = 2;
                    button3.FlatAppearance.BorderColor = SystemColors.Control;
                    button3.FlatAppearance.BorderSize = 2;
                }
                else if (result.secim1db == "Kağıt")
                {
                    button2.FlatAppearance.BorderColor = Color.Red;
                    button2.FlatAppearance.BorderSize = 2;


                    button1.FlatAppearance.BorderColor = SystemColors.Control;
                    button1.FlatAppearance.BorderSize = 2;
                    button3.FlatAppearance.BorderColor = SystemColors.Control;
                    button3.FlatAppearance.BorderSize = 2;
                }
                else if (result.secim1db == "Makas")
                {
                    button3.FlatAppearance.BorderColor = Color.Red;
                    button3.FlatAppearance.BorderSize = 2;

                    button1.FlatAppearance.BorderColor = SystemColors.Control;
                    button1.FlatAppearance.BorderSize = 2;
                    button2.FlatAppearance.BorderColor = SystemColors.Control;
                    button2.FlatAppearance.BorderSize = 2;
                }
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
                    secim1db = "yok"
                };
                FirebaseResponse updateResponseBirinci = await client.UpdateAsync(odalar.secilenoda + "/" + "birinci", newDataBirinci);

                // "ikinci" kümesini güncelle ve sadece "hazir2db" ve "secim2db" alanlarını değiştir
                var newDataIkinci = new Data
                {
                    hazir2db = "false",
                    secim2db = "yok"
                };
                FirebaseResponse updateResponseIkinci = await client.UpdateAsync(odalar.secilenoda + "/" + "ikinci", newDataIkinci);
            }
        }



        private async void button10_Click(object sender, EventArgs e)
        {
            timer1.Stop();
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
                biraktif="off",
                
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

        private void button7_Click(object sender, EventArgs e)
        {
        }
    }
}
