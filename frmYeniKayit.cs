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
    public partial class frmYeniKayit : Form
    {
        OleDbConnection Veri_Baglanti = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0; Data Source = fatura.accdb");
        OleDbDataAdapter Veri_Adaptor;
        DataSet Veri_Seti;
        OleDbCommand Veri_Komutu;
        OleDbDataReader Veri_Oku;




        public frmYeniKayit()
        {
            InitializeComponent();
        }

       



        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Veri_Komutu = new OleDbCommand();
            Veri_Baglanti.Open();

            Veri_Komutu.Connection = Veri_Baglanti;
            Veri_Komutu.CommandText = "INSERT INTO Doğalgaz(sozlesme_no, ad, soyad, adres, tuketilen_enerji_mik, fatura_tutar, son_odeme_tarihi) values(@sozlesme, @ad, @soyad, @adres, @enerji, @tutar, @tarih)";

            Veri_Komutu.Parameters.AddWithValue("@sozlesme", textBox1.Text);
            Veri_Komutu.Parameters.AddWithValue("@ad", textBox2.Text);
            Veri_Komutu.Parameters.AddWithValue("@soyad", textBox3.Text);
            Veri_Komutu.Parameters.AddWithValue("@adres", textBox4.Text);
            Veri_Komutu.Parameters.AddWithValue("@enerji", textBox5.Text);
            Veri_Komutu.Parameters.AddWithValue("@tutar", textBox6.Text);
            Veri_Komutu.Parameters.AddWithValue("@tarih", textBox7.Text);

            Veri_Komutu.ExecuteNonQuery();
            Veri_Baglanti.Close();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            MessageBox.Show("Yeni Kayıt Eklendi");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Sözleşme No 11 hanayi geçerse yada bulunan kayıtlarla aynı sayı girilirse çalışmaz " +
                "maalesef bunun hata mesajını verdiremedim:(");
        }
    }
}
