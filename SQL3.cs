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
using System.Collections;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        SqlConnection baglanti;

        public Form1()
        {
            InitializeComponent();
        }

        private void VeriGetir()
        {
            baglanti.Open();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT CustomerID,[Title]      ,[FirstName]     ,[LastName]      ,[CompanyName]      ,[EmailAddress]            FROM[AdventureWorksLT2022].[SalesLT].[Customer]      ", baglanti);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            dgvData.DataSource = dataTable;
            baglanti.Close();
        }

        private void btnBaglanVeriGetir_Click(object sender, EventArgs e)
        {
            VeriGetir();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            baglanti = new SqlConnection("Server=DESKTOP-0IC98O5\\SQLEXPRESS;Database=AdventureWorksLT2022;Trusted_Connection=Yes;");
            dgvData.AutoGenerateColumns = false;

            ArrayList a = new ArrayList();
            foreach (object item in listBox1.Items)
            {
                string aas = item.ToString();
                int dda = 90;
            }
        }

        private void dgvData_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                int Selected_RowIndex = dgvData.SelectedCells[0].RowIndex;


                txtId.Text = dgvData.Rows[Selected_RowIndex].Cells[0].Value.ToString();
                txtBaslik.Text = dgvData.Rows[Selected_RowIndex].Cells[1].Value.ToString();
                txtAd.Text = dgvData.Rows[Selected_RowIndex].Cells[2].Value.ToString();
                txtSoyad.Text = dgvData.Rows[Selected_RowIndex].Cells[3].Value.ToString();
                txtSirket.Text = dgvData.Rows[Selected_RowIndex].Cells[4].Value.ToString();
                txtEposta.Text = dgvData.Rows[Selected_RowIndex].Cells["Column5"].Value.ToString();
                
            }
            catch (Exception)
            {

                
            }
           

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("delete FROM [SalesLT].[Customer] WHERE CustomerID = " + txtId.Text, baglanti);
                sqlDataAdapter.SelectCommand.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Başarı İle Silindi");
                VeriGetir();
            }
            catch (Exception ex)
            {
                MessageBox.Show("HATA SİLİNEMEDİ");

            }
            
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            String UpdateSentence = " UPDATE [SalesLT].[Customer] SET  [Title] = '" + txtBaslik.Text + "' ,[FirstName] = '" + txtAd.Text + "' WHERE  CustomerID =" + txtId.Text;

            try
            {
                baglanti.Open();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(UpdateSentence, baglanti);
                sqlDataAdapter.SelectCommand.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Başarı İle Düzenlendi");
                VeriGetir();
            }
            catch (Exception ex)
            {
                MessageBox.Show("HATA Düzenlenmedi");

            }


        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            

            String InsertSentence = "INSERT INTO[SalesLT].[Customer] ([FirstName]) VALUES ('"+txtAd.Text+"')";

            try
            {
                baglanti.Open();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(InsertSentence, baglanti);
                sqlDataAdapter.SelectCommand.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Başarı İle Eklendi");
                VeriGetir();
            }
            catch (Exception ex)
            {
                MessageBox.Show("HATA Eklenmedi");

            }


        }
    }
}
