using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Kisi a = new Kisi();
            a.ad = textBox1.Text;
            a.soyad = textBox2.Text;
            a.numara = textBox3.Text;
            listBox1.Items.Add(a);
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox1.Focus();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Kisi k = (Kisi)listBox1.SelectedItem;
            textBox1.Text=k.ad;
            textBox2.Text=k.soyad;
            textBox3.Text=k.numara;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Kisi a;
            System.Data.OleDb.OleDbConnection yol = new System.Data.OleDb.OleDbConnection("provider=Microsoft.Jet.OLEDB.4.0; Data source=Rehber.mdb");
            yol.Open();
            System.Data.OleDb.OleDbCommand postaci = new System.Data.OleDb.OleDbCommand("select ad,soyad,numara from kisiler", yol);
            System.Data.OleDb.OleDbDataReader okuyucu = postaci.ExecuteReader();
            while (okuyucu.Read())
            {
                a = new Kisi();
                a.ad=okuyucu["ad"].ToString();
                a.soyad=okuyucu["soyad"].ToString();
                a.numara=okuyucu["numara"].ToString();
                listBox1.Items.Add(a);
            }
                    yol.Close();
                

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Aranıyor");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var nesneler = groupBox1.Controls.OfType<TextBox>();

            foreach (var nesne in nesneler)
            {
                nesne.Clear();
            }
        }
    }
            
            class Kisi
            {
                public String ad;
                public String soyad;
                public String numara;
                
                public override string  ToString()
{
 	             return this.ad + "  " + this.soyad;
}
            }

        }

