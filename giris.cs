using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms;
using System.Data.OleDb;


namespace WindowsFormsApp1
{
    public partial class giris : Form
    {
        
        OleDbDataAdapter Veri_Adaptor;
        DataSet Veri_Seti;
       
        




        public giris()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OleDbConnection Veri_Baglanti = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0; Data Source = fatura.accdb");
            Veri_Baglanti.Open();
            OleDbCommand Veri_Komutu = new OleDbCommand("select * from kayit where kAd=@ad and kSifre=@sifre ", Veri_Baglanti);
            Veri_Komutu.Parameters.Add("@ad", textBox1.Text);
            Veri_Komutu.Parameters.Add("@sifre", textBox2.Text);
            OleDbDataReader Veri_Oku = Veri_Komutu.ExecuteReader();

            if(Veri_Oku.Read())
            {
                Form1 frm = new Form1();
                frm.Show();
                this.Hide();                 
            }

            else
            {
                Veri_Baglanti.Close();
                MessageBox.Show("Hatalı Kullanıcı Aı veya Şifre");
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            sifre ekle = new sifre();
            ekle.ShowDialog();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            kayitol ekle = new kayitol();
            ekle.ShowDialog();
        }
    }
}
