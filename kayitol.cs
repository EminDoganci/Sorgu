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
    public partial class kayitol : Form
    {

        OleDbConnection Veri_Baglanti = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0; Data Source = fatura.accdb");
        OleDbDataAdapter Veri_Adaptor;
        DataSet Veri_Seti;
        OleDbCommand Veri_Komutu;
        OleDbDataReader Veri_Oku;



        public kayitol()
        {
            InitializeComponent();
        }

        private void kayitol_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Veri_Komutu = new OleDbCommand();
            Veri_Baglanti.Open();

            Veri_Komutu.Connection = Veri_Baglanti;
            Veri_Komutu.CommandText = "INSERT INTO kayit(kAd, kSifre) values(@ad, @sifre)";

            Veri_Komutu.Parameters.AddWithValue("@sozlesme", textBox1.Text);
            Veri_Komutu.Parameters.AddWithValue("@ad", textBox2.Text);
           

            Veri_Komutu.ExecuteNonQuery();
            Veri_Baglanti.Close();
            textBox1.Text = "";
            textBox2.Text = "";
          
            MessageBox.Show("Yeni Kullanıcı Eklendi");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
