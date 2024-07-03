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

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        SqlConnection SqlConnection;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnBaglanVeriGetir_Click(object sender, EventArgs e)
        {
             SqlConnection.Open();
             SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT [Title]  ,[FirstName] ,[LastName]  ,[CompanyName] ,[EmailAddress]  FROM[AdventureWorksLT2022].[SalesLT].[Customer] ", SqlConnection);
             DataTable dataTable = new DataTable();
             sqlDataAdapter.Fill(dataTable);

            dataGridView1.DataSource = dataTable;

            SqlConnection.Close();

        }

        // Veritabanına bağlanarak Select Cümlesinin Sonucunu datatable olarak döndüren fonksiyonu yazınız
        DataTable select2DataTable(String SelectSentence)
        {
            SqlConnection.Open();
            DataTable dataTable = new DataTable();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(SelectSentence, SqlConnection);
            sqlDataAdapter.Fill(dataTable);
            SqlConnection.Close();
            return dataTable;
        }

        // Veritabanına baglanarak SqlCumlesinin sonucunu OgrenciClasslarından olucan bir Arraylist olrak geri Dondur

        ArrayList Db2ArrayList (String SqlCumlesi)
        {
            ArrayList arrayList_Ogrenci = new ArrayList();

            SqlConnection.Open();
            DataTable dataTable = new DataTable();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(SqlCumlesi,SqlConnection);
            sqlDataAdapter.Fill(dataTable);

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                Ogrenci tmp_Ogrenci = new Ogrenci();
                tmp_Ogrenci.Title = dataTable.Rows[i]["Title"].ToString();
                tmp_Ogrenci.FirstName = dataTable.Rows[i]["FirstName"].ToString();
                tmp_Ogrenci.LastName = dataTable.Rows[i]["LastName"].ToString();
                arrayList_Ogrenci.Add(tmp_Ogrenci);
            }
            
            SqlConnection.Close();


            return  arrayList_Ogrenci;
        }

        private class Ogrenci
        {
            public string Title = "";
            public string FirstName = "";
            public string LastName = "";
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            SqlConnection = new SqlConnection("Server=DESKTOP-0IC98O5\\SQLEXPRESS;Database=AdventureWorksLT2022;Trusted_Connection=Yes;");
            dataGridView1.AutoGenerateColumns = false;
        }

    
        private void btnMetod_Click(object sender, EventArgs e)
        {
            //String Sorgu = "SELECT [Title] ,[FirstName] ,[LastName] FROM [AdventureWorksLT2022].[SalesLT].[Customer]";

            String Sorgu = txtSorgu.Text;
            try
            {
                DataTable sonuc = select2DataTable(Sorgu);
                dataGridView2.DataSource = sonuc;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
               
            }
          
        }

        private void btnVeri2_Click(object sender, EventArgs e)
        {
            ArrayList listem = Db2ArrayList(txtSorgu2.Text);

            foreach (Ogrenci item in listem)
            {
                txtEkran.Text += item.Title + " " + item.FirstName + " " + item.LastName+Environment.NewLine;
            }
        
        }
    }
}
