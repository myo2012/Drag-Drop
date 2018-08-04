using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApplication4
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {

            // sürüklediğimiz yerin kordinatlarını vericez..    
            pictureBox1.DoDragDrop("pct", DragDropEffects.Move);

        }

     

        private void Form2_DragDrop(object sender, DragEventArgs e)
        {

            string gelendata = e.Data.GetData(DataFormats.StringFormat).ToString();

            if (gelendata == "pct")
            {
                pictureBox1.Left = e.X - pictureBox1.Width / 2;
                pictureBox1.Top = e.Y - pictureBox1.Height / 2;
            }
            else if (gelendata == "btn")
            {
                button1.Left = e.X - button1.Width / 2;
                button1.Top = e.Y - button1.Height / 2;
            }
            
        }

        private void Form2_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            button1.DoDragDrop("btn", DragDropEffects.Move);
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {

            // form kapanırken degerleri değişkene atıyoruz ve form açıldıgında 
        // kaldıgı yerden devam ediyor
            string btnLeft = button1.Left.ToString();
            string btnTop = button1.Top.ToString();
            string pctLeft = pictureBox1.Left.ToString();
            string pctTop = pictureBox1.Top.ToString();

 //degerleri exe'nin yanına atıyoruz.. Application.StartupPath projenin kısayolu
            StreamWriter yazici = new StreamWriter(Application.StartupPath +"\\ayarlar.txt");
            yazici.WriteLine(btnLeft + "," + btnTop);
            yazici.WriteLine(pctLeft + "," + pctTop);

            yazici.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

            // ayarlar adlı dosya varmı diye bakıyoruz
            if (File.Exists(Application.StartupPath + @"\\ayarlar.txt") == false)
            {

                return;
            }



            StreamReader okuyucu = new StreamReader(Application.StartupPath + "\\ayarlar.txt");


            okuyucu.ReadLine();
            // readLine tek satır okur
            String btnKoordinat = okuyucu.ReadLine();
            String pctKoordinat = okuyucu.ReadLine();

            okuyucu.Close();

            String[] btnLeftTop = btnKoordinat.Split(',');//split geri dönüşü array'dır
            // virgüle göre koordinatları ayarlar içinden ayırdılarını diziye attık.

            button1.Left = Convert.ToInt32(btnLeftTop[0]);
            button1.Top = Convert.ToInt32(btnLeftTop[1]);

            String[] pctTopLeft = pctKoordinat.Split(',');

            pictureBox1.Left = Convert.ToInt32(pctTopLeft[0]);
            pictureBox1.Left = Convert.ToInt32(pctTopLeft[1]);

        }    
    }
}
