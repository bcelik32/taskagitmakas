﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
namespace taskagitmakas
{
    public partial class odalar : Form
    {
        public odalar()
        {
            InitializeComponent();
        }

        IFirebaseConfig config = new FirebaseConfig
        {
            BasePath = "https://csharpfirebase-492fb-default-rtdb.europe-west1.firebasedatabase.app/",
            AuthSecret = "y9KUFGNMTqX76Dky75qIpHmuNtpEAoZQrDk84axj"
        };
        IFirebaseClient client;
        public static string idstr = "";
        public static string bilgiodaidstr = "";



        public class Data
        {
            public string secim1db { get; set; }
            public string hazir1db { get; set; }
            public string hazir2db { get; set; }
            public string secim2db { get; set; }
            public string biraktif { get; set; }
            public string ikiaktif { get; set; }
            public string odaid { get; set; }
            public string chat1 { get; set; }
            public string chat2 { get; set; }
            public string odaparola { get; set; }
            public string sistemmesaj { get; set; }


        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Oda Adı")
            {
                textBox1.Text = "";
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Oda Adı";
            }
        }


        private void id_Enter(object sender, EventArgs e)
        {
            if (textBox3.Text == "Oda ID")
            {
                textBox3.Text = "";
            }
        }

        private void id_Leave(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                textBox3.Text = "Oda ID";
            }
        }

        public static int ID = 0;
   
        private async void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                if (textBox1.Text != "" || textBox1.Text == "Oda Adı")
                {

                    if (textBox2.Text != "" || textBox2.Text == "Oda Parolası")
                    {

                        FirebaseResponse getResponse = await client.GetAsync("/");
                        string searchStr = textBox1.Text;

                        if (getResponse.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            Dictionary<string, object> data = getResponse.ResultAs<Dictionary<string, object>>();
                            List<string> topLevelNodeNames = new List<string>(data.Keys);

                            bool found = false;

                            foreach (var nodeName in topLevelNodeNames)
                            {
                                if (nodeName == searchStr)
                                {
                                    found = true;
                                    MessageBox.Show($"Zaten  {nodeName}  Adında Bir Oda Mevcut. Oda İsmini Değiştiriniz.", "Taş-Kağıt-Makas Online PC");
                                    break;
                                }
                            }

                            if (!found)
                            {
                                timer1.Stop();
                                timer2.Stop();
                                sifreliodaolustur();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Firebase'den veri alınamadı. Hata kodu: " + getResponse.StatusCode, "Taş-Kağıt-Makas Online PC");
                        }


                    }
                    else
                    {
                        textBox2.Text = "Lütfen Bir Parola Adı Giriniz";
                    }
                }
                else
                {
                    textBox1.Text = "Lütfen Bir Oda Adı Giriniz";
                }
            }
            else
            {
                if (textBox1.Text != "" || textBox1.Text == "Oda Adı")
                {
                    FirebaseResponse getResponse = await client.GetAsync("/");
                    string searchStr = textBox1.Text;

                    if (getResponse.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        Dictionary<string, object> data = getResponse.ResultAs<Dictionary<string, object>>();
                        List<string> topLevelNodeNames = new List<string>(data.Keys);

                        bool found = false;

                        foreach (var nodeName in topLevelNodeNames)
                        {
                            if (nodeName == searchStr)
                            {
                                found = true;
                                MessageBox.Show($"Zaten {nodeName} Adında Bir Oda Mevcut. Oda İsmini Değiştiriniz.", "Taş-Kağıt-Makas Online PC");
                                break;
                            }
                        }

                        if (!found)
                        {
                            timer1.Stop();
                            timer2.Stop();
                            odaolustur();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Firebase'den veri alınamadı. Hata kodu: " + getResponse.StatusCode, "Taş-Kağıt-Makas Online PC");
                    }

                }
                else
                {
                    textBox1.Text = "Lütfen Bir Oda Adı Giriniz";
                }
            }
        }


        private async void sifreliodaolustur() {
            Random random = new Random();
            ID = random.Next(0, 100001);
            bilgiodaidstr = ID.ToString();
            client = new FireSharp.FirebaseClient(config);

            // Eğer hata var ise null döner
            if (client == null)
            {
                MessageBox.Show("Bağlantı hatası.", "Taş-Kağıt-Makas Online PC");
                return;
            }

            // "birinci" kümesinden mevcut veriyi çek
            FirebaseResponse getResponseBirinci = await client.GetAsync(textBox1.Text + "/" + "birinci");
            Data currentDataBirinci = getResponseBirinci.ResultAs<Data>();


            // "ikinci" kümesinden mevcut veriyi çek
            FirebaseResponse getResponseIkinci = await client.GetAsync(textBox1.Text + "/" + "ikinci");
            Data currentDataIkinci = getResponseIkinci.ResultAs<Data>();



            FirebaseResponse getResponseidpas = await client.GetAsync(textBox1.Text);
            Data currentDataIid = getResponseidpas.ResultAs<Data>();

            // "birinci" kümesini güncelle ve sadece "hazir1db" ve "secim1db" alanlarını değiştir
            var newDataBirinci = new Data
            {
                hazir1db = "false",
                secim1db = "yok",
                biraktif = "off",
                chat1 = "",

            };
            FirebaseResponse updateResponseBirinci = await client.UpdateAsync(textBox1.Text + "/" + "birinci", newDataBirinci);

            // "ikinci" kümesini güncelle ve sadece "hazir2db" ve "secim2db" alanlarını değiştir
            var newDataIkinci = new Data
            {
                hazir2db = "false",
                secim2db = "yok",
                ikiaktif = "off",
                chat2 = ""

            };
            FirebaseResponse updateResponseIkinci = await client.UpdateAsync(textBox1.Text + "/" + "ikinci", newDataIkinci);


            var idyukle = new Data
            {

                odaid = ID.ToString(),
                odaparola = textBox2.Text,
                sistemmesaj = ""

            };
            FirebaseResponse updateResponseid = await client.UpdateAsync(textBox1.Text, idyukle);
            parolagir.odaparolasi = textBox2.Text;
            secilenoda = textBox1.Text;
            player osece = new player();
            Hide();
            osece.Show();
        }

        private async void odaolustur()
        {
            Random random = new Random();
            ID = random.Next(0, 100001);
            client = new FireSharp.FirebaseClient(config);
            bilgiodaidstr = ID.ToString();
            // Eğer hata var ise null döner
            if (client == null)
            {
                MessageBox.Show("Bağlantı hatası.", "Taş-Kağıt-Makas Online PC");
                return;
            }

            // "birinci" kümesinden mevcut veriyi çek
            FirebaseResponse getResponseBirinci = await client.GetAsync(textBox1.Text + "/" + "birinci");
            Data currentDataBirinci = getResponseBirinci.ResultAs<Data>();


            // "ikinci" kümesinden mevcut veriyi çek
            FirebaseResponse getResponseIkinci = await client.GetAsync(textBox1.Text + "/" + "ikinci");
            Data currentDataIkinci = getResponseIkinci.ResultAs<Data>();



            FirebaseResponse getResponseidpas = await client.GetAsync(textBox1.Text);
            Data currentDataIid = getResponseidpas.ResultAs<Data>();

            // "birinci" kümesini güncelle ve sadece "hazir1db" ve "secim1db" alanlarını değiştir
            var newDataBirinci = new Data
            {
                hazir1db = "false",
                secim1db = "yok",
                biraktif = "off",
                chat1 = "",

            };
            FirebaseResponse updateResponseBirinci = await client.UpdateAsync(textBox1.Text + "/" + "birinci", newDataBirinci);

            // "ikinci" kümesini güncelle ve sadece "hazir2db" ve "secim2db" alanlarını değiştir
            var newDataIkinci = new Data
            {
                hazir2db = "false",
                secim2db = "yok",
                ikiaktif = "off",
                chat2 = ""

            };
            FirebaseResponse updateResponseIkinci = await client.UpdateAsync(textBox1.Text + "/" + "ikinci", newDataIkinci);


            var idyukle = new Data
            {

                odaid = ID.ToString(),
                odaparola = "",
                sistemmesaj=""

            };
            FirebaseResponse updateResponseid = await client.UpdateAsync(textBox1.Text, idyukle);
            parolagir.odaparolasi = textBox2.Text;
            secilenoda = textBox1.Text;
            player osece = new player();
            Hide();
            osece.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 anamenu = new Form2();
            Hide();
            anamenu.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           
            if (checkBox1.Checked == true)
            {
                textBox2.Enabled = true;

                if (textBox1.Text == "" || textBox1.Text == "Oda Adı" || textBox2.Text == "" || textBox2.Text == "Oda Parolası")
                {
                    button1.Enabled = false;
                }
                else
                {
                    button1.Enabled = true;
                }
            }
            else
            {
                //textBox2.Enabled = false;
                if (textBox1.Text == "" || textBox1.Text == "Oda Adı")
                {
                    button1.Enabled = false;
                }
                else
                {
                    button1.Enabled = true;
                }
            }
            if (textBox3.Text == "" || textBox3.Text == "Oda Adı")
            {
                button5.Enabled = false;
            }
            else
            {
                button5.Enabled = true;
            }
        }
     
        private void odalar_Load(object sender, EventArgs e)
        {
            //listView1.BorderStyle = BorderStyle.FixedSingle;
            listView1.Columns.Add("                    Oda Adı", 337);
            listView1.Columns.Add("    ID", 86);
            listView1.Columns.Add("Aktif", 62);


            timer1.Start();
            timer2.Start();
            yenile();
            /*
            client = new FireSharp.FirebaseClient(config);

            if (client == null)
            {
                MessageBox.Show("Bağlantı hatası.");
                return;
            }

            // Silmek istediğiniz koleksiyonun tam yolu
            string silinecekDugumYolu = "birinci";

            // Firebase Realtime Database'den belirtilen düğümü sil
            FirebaseResponse deleteResponse = await client.DeleteAsync(silinecekDugumYolu);
            */
        }

        private void button3_Click(object sender, EventArgs e)
        {
            yenile();
        }
       public static string secilenoda = "";
        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            //label5.Text = listBox1.SelectedItem.ToString(); 
            if (listBox1.SelectedItem.ToString() != "")
            {
                secilenoda = listBox1.SelectedItem.ToString();
                player osece = new player();
                Hide();
                osece.Show();
            }
        }
        string aktifk = "";
  
        private async void yenile()
        {/*
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            */
            client = new FireSharp.FirebaseClient(config);
            listView1.Items.Clear();

            // Eğer hata var ise null döner
            if (client == null)
            {
                MessageBox.Show("Bağlantı hatası.", "Taş-Kağıt-Makas Online PC");
                return;
            }

            // Firebase Realtime Database'den tüm çocuk düğümleri al
            FirebaseResponse getResponse = await client.GetAsync("");

            if (getResponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Dictionary<string, object> data = getResponse.ResultAs<Dictionary<string, object>>();
                /*
                // ListBox'ları temizle
                listBox1.Items.Clear();
                listBox2.Items.Clear();
                listBox3.Items.Clear();
                //textBox1.Text = data.Keys.ToString();
                */
                
                if (data != null)
                {
                    // Her bir oda adını ListBox'a ekleyin
                    foreach (var roomName in data.Keys)
                    {

                        // Her bir oda adı için birinci ve ikinci içindeki değerleri çek
                        FirebaseResponse birinciResponse = await client.GetAsync($"{roomName}/birinci");
                        FirebaseResponse ikinciResponse = await client.GetAsync($"{roomName}/ikinci");
                        FirebaseResponse fid = await client.GetAsync($"{roomName}");

                        Data birinciData = birinciResponse.ResultAs<Data>();
                        Data ikinciData = ikinciResponse.ResultAs<Data>();
                        Data fiddata = fid.ResultAs<Data>();

                        if (birinciData != null && ikinciData != null)
                        {
                            string birinciBiraktifValue = birinciData.biraktif;
                            string ikinciIkiaktifValue = ikinciData.ikiaktif;
                            idstr = fiddata.odaid;
                            if (birinciBiraktifValue == "on" && ikinciIkiaktifValue == "on")
                            {
                                // listBox3.Items.Add($"2/2");
                                aktifk = "2/2";
                            }
                            else if (birinciBiraktifValue == "on" || ikinciIkiaktifValue == "on")
                            {
                                 //listBox3.Items.Add($"2/1");
                                aktifk = "2/1";

                            }
                            else
                            {
                                // listBox3.Items.Add($"2/0");
                                aktifk = "2/0";

                            }
                            string[] odalarlist = {roomName,idstr, aktifk};
                            ListViewItem odaynl= new ListViewItem(odalarlist);
                            listView1.Items.Add(odaynl);
                            /*
                            listBox1.Items.Add(roomName);
                            listBox2.Items.Add($"{idstr}");
                            */
                            
                            // Duruma göre listBox2'ye ekleme yap
                        }
                        else
                        {
                            
                            MessageBox.Show($"Odaya Giriş Başarısız {roomName} Lütfen Daha Sonra Tekrar Deneyiniz." , "Taş-Kağıt-Makas Online PC");
                        }
                    }
                }
                
            }
            else
            {
                MessageBox.Show("Firebase'den veri alınamadı. Hata kodu: " + getResponse.StatusCode, "Taş-Kağıt-Makas Online PC");
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

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

        private void button4_Click(object sender, EventArgs e)
        {
            timer2.Stop();
            yenile();
            timer2.Start();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            yenile();
        }

       

        private async void listView1_DoubleClick(object sender, EventArgs e)
        {
            client = new FireSharp.FirebaseClient(config);

            string itemId = listView1.SelectedItems[0].SubItems[0].Text;
            string bilgiodaiddoubleclickid = listView1.SelectedItems[0].SubItems[1].Text;
            //MessageBox.Show(bilgiodaiddoubleclickid);
            // Eğer hata var ise null döner
            if (client == null)
                MessageBox.Show("Bağlantı hatası.", "Taş-Kağıt-Makas Online PC");

            FirebaseResponse response = await client.GetAsync($"{itemId}");

            // Response ile dönen sonuçları Data sınıfına aktardık
            Data result = response.ResultAs<Data>();

            if (result.odaparola !="") 
            {
                if (itemId != "")
                {
                    secilenoda = itemId;
                    bilgiodaidstr = bilgiodaiddoubleclickid;
                    timer1.Stop();
                    timer2.Stop();
                    parolagir parolatextbox = new parolagir();
                    Hide();
                    parolatextbox.Show();
                }
            }
            else
            {
             //   textBox1.Text = itemId+result.odaparola.ToString();
                
                if (itemId != "")
                {
                    secilenoda = itemId;
                    bilgiodaidstr = bilgiodaiddoubleclickid;
                    timer1.Stop();
                    timer2.Stop();
                    player osece = new player();
                    Hide();
                    osece.Show();
                }
                
                
            }
            
        }

        private void listView1_ColumnWidthChanged(object sender, ColumnWidthChangedEventArgs e)
        {
            if (e.ColumnIndex == 0 && listView1.Columns[0].Width != 337)
            {
                listView1.Columns[0].Width = 337;
            }
            else if (e.ColumnIndex == 1 && listView1.Columns[1].Width != 86)
            {
                listView1.Columns[1].Width = 86;
            }
            else if (e.ColumnIndex == 2 && listView1.Columns[2].Width != 65)
            {
                listView1.Columns[2].Width = 65;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "Oda Parolası")
            {
                textBox2.Text = "";
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "Oda Parolası";
            }
        }
        public static string idsecilenoda = ""; 

        private async void sifreilekatil() 
        {
            string searchId = textBox3.Text; // TextBox'tan alınan ID değeri
            bool found = false;

            // Firebase Realtime Database'den tüm çocuk düğümleri al
            FirebaseResponse getResponse = await client.GetAsync("/");

            if (getResponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Dictionary<string, object> data = getResponse.ResultAs<Dictionary<string, object>>();

                // En üst düzey koleksiyonların isimlerini al
                List<string> topLevelCollectionNames = new List<string>(data.Keys);

                // Bu isimleri tek tek kontrol et
                foreach (var collectionName in topLevelCollectionNames)
                {
                    // Her koleksiyondan "odaid" değerini al
                    FirebaseResponse childResponse = await client.GetAsync($"/{collectionName}/odaid");
                    string odaIdValue = childResponse.ResultAs<string>();

                    // Eğer aranan ID değeri bulunduysa
                    if (odaIdValue == searchId)
                    {
                        //MessageBox.Show($"{collectionName}");
                        found = true;

                        client = new FireSharp.FirebaseClient(config);

                        //string itemId = listView1.SelectedItems[0].SubItems[0].Text;
                        // Eğer hata var ise null döner
                        if (client == null)
                        {
                            MessageBox.Show("Bağlantı hatası.", "Taş-Kağıt-Makas Online PC");
                        }
                        // Firebase database'i oluştururken directory oluşturmadığımız için GetAsync içerisini boş bıraktık
                        FirebaseResponse response = await client.GetAsync($"{collectionName}");

                        // Response ile dönen sonuçları Data sınıfına aktardık
                        Data result = response.ResultAs<Data>();

                        if (result.odaparola != "")
                        {
                            //idsecilenoda = collectionName;
                            secilenoda = collectionName;
                            bilgiodaidstr = searchId;
                            timer1.Stop();
                            timer2.Stop();
                            parolagir parolatextbox = new parolagir();
                            Hide();
                            parolatextbox.Show();

                            //button5.Text= result.odaparola;
                        }
                        else
                        {
                            secilenoda = collectionName;
                            bilgiodaidstr = searchId;
                            timer1.Stop();
                            timer2.Stop();
                            player osece = new player();
                            Hide();
                            osece.Show();



                        }
                        break;
                    }
                }

                // Eğer aranan ID değeri bulunamadıysa
                if (!found)
                {
                    MessageBox.Show($"{searchId} ID' ye Sahip Oda Bulunamadı."  , "Taş-Kağıt-Makas Online PC");
                }
            }
            else
            {
                MessageBox.Show("Firebase'den veri alınamadı. Hata kodu: " + getResponse.StatusCode, "Taş-Kağıt-Makas Online PC");
            }
        }


        private void button5_Click(object sender, EventArgs e)
        {
            sifreilekatil();
           
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            // Eğer Enter tuşuna basıldıysa
            if (e.KeyCode == Keys.Enter)
            {
                // Enter tuşuna basılınca çalışmasını istediğiniz fonksiyonu çağırın
                sifreilekatil();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                textBox2.Enabled = true;
            }
            else if (!checkBox1.Checked)
            {
                textBox2.Text = "Oda Parolası";
                textBox2.Enabled = false;
            }
        }
    }
}
