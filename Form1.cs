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
    public partial class Form1 : Form
    {
        OleDbConnection Veri_Baglanti = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0; Data Source = fatura.accdb");
        OleDbDataAdapter Veri_Adaptor;
        DataSet Veri_Seti;
        OleDbCommand Veri_Komutu;
        OleDbDataReader Veri_Oku;

        public Form1()
        {
            InitializeComponent();
        }



        void Verileri_Goster()
        {
            Veri_Adaptor = new OleDbDataAdapter("Select * from Doğalgaz", Veri_Baglanti);

            Veri_Seti = new DataSet();

            
            Veri_Baglanti.Open();

            Veri_Adaptor.Fill(Veri_Seti, "Doğalgaz");
            dataGridView1.DataSource = Veri_Seti.Tables["Doğalgaz"];

            Veri_Baglanti.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Veri_Komutu = new OleDbCommand();
            Veri_Baglanti.Open();

            Veri_Komutu.Connection = Veri_Baglanti;
            Veri_Komutu.CommandText = "Delete from Doğalgaz where sozlesme_no ='" + textBox1.Text + "'";
            Veri_Komutu.ExecuteNonQuery();
            Veri_Baglanti.Close();
            Verileri_Goster();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmYeniKayit ekle = new frmYeniKayit();
            ekle.ShowDialog();
            Verileri_Goster();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            {
                Verileri_Goster();
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Veri_Komutu = new OleDbCommand();
            Veri_Baglanti.Open();

            Veri_Komutu.Connection = Veri_Baglanti;
            Veri_Komutu.CommandText = "Update Doğalgaz Set sozlesme_no = @sozlesme, ad = @ad, soyad=@soyad , adres = @adres, tuketilen_enerji_mik = @enerji, fatura_tutar = @tutar, son_odeme_tarihi=@tarih where sozlesme_no=@sozlesme";
            
            Veri_Komutu.Parameters.AddWithValue("@sozlesme", textBox1.Text);
            Veri_Komutu.Parameters.AddWithValue("@ad", textBox2.Text);
            Veri_Komutu.Parameters.AddWithValue("@soyad", textBox3.Text);
            Veri_Komutu.Parameters.AddWithValue("@adres", textBox4.Text);
            Veri_Komutu.Parameters.AddWithValue("@enerji", textBox5.Text);
            Veri_Komutu.Parameters.AddWithValue("@tutar", textBox6.Text);
            Veri_Komutu.Parameters.AddWithValue("@tarih", textBox7.Text);
            
            Veri_Komutu.ExecuteNonQuery();
            Veri_Baglanti.Close();
            Verileri_Goster();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox7.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            Veri_Adaptor = new OleDbDataAdapter("Select * from Doğalgaz Where ad like '" + textBox8.Text + "%'", Veri_Baglanti);

            Veri_Seti = new DataSet();



            Veri_Baglanti.Open();


            Veri_Adaptor.Fill(Veri_Seti, "Doğalgaz");

            dataGridView1.DataSource = Veri_Seti.Tables["Doğalgaz"];


            Veri_Baglanti.Close();
        }
    }
}
