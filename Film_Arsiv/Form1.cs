using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Film_Arsiv
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-JH4F24U\SQLEXPRESS;Initial Catalog=FilmArsiv;" +
            "Integrated Security=True");
        void filmler()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select*from TBLFİLMLER",baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            filmler();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into TBLFİLMLER(ad,KATEGORİ,LİNK)values(@P1,P2,P3)", baglanti);
            komut.Parameters.AddWithValue("@P1", txtFilmAd.Text);
            komut.Parameters.AddWithValue("@P2", txtKategori.Text);
            komut.Parameters.AddWithValue("@P1", txtLink.Text);

            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Film listenize eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            filmler();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            string link = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            webBrowser1.Navigate(link);
        }

        private void btnHakkımızda_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bu proje 15 Mayıs 2022'de kodlandı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

       
    }
}
