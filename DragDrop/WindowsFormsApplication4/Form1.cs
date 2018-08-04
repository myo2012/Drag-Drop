using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_MouseDown(object sender, MouseEventArgs e)
        {                     //basıldıgı an
            if(listBox1.SelectedItem==null) // boş biyere tıklayıp sürüklemeye çalıştımızda
                //bu if blogu olmassa hata verir
            {
                return;
            }


            listBox1.DoDragDrop(listBox1.SelectedItem,DragDropEffects.Move);
                                //SEÇİLMESİ             EFEKTİ          HAREKETETSİN
        }

        private void listBox2_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void listBox2_DragDrop(object sender, DragEventArgs e)
        {
            object tasinanDeger=e.Data.GetData(DataFormats.StringFormat);
            listBox2.Items.Add(tasinanDeger);
            listBox1.Items.Add(tasinanDeger);

        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {

        }
    }
}
