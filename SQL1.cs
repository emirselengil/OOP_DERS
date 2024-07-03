using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace db_Operations
{
    public partial class Form1 : Form
    {
        SqlConnection conn;
        public Form1()
        {
            InitializeComponent();
        }


        //  https://learn.microsoft.com/en-us/sql/samples/adventureworks-install-configure?view=sql-server-ver16&tabs=ssms#download-backup-files

        /*
         USE [AdventureWorksLT2022]
GO

SELECT  
      min(ListPrice) as min,
	   max(ListPrice) as max,
	   sum(ListPrice) as sum
 
     
  FROM [SalesLT].[Product]

GO



SELECT TOP (1000) [ProductID]
      ,[Name]
      ,[ProductNumber]
      ,[ListPrice]
	  ,([ListPrice]*1.20) as KDVDAHIL
       
  FROM [AdventureWorksLT2022].[SalesLT].[Product]
   order by [ListPrice] asc


USE [AdventureWorksLT2022]
GO

SELECT [CustomerID]
      ,[FirstName]
      ,[MiddleName]
	  ,([FirstName]+' '+[LastName]) as AdSoyad
      ,[LastName]
      ,[SalesPerson]
      ,[EmailAddress]
      ,[Phone]
    
  FROM [SalesLT].[Customer]

   where  FirstName   like '%Co%' 
 --   where  FirstName not like '%Co%' 
  -- where  FirstName = 'Scott' and LastName = 'Culp'
 --  where CustomerID >=  12 and CustomerID <20
    order by FirstName desc
GO


 SELECT TOP (10) [CustomerID]
      ,[NameStyle]
      ,[Title]
      ,[FirstName]
      ,[MiddleName]
      ,[LastName]
      ,[Suffix]
      ,[CompanyName]
      ,[SalesPerson]
      ,[EmailAddress]
      ,[Phone]
      ,[PasswordHash]
      ,[PasswordSalt]
      ,[rowguid]
      ,[ModifiedDate]
  FROM [AdventureWorksLT2022].[SalesLT].[Customer]

         
         
        */
        private void btnBaglan_Click(object sender, EventArgs e)
        {
            conn.Open();
            if(conn.State == ConnectionState.Open)
            {
                txtEkran.Text = "Bağlantı AÇILDI";

            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection("Server=DESKTOP-0IC98O5\\SQLEXPRESS;Database=AdventureWorksLT2022;Trusted_Connection=Yes;");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            conn.Close();
            if (conn.State == ConnectionState.Closed)
            {
                txtEkran.Text = "Bağlantı KAPANDI";

            }
        }
    


        private void btnGetir_Click(object sender, EventArgs e)
        {
            conn.Open();

            SqlDataAdapter adapter = new SqlDataAdapter("SELECT [CustomerID] ,[Title] ,[FirstName] ,[LastName] FROM[AdventureWorksLT2022].[SalesLT].[Customer] ", conn);
            DataTable data = new DataTable();
            adapter.Fill(data);
            conn.Close();

            dataGridView1.DataSource = data;

            for (int i = 0; i < data.Rows.Count; i++)
            {
                for (int j = 0; j < data.Columns.Count; j++)
                {
                    txtEkran.Text += data.Rows[i][j].ToString()+" ";
                }
                txtEkran.Text += Environment.NewLine ;
            }

            dataGridView1.DataSource = data;

            for (int i = 0; i < data.Rows.Count; i++)
            {
                listBox1.Items.Add( data.Rows[i][1] + " " + data.Rows[i][2] + " " + data.Rows[i][3]);
            }
            }

        private void txtAra_TextChanged(object sender, EventArgs e)
        {


            if (txtAra.Text.Length > 4) { 
            conn.Open();

            String AramaCumlesi = "SELECT  [Name]  ,[ProductNumber],[Color] ,[StandardCost] ,[ListPrice] FROM [SalesLT].[Product]  where  ProductNumber like '%" + txtAra.Text+"%' ";

            SqlDataAdapter adapter = new SqlDataAdapter(AramaCumlesi, conn);
            DataTable data = new DataTable();
            adapter.Fill(data);
            conn.Close();
            dataGridView1.DataSource = data;
            }
        }
    }
}
