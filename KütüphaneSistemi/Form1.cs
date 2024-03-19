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

namespace KütüphaneSistemi
{
    public partial class Form1 : Form
    {
        SqlConnection baglanti =new SqlConnection("Data Source=Burhan\\SQLEXPRESS;Initial Catalog=Kütüphanesistemib;Integrated Security=True;");
        public Form1() 
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.kitaplikTableAdapter.Fill(this.kütüphanesistemibDataSet.Kitaplik);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into Kitaplik(KitapADI,KitapYAZARI,ISBN,KitapDURUM)values(@k1,@k2,@k3,@k4)", baglanti);
            komut.Parameters.AddWithValue("@k1", textBox2.Text);
            komut.Parameters.AddWithValue("@k2", textBox3.Text);
            komut.Parameters.AddWithValue("@k3", maskedTextBox1.Text);
            komut.Parameters.AddWithValue("@k4", label10.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            this.kitaplikTableAdapter.Fill(this.kütüphanesistemibDataSet.Kitaplik);
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            label10.Text = "True";
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            label10.Text="False";
        }
        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand kitapsil=new SqlCommand("Delete from Kitaplik where KitapID=@s1",baglanti);
            kitapsil.Parameters.AddWithValue("@s1", textBox1.Text);
            kitapsil.ExecuteNonQuery();
            baglanti.Close();
        }
    }
}
