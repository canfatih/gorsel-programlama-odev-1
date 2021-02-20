using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
namespace ödev
{
    public partial class Form1 : Form
    {
        string[] kelimeler = { "FARE", "FİLE", "FAKS" };
        int tamamlanan = 0;
        Timer MyTimer;
        public Form1()
        {
            InitializeComponent();
            InitializeMyGroupBox();
            Form1_Load();
            this.listBox2.Items.AddRange(kelimeler);
            secilenler.Add(button3);
            secilenler.Add(button4);
            secilenler.Add(button5);
            secilenler.Add(button6);
            listBox2.SelectedIndex = tamamlanan;

        }
        int saniye = 60;
        int kalan = 60;
        int count = 0;
        string[] harfler = {"A","B","C","Ç","D","E","F","G","Ğ","H","I","İ","J","K","L","M","N","O","Ö","P","R","S","Ş","T","U","Ü","V","Y","Z"};
        GroupBox groupBox1;
        Char[] secilen = new Char[4];
        string aranan = "";
        List<Button> secilenler = new List<Button>();
        List<Button> butonlar = new List<Button>();
        private void InitializeMyGroupBox()
        {
            // Create and initialize a GroupBox and a Button control.
            groupBox1 = new GroupBox();
            groupBox1.Location = new Point(20, 70);
            groupBox1.Size = new Size(400, 350);
            Button button1 = new Button();
            button1.Location = new Point(50, 80);
            button1.Size = new Size(20, 20);
            Button button2 = new Button();
            button2.Location = new Point(80, 80);
            button2.Size = new Size(20, 20);
            Button button3 = new Button();
            button3.Location = new Point(110, 80);
            button3.Size = new Size(20, 20);
            Button button4 = new Button();
            button4.Location = new Point(130, 80);
            button4.Size = new Size(20, 20);
            Button button5 = new Button();
            button5.Location = new Point(160, 80);
            button5.Size = new Size(20, 20);
            // Set the FlatStyle of the GroupBox.
            groupBox1.FlatStyle = FlatStyle.Flat;

            butonlar.Add(button1);
            butonlar.Add(button2);
            butonlar.Add(button3);
            butonlar.Add(button4);
            butonlar.Add(button5);

            foreach (Button btn in butonlar) {
                groupBox1.Controls.Add(btn);
                btn.Click += buttonharf_Click;
            }
            

            

            
            // Add the GroupBox to the Form.
            Controls.Add(groupBox1);
        }
        private void button1_Click(object sender, EventArgs e)
        {   
            Random rastgele = new Random();

        }
        protected void buttonharf_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            Char harf = clickedButton.Text.ToCharArray()[0];
            aranan = kelimeler[tamamlanan];
            //secilen.Append("    ");

            int index = -1;
            if (aranan.Contains(harf)) {
                 index = aranan.IndexOf(harf);
            }
            if (index == 0)
                {
                    button9.Text = ""+harf;
                    secilen[0] = harf;
                }
            else if (index == 1)
            {
                button10.Text = "" + harf;
                secilen[1] = harf;
            }
            else if (index == 2)
            {
                button11.Text = "" + harf;
                secilen[2] = harf;
            }
            else if (index == 3)
            {
                button12.Text = "" + harf;
                secilen[3] = harf;
            }

            
            
        }


        private void Form1_Load()
        {
            MyTimer = new Timer();
            MyTimer.Interval = (1 * 1000); // 1sn
            MyTimer.Tick += new EventHandler(MyTimer_Tick);
        }

        private void MyTimer_Tick(object sender, EventArgs e)
        {
            //MessageBox.Show("timer calisti");
            Random rastgele = new Random();
            foreach (Button btn in butonlar)
            {
                int a = rastgele.Next(0, 28);
                btn.Text = harfler[a];
                int x = rastgele.Next(30, 390);
                int y = rastgele.Next(90, 150);

                btn.Location = new Point(x,y);
            }

            count++;
            kalan--;

            label1.Text = "Kalan Süre \n " + kalan;

            if (count == saniye) {
                MessageBox.Show("ooups zaman doldu.");
                MyTimer.Stop();
            }
            
        }

        private void onayla(object sender, EventArgs e)
        {
            String onaysecilen = new String(secilen);
            if (aranan == onaysecilen)
            {
                MessageBox.Show(tamamlanan + ". kelimeyi tamamladın");
                tamamlanan++;
                listBox2.SelectedIndex = tamamlanan;
            }
        }

        private void oyuna_basla(object sender, EventArgs e)
        {
            MyTimer.Start();
        }

        private void oyunu_bitir(object sender, EventArgs e)
        {
            MyTimer.Stop();
        }
    }
}
