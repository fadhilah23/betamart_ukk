using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;


namespace BetaMart_brg
{
    public partial class Form1 : Form
    {
        OleDbConnection koneksi = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\HP\source\repos\BetaMart_brg\BetaMart_brg\Betamart_Barang.accdb");

        public Form1()
        {
            InitializeComponent();
        }
        void ShowData()
        {
            koneksi.Open();
            string query = "select * from Barang";
            OleDbDataAdapter data = new OleDbDataAdapter(query, koneksi);
            DataTable dt = new DataTable();
            data.Fill(dt);
            dataGridView1.DataSource = dt;
            koneksi.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'betamart_BarangDataSet1.Barang' table. You can move, or remove it, as needed.
            this.barangTableAdapter.Fill(this.betamart_BarangDataSet1.Barang);

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        void ClearText()
        {
            ID.Clear();
            Nama.Clear();
            Harga.Clear();
            Kode.Clear();
            Stok.Clear();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearText();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            koneksi.Open();
            OleDbCommand cmd = new OleDbCommand("UPDATE Barang SET nama = '" + Nama.Text + "', kode = '" + Kode.Text + "', harga = '" + Harga.Text + "', stok = '" + Stok.Text + "' where ID=" + ID.Text + " ", koneksi);
            cmd.ExecuteNonQuery();
            koneksi.Close();
            MessageBox.Show("Data Berhasil Diupdate");

            ShowData();


        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            koneksi.Open();
            string perintah = "Insert into Barang (Nama, Kode, Harga, Stok) values ('" + Nama.Text + "', '" + Kode.Text + "', '" + Harga.Text + "', '" + Stok.Text + "')";
            OleDbCommand cmd = new OleDbCommand(perintah, koneksi);
            cmd.ExecuteNonQuery();
            koneksi.Close();
            MessageBox.Show("Data Tersimpan");

            ShowData();
        }

        private void Search_TextChanged(object sender, EventArgs e)
        {
            koneksi.Open();
            string perintah = "select * from Barang where Nama='" + Search.Text + "'";
            OleDbDataAdapter data = new OleDbDataAdapter(perintah, koneksi);
            DataTable dt = new DataTable();
            data.Fill(dt);
            dataGridView1.DataSource = dt;
            koneksi.Close();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            koneksi.Open();
            string perintah = "DELETE FROM Barang WHERE ID = " + ID.Text;
            OleDbCommand cmd = new OleDbCommand(perintah, koneksi);
            cmd.ExecuteNonQuery();
            koneksi.Close();
            MessageBox.Show("Data Terhapus");
            ShowData();

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
   

