using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using System;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Header;

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
            public string chat1{ get; set; }
            public string chat2{ get; set; }
            public string sistemmesaj{ get; set; }
            public string odaid{ get; set; }
            public string odaparola{ get; set; }


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
            button5.FlatAppearance.BorderSize = 0;
            button3.FlatAppearance.BorderSize = 0;


            button6.FlatAppearance.BorderColor = Color.Red;
            button6.FlatAppearance.BorderSize = 2;
            client = new FireSharp.FirebaseClient(config);

            // Eğer hata var ise null döner
            if (client == null)
            {
                MessageBox.Show("Bağlantı hatası.","Taş-Kağıt-Makas Online PC");
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
                chat2 = currentData.chat2,

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

            button4.FlatAppearance.BorderSize = 0;
            button6.FlatAppearance.BorderSize = 0;

            client = new FireSharp.FirebaseClient(config);

            // Eğer hata var ise null döner
            if (client == null)
            {
                MessageBox.Show("Bağlantı hatası.","Taş-Kağıt-Makas Online PC");
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
                chat2 = currentData.chat2,
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
            
            button5.FlatAppearance.BorderSize = 0;
            button6.FlatAppearance.BorderSize = 0;

            client = new FireSharp.FirebaseClient(config);

            // Eğer hata var ise null döner
            if (client == null)
            {
                MessageBox.Show("Bağlantı hatası.","Taş-Kağıt-Makas Online PC");
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
                chat2 = currentData.chat2,

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
                button1.FlatAppearance.BorderSize = 0;
                button2.FlatAppearance.BorderSize = 0;
                button3.FlatAppearance.BorderSize = 0;
                button8.Image = Properties.Resources.rsz_check; // "secondImage" adındaki görüntüyü projenizdeki Resources klasöründen alıyoruz.
                button6.Enabled = false;
                button5.Enabled = false;
                button4.Enabled = false;
                // Firebase Client bağlantısı aç
                client = new FireSharp.FirebaseClient(config);

                // Eğer hata var ise null döner
                if (client == null)
                {
                    MessageBox.Show("Bağlantı hatası.","Taş-Kağıt-Makas Online PC");
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
                    ikiaktif = currentData.ikiaktif,
                    chat2 = currentData.chat2
                };

                // Veriyi Firebase Realtime Database'de güncelle
                FirebaseResponse updateResponse = await client.UpdateAsync(odalar.secilenoda + "/" + "ikinci", newData);
                timer1.Start();

                // Güncelleme işlemi başarılıysa ve timer başlatılmamışsa timer'ı başlat
            }
        }

        string secimdb = "boş";
        string secim2db = "boş";
        string karsidangelen = "";
        int itemsay = 0;
        bool rakipflag = true;
        bool skorflag = false;
        string sistemgelen = "";
        int o2sayaceski= 0;
        bool birinciflag=false;
        string baslangiczaman = "";
        private async void timer1_Tick(object sender, EventArgs e)
        {
            // Butona basıldığında Firebase Client bağlantısı açılır
            // Butona basıldığında Firebase Client bağlantısı açılır
            client = new FireSharp.FirebaseClient(config);

            // Eğer hata var ise null döner
            if (client == null)
            {
                MessageBox.Show("Bağlantı hatası.","Taş-Kağıt-Makas Online PC");
            }

            FirebaseResponse response = await client.GetAsync($"{odalar.secilenoda}");
            // Eğer düğüm varsa true, yoksa false değeri ile odavarmı değişkenini güncelle
            bool odavarmi = response.Body != "null";
                string pathToGetBirinciData = odalar.secilenoda + "/" + "birinci";
                FirebaseResponse birinciResponse = await client.GetAsync(pathToGetBirinciData);
                Data result = birinciResponse.ResultAs<Data>();
            if (odavarmi)
            {
                int itemCount = listBox1.Items.Count;
                if (itemCount != itemsay)
                {
                    itemsay = itemCount;
                    listBox1.TopIndex = listBox1.Items.Count - 1;

                }



                if (o2sayac >= 3 & skorflag == false & o2sayaceski==0)
                {
                    //listBox1.Items.Add("Sistem: 1. Oyuncu Üç'ledi.");

                    client = new FireSharp.FirebaseClient(config);

                    // Eğer hata var ise null döner
                    if (client == null)
                    {
                        MessageBox.Show("Bağlantı hatası.","Taş-Kağıt-Makas Online PC");
                        return;
                    }

                    // Belirtilen yoldaki mevcut veriyi çek
                    FirebaseResponse getResponse = await client.GetAsync(odalar.secilenoda);
                    Data currentData = getResponse.ResultAs<Data>();

                    // Güncellenecek veriyi hazırla ve sadece "hazir2db" alanını güncelle
                    var newData = new Data
                    {
                        sistemmesaj = "Sistem: 2. Oyuncu Üç'ledi",
                        odaparola = currentData.odaparola,
                        odaid = currentData.odaid
                    };

                    // Veriyi Firebase Realtime Database'de güncelle
                    FirebaseResponse updateResponse = await client.UpdateAsync(odalar.secilenoda, newData);
                    skorflag = true;
                    o2sayaceski = 3;
                }
                else if (o2sayac >= 4 & skorflag == true & o2sayaceski == 3)
                {
                    // listBox1.Items.Add(@"Sistem: 1. Oyuncu Aman Vermiyor.");
                    // listBox1.Items.Add(@"Sistem: Aman Vermiyor.");
                    //listBox1.Items.Add("Sistem: 1. Oyuncu Üç'ledi.");
                    client = new FireSharp.FirebaseClient(config);

                    // Eğer hata var ise null döner
                    if (client == null)
                    {
                        MessageBox.Show("Bağlantı hatası.","Taş-Kağıt-Makas Online PC");
                        return;
                    }

                    // Belirtilen yoldaki mevcut veriyi çek
                    FirebaseResponse getResponse = await client.GetAsync(odalar.secilenoda);
                    Data currentData = getResponse.ResultAs<Data>();

                    // Güncellenecek veriyi hazırla ve sadece "hazir2db" alanını güncelle
                    var newData = new Data
                    {
                        sistemmesaj = "Sistem: 2. Oyuncu Aman Vermiyor",
                        odaparola = currentData.odaparola,
                        odaid = currentData.odaid
                    };

                    // Veriyi Firebase Realtime Database'de güncelle
                    FirebaseResponse updateResponse = await client.UpdateAsync(odalar.secilenoda, newData);
                    skorflag = false;
                    o2sayaceski = 4;
                }
                else if (o2sayac >= 5 & skorflag == false & o2sayaceski == 5)
                {
                    //listBox1.Items.Add("Sistem: 1. Oyuncu Destan Yazdı.");
                    //  listBox1.Items.Add("Sistem: Destan Yazdı.");
                    client = new FireSharp.FirebaseClient(config);

                    // Eğer hata var ise null döner
                    if (client == null)
                    {
                        MessageBox.Show("Bağlantı hatası.","Taş-Kağıt-Makas Online PC");
                        return;
                    }

                    // Belirtilen yoldaki mevcut veriyi çek
                    FirebaseResponse getResponse = await client.GetAsync(odalar.secilenoda);
                    Data currentData = getResponse.ResultAs<Data>();

                    // Güncellenecek veriyi hazırla ve sadece "hazir2db" alanını güncelle
                    var newData = new Data
                    {
                        sistemmesaj = "Sistem: 2. Oyuncu Destan Yazdı!",
                        odaparola = currentData.odaparola,
                        odaid = currentData.odaid
                    };

                    // Veriyi Firebase Realtime Database'de güncelle
                    FirebaseResponse updateResponse = await client.UpdateAsync(odalar.secilenoda, newData);
                    skorflag = true;
                    o2sayaceski = 6;
                }

                if (result.biraktif== "on" & rakipflag)
                {
                    listBox1.Items.Add("Sistem: Odaya Biri Katıldı.");
                    listBox1.Items.Add(DateTime.Now.ToString("HH:mm:ss") + " - Sistem: İyi Oyunlar.");
                    rakipflag = false;
                    birinciflag = true;
                    baslangiczaman = DateTime.Now.ToString("HH:mm:ss");
                    timer3.Start();

                }
                else if (result.biraktif == "off" & rakipflag == false& birinciflag)
                {
                    listBox1.Items.Add("Sistem: Rakibin Odadan Çıktı.");
                    o2sayac = 0;
                    o1sayac = 0;
                    rakipflag = true;
                    birinciflag = false;
                    timer3.Stop();
                    listBox1.Items.Add($"Sistem: {saat}:{dakika}:{saniye} Süre Oynadınız.");
                    listBox1.Items.Add($"Sistem: {baslangiczaman} - {DateTime.Now.ToString("HH:mm:ss")}");
                    saat = 0;dakika = 0; saniye = 0;
                    label8.Text = "00:00:00";
                }

                client = new FireSharp.FirebaseClient(config);

                // Eğer hata var ise null döner
                if (client == null)
                    MessageBox.Show("Bağlantı hatası.","Taş-Kağıt-Makas Online PC");

                // Firebase database'i oluştururken directory oluşturmadığımız için GetAsync içerisini boş bıraktık
                FirebaseResponse response3 = await client.GetAsync($"{odalar.secilenoda}");

                // Response ile dönen sonuçları Data sınıfına aktardık
                Data result3 = response.ResultAs<Data>();
                if (sistemgelen != result3.sistemmesaj)
                {
                    //label7.Text = label7.Text + "\n" + ikinciresult.chat2;
                    // listBox1.Items.Add(ikinciresult.chat2);

                    sistemgelen = result3.sistemmesaj;
                    string sampleText = sistemgelen;

                    // Metni 32 karakterlik parçalara böler ve her bir parçayı ListBox'a ekler
                    for (int i = 0; i < sampleText.Length; i += 25)
                    {
                        int remainingChars = Math.Min(25, sampleText.Length - i);
                        listBox1.Items.Add(sampleText.Substring(i, remainingChars));
                    }
                }

                // Firebase database'i oluştururken directory oluşturmadığımız için GetAsync içerisini boş bıraktık
                if (karsidangelen != result.chat1)
                {
                    //label7.Text = label7.Text + "\n" + ikinciresult.chat2;
                    // listBox1.Items.Add(ikinciresult.chat2);

                    karsidangelen = result.chat1;
                    string sampleText = karsidangelen;

                    // Metni 32 karakterlik parçalara böler ve her bir parçayı ListBox'a ekler
                    for (int i = 0; i < sampleText.Length; i += 25)
                    {
                        int remainingChars = Math.Min(25, sampleText.Length - i);
                        listBox1.Items.Add(sampleText.Substring(i, remainingChars));
                    }
                }

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
                        o2sayaceski = 0;
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
                        o2sayaceski = 0;
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
                        o2sayaceski = 0;
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

                    //timer1.Stop();
                    if (result.secim1db == "Taş")
                    {
                        button1.FlatAppearance.BorderColor = Color.Red;
                        button1.FlatAppearance.BorderSize = 2;

                        button2.FlatAppearance.BorderSize = 0;
                        button3.FlatAppearance.BorderSize = 0;

                    }
                    else if (result.secim1db == "Kağıt")
                    {
                        button2.FlatAppearance.BorderColor = Color.Red;
                        button2.FlatAppearance.BorderSize = 2;


                        button1.FlatAppearance.BorderSize = 0;
                        button3.FlatAppearance.BorderSize = 0;
                    }
                    else if (result.secim1db == "Makas")
                    {
                        button3.FlatAppearance.BorderColor = Color.Red;
                        button3.FlatAppearance.BorderSize = 2;


                        button2.FlatAppearance.BorderSize = 0;
                        button1.FlatAppearance.BorderSize = 0;
                    }
                    client = new FireSharp.FirebaseClient(config);

                    button4.FlatAppearance.BorderSize = 0;
                    button5.FlatAppearance.BorderSize = 0;
                    button6.FlatAppearance.BorderSize = 0;
                    button8.Enabled = false;
                    timer2.Start();
                    // Eğer hata var ise null döner
                    if (client == null)
                    {
                        MessageBox.Show("Bağlantı hatası.","Taş-Kağıt-Makas Online PC");
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
                        biraktif=currentDataBirinci.biraktif,
                        chat1=currentDataBirinci.chat1
                        
                    };
                    FirebaseResponse updateResponseBirinci = await client.UpdateAsync(odalar.secilenoda + "/" + "birinci", newDataBirinci);

                    // "ikinci" kümesini güncelle ve sadece "hazir2db" ve "secim2db" alanlarını değiştir
                    var newDataIkinci = new Data
                    {
                        hazir2db = "false",
                        secim2db = "yok",
                        ikiaktif = currentDataIkinci.ikiaktif,
                        chat2 = currentDataIkinci.chat2
                    };
                    FirebaseResponse updateResponseIkinci = await client.UpdateAsync(odalar.secilenoda + "/" + "ikinci", newDataIkinci);
                }
            }
            else
            {
                timer1.Stop();
                Form2 anamenu = new Form2();
                Hide();
                anamenu.Show();
                MessageBox.Show("Odanız Kapatıldı.", "Taş-Kağıt-Makas Online PC");
            }
        }



        private async void button10_Click(object sender, EventArgs e)
        {
          
            if (odalar.secilenoda != "Bekir ÇELİK - jr_cyberbot")
            {
                DialogResult result = MessageBox.Show("Odayı Silmek İstermisiniz?", "Taş-Kağıt-Makas Online PC", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    timer1.Stop();
                    timer2.Stop();
                    client = new FireSharp.FirebaseClient(config);

                    if (client == null)
                    {
                        MessageBox.Show("Bağlantı hatası.","Taş-Kağıt-Makas Online PC");
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
                else if(result==DialogResult.No)
                {

                    timer1.Stop();
                    client = new FireSharp.FirebaseClient(config);

                    // Eğer hata var ise null döner
                    if (client == null)
                    {
                        MessageBox.Show("Bağlantı hatası.","Taş-Kağıt-Makas Online PC");
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
                        biraktif = currentDataBirinci.biraktif,
                        chat1 = currentDataBirinci.chat1

                    };
                    FirebaseResponse updateResponseBirinci = await client.UpdateAsync(odalar.secilenoda + "/" + "birinci", newDataBirinci);

                    // "ikinci" kümesini güncelle ve sadece "hazir2db" ve "secim2db" alanlarını değiştir
                    var newDataIkinci = new Data
                    {
                        hazir2db = "false",
                        secim2db = "yok",
                        ikiaktif = "off",
                        chat2 = "",
                    };
                    FirebaseResponse updateResponseIkinci = await client.UpdateAsync(odalar.secilenoda + "/" + "ikinci", newDataIkinci);


                    // Belirtilen yoldaki mevcut veriyi çek
                    FirebaseResponse getResponse = await client.GetAsync(odalar.secilenoda);
                    Data currentData = getResponse.ResultAs<Data>();

                    // Güncellenecek veriyi hazırla ve sadece "hazir2db" alanını güncelle
                    var newData = new Data
                    {
                        sistemmesaj = "",
                        odaparola = currentData.odaparola,
                        odaid = currentData.odaid
                    };

                    // Veriyi Firebase Realtime Database'de güncelle
                    FirebaseResponse updateResponse = await client.UpdateAsync(odalar.secilenoda, newData);

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

        
        string mesajgiden = "";
        string itemtext = "";
       
        private bool mouseDown;
        private Point lastLocation;
        private void player2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseDown = true;
                lastLocation = e.Location;
            }
        }

        private void player2_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                Location = new Point(
                    (Location.X - lastLocation.X) + e.X,
                    (Location.Y - lastLocation.Y) + e.Y);

                Update();
            }
        }

        private void player2_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseDown = false;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_Enter(object sender, EventArgs e)
        {

            listBox1.Enabled = true;

            if (textBox1.Text == "Bir Mesaj Yaz.")
            {
                textBox1.Text = "";
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            listBox1.Enabled = false;
            if (textBox1.Text == "")
            {
                textBox1.Text = "Bir Mesaj Yaz.";
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
        public static bool odabilgisiflag2 = false;
        private void button11_Click(object sender, EventArgs e)
        {
            if (!odabilgisiflag2)
            {
                odabilgisiflag2 = true;
                odabilgisi bilgi = new odabilgisi();
                bilgi.Show();
            }
        }
        private async void mesajgonder()
        {
            mesajgiden = "Sen: " + textBox1.Text;
            client = new FireSharp.FirebaseClient(config);

            // Eğer hata var ise null döner
            if (client == null)
            {
                MessageBox.Show("Bağlantı hatası.","Taş-Kağıt-Makas Online PC");
                return;
            }
            // Belirtilen yoldaki mevcut veriyi çek
            FirebaseResponse getResponse = await client.GetAsync(odalar.secilenoda + "/" + "ikinci");
            Data currentData = getResponse.ResultAs<Data>();
            DateTime simdikiZaman = DateTime.Now;
            int saat = simdikiZaman.Hour;
            int dakika = simdikiZaman.Minute;
            int saniye = simdikiZaman.Second;
            string simdikizamanedit = saat.ToString() + ":" + dakika.ToString() + ":" + saniye.ToString();

            // Güncellenecek veriyi hazırla ve sadece "hazir2db" alanını güncelle
            var newData = new Data
            {
                hazir2db = currentData.hazir2db,
                // Diğer alanları mevcut değerlerle aynı bırakmak için aşağıdaki satırları ekleyebilirsiniz
                secim2db = currentData.secim2db,
                ikiaktif = currentData.ikiaktif,
                chat2 = simdikizamanedit+" - Rakip: " + textBox1.Text

            };
            foreach (var item in listBox1.Items)
            {
                itemtext = item.ToString();
                // Burada itemText değişkeni, ListBox'taki her bir öğenin metnini içerecektir.
                //Console.WriteLine(itemText); // veya başka bir işlem yapabilirsiniz
            }
            //listBox1.Items.Add(mesajgiden);
            string sampleText = simdikizamanedit + " - " + "Sen: " + textBox1.Text;
            // Metni 32 karakterlik parçalara böler ve her bir parçayı ListBox'a ekler
            for (int i = 0; i < sampleText.Length; i += 25)
            {
                int remainingChars = Math.Min(25, sampleText.Length - i);
                listBox1.Items.Add(sampleText.Substring(i, remainingChars));
            }
            textBox1.Text = "";
            // Veriyi Firebase Realtime Database'de güncelle
            FirebaseResponse updateResponse = await client.UpdateAsync(odalar.secilenoda + "/" + "ikinci", newData);
        }
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            // Eğer Enter tuşuna basıldıysa
            if (e.KeyCode == Keys.Enter)
            {
                // Enter tuşuna basılınca çalışmasını istediğiniz fonksiyonu çağırın
                mesajgonder();
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {

            button2.FlatAppearance.BorderSize = 0;
            button3.FlatAppearance.BorderSize = 0;
            button1.FlatAppearance.BorderSize = 0;
            button8.Enabled = true;
            timer2.Stop();
                 
        }
        private int saat = 0, dakika = 0, saniye = 0;

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            saniye++;

            // Saniye 60'a ulaştığında dakikayı artır ve saniyeyi sıfırla
            if (saniye == 60)
            {
                dakika++;
                saniye = 0;
            }

            // Dakika 60'a ulaştığında saati artır ve dakikayı sıfırla
            if (dakika == 60)
            {
                saat++;
                dakika = 0;
            }

            // Label üzerinde saat, dakika, saniye göster
            label8.Text = $"{saat:D2}:{dakika:D2}:{saniye:D2}";
        }
    }
}
