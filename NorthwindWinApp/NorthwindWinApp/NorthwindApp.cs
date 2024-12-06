using NorthwindWinApp.Props;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NorthwindWinApp
{
    public partial class NorthwindApp : Form
    {
        public NorthwindApp()
        {
            InitializeComponent();
        }

        private void NorthwindApp_Load(object sender, EventArgs e)
        {

        }

        private void btn_ekle_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tb_kategoriAdi.Text))
            {
                if (tb_kategoriAdi.Text == "Categories")
                {
                    lb_SecilecekSutunlar.Items.Add(tb_kategoriAdi.Text);
                    tb_kategoriAdi.Text = "";
                }
                else if (tb_kategoriAdi.Text == "Suppliers")
                {
                    lb_SecilecekSutunlar.Items.Add(tb_kategoriAdi.Text);
                    tb_kategoriAdi.Text = "";
                }
                else if (tb_kategoriAdi.Text == "Products")
                {
                    lb_SecilecekSutunlar.Items.Add(tb_kategoriAdi.Text);
                    tb_kategoriAdi.Text = "";
                }
                else if (tb_kategoriAdi.Text == "Customers")
                {
                    lb_SecilecekSutunlar.Items.Add(tb_kategoriAdi.Text);
                    tb_kategoriAdi.Text = "";
                }
                else if (tb_kategoriAdi.Text == "Employees")
                {
                    lb_SecilecekSutunlar.Items.Add(tb_kategoriAdi.Text);
                    tb_kategoriAdi.Text = "";
                }
                else if (tb_kategoriAdi.Text == "Orders")
                {
                    lb_SecilecekSutunlar.Items.Add(tb_kategoriAdi.Text);
                    tb_kategoriAdi.Text = "";
                }
                else
                {
                    MessageBox.Show("Hatalı giriş yaptınız. Lütfen yeniden giriniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tb_kategoriAdi.Clear();
                }
            }
            else
            {
                MessageBox.Show("Alan boş bırakılamaz. Lütfen eklemek için metin kutusuna uygun kategorileri yazınız.", "Dikkat!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lb_SecilecekSutunlar_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btn_listele_Click(object sender, EventArgs e)
        {
            
            var liste = lb_SecilecekSutunlar.SelectedItems;

            foreach (string item in liste)
            {
                if (item == "Categories")
                {
                    SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS; Initial Catalog=NORTHWND; Integrated Security=True");
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "SELECT * FROM Categories";
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Columns.Add("Kategori No");
                    dt.Columns.Add("Kategori İsim");
                    dt.Columns.Add("Kategori Açıklaması");
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string name = reader.GetString(1);
                        string description = reader.GetString(2);
                        dt.Rows.Add(id, name, description);
                    }

                    dataGridView1.DataSource = dt;
                }
                if (item == "Suppliers")
                {
                    SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS; Initial Catalog=NORTHWND; Integrated Security=True");
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "SELECT * FROM Suppliers";
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Columns.Add("Tedarikçi No");
                    dt.Columns.Add("Şirket Adı");
                    dt.Columns.Add("Kişi Adı");
                    dt.Columns.Add("Kişi Unvanı");
                    dt.Columns.Add("Adres");
                    dt.Columns.Add("Şehir");
                    dt.Columns.Add("Posta Kodu");
                    dt.Columns.Add("Ülke");
                    dt.Columns.Add("Telefon No");
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string companyName = reader.GetString(1);
                        string contactName = reader.GetString(2);
                        string contactTitle = reader.GetString(3);
                        string address = reader.GetString(4);
                        string city = reader.GetString(5);
                        string postalCode = reader.GetString(7);
                        string country = reader.GetString(8);
                        string phone = reader.GetString(9);

                        dt.Rows.Add(id, companyName, contactName, contactTitle, address, city, postalCode, country, phone);
                    }

                    dataGridView1.DataSource = dt;
                }
                if (item == "Products")
                {
                    SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS; Initial Catalog=NORTHWND; Integrated Security=True");
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "SELECT * FROM Products";
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Columns.Add("Ürün No");
                    dt.Columns.Add("Ürün Adı");
                    dt.Columns.Add("Tedarikçi No");
                    dt.Columns.Add("Kategori No");
                    dt.Columns.Add("Birim başına içerdiği miktar");
                    dt.Columns.Add("Ürün Fiyatı");
                    dt.Columns.Add("Stoktaki Ürün Sayısı");
                    dt.Columns.Add("Birim Sipariş Sayısı");
                    dt.Columns.Add("Yenilen Sıralama Düzeyi");
                    dt.Columns.Add("Durdurulma");
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string ProductName = reader.GetString(1);
                        int SupplierID = reader.GetInt32(2);
                        int CategoryID = reader.GetInt32(3);
                        string QuantityPerUnit = reader.GetString(4);
                        int UnitPrice = Convert.ToInt32(reader.GetDecimal(5));
                        int UnitInStock = reader.GetInt16(6);
                        int UnitOnOrder = reader.GetInt16(7);
                        int ReOrderLevel = reader.GetInt16(8);
                        bool Discontinued = reader.GetBoolean(9);

                        dt.Rows.Add(id, ProductName, SupplierID, CategoryID, QuantityPerUnit, UnitPrice, UnitInStock, UnitOnOrder, ReOrderLevel, Discontinued);
                    }

                    dataGridView1.DataSource = dt;
                }
                if (item == "Customers")
                {
                    SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS; Initial Catalog=NORTHWND; Integrated Security=True");
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "SELECT * FROM Customers";
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Columns.Add("Müşteri No");
                    dt.Columns.Add("Şirket Adı");
                    dt.Columns.Add("Kişi Adı");
                    dt.Columns.Add("Kişi Unvanı");
                    dt.Columns.Add("Adres");
                    dt.Columns.Add("Şehir");
                    dt.Columns.Add("Ülke");
                    dt.Columns.Add("Telefon No");
                    while (reader.Read())
                    {
                        string id = reader.GetString(0);
                        string companyName = reader.GetString(1);
                        string contactName = reader.GetString(2);
                        string contactTitle = reader.GetString(3);
                        string address = reader.GetString(4);
                        string city = reader.GetString(5);
                        string country = reader.GetString(8);
                        string phone = reader.GetString(9);

                        dt.Rows.Add(id, companyName, contactName, contactTitle, address, city, country, phone);
                    }

                    dataGridView1.DataSource = dt;
                }
                if (item == "Employees")
                {
                    SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS; Initial Catalog=NORTHWND; Integrated Security=True");
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "SELECT * FROM Employees";
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Columns.Add("Çalışan No");
                    dt.Columns.Add("Çalışanın Adı");
                    dt.Columns.Add("Çalışanın Soyadı");
                    dt.Columns.Add("Çalışanın Ünvanı");
                    dt.Columns.Add("Nezaket Ünvanı");
                    dt.Columns.Add("Doğum Tarihi");
                    dt.Columns.Add("İşe Alım Tarihi");
                    dt.Columns.Add("Adres");
                    dt.Columns.Add("Şehir");
                    dt.Columns.Add("Posta Kodu");
                    dt.Columns.Add("Ülke");
                    dt.Columns.Add("Telefon No");
                    dt.Columns.Add("Eklenti");
                    dt.Columns.Add("Notlar");
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string firstName = reader.GetString(2);
                        string lastName = reader.GetString(1);
                        string title = reader.GetString(3);
                        string titleOfCourtesy = reader.GetString(4);
                        DateTime birthDate = reader.GetDateTime(5);
                        DateTime hireDate = reader.GetDateTime(6);
                        string address = reader.GetString(7);
                        string city = reader.GetString(8);
                        string postalCode = reader.GetString(10);
                        string country = reader.GetString(11);
                        string homePhone = reader.GetString(12);
                        string extension = reader.GetString(13);
                        string notes = reader.GetString(15);

                        dt.Rows.Add(id, firstName, lastName, title, titleOfCourtesy, birthDate, hireDate, address, city, postalCode, country, homePhone, extension, notes);
                    }

                    dataGridView1.DataSource = dt;
                }
                if (item == "Orders")
                {
                    SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS; Initial Catalog=NORTHWND; Integrated Security=True");
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "SELECT * FROM Orders";
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Columns.Add("Sipariş No");
                    dt.Columns.Add("Müşteri No");
                    dt.Columns.Add("Çalışan No");
                    dt.Columns.Add("Sipariş Tarihi");
                    dt.Columns.Add("Siparişin son tarihi");
                    dt.Columns.Add("Nakliyeci No");
                    dt.Columns.Add("Yük Miktarı");
                    dt.Columns.Add("Ürün Adı");
                    dt.Columns.Add("Ürünün Gönderileceği Adres");
                    dt.Columns.Add("Ürünün Gönderileceği Şehir");
                    dt.Columns.Add("Ürünün Gönderileceği Ülke");
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string customerID = reader.GetString(1);
                        int employeesID = reader.GetInt32(2);
                        DateTime orderDate = reader.GetDateTime(3);
                        DateTime requiredDate = reader.GetDateTime(4);
                        int shipVia = reader.GetInt32(6);
                        int freight = Convert.ToInt32(reader.GetDecimal(7));
                        string shipName = reader.GetString(8);
                        string shipAddress = reader.GetString(9);
                        string shipCity = reader.GetString(10);
                        string shipCountry = reader.GetString(13);


                        dt.Rows.Add(id, customerID, employeesID, orderDate, requiredDate, shipVia, freight, shipName, shipAddress, shipCity, shipCountry);
                    }

                    dataGridView1.DataSource = dt;
                }
                
            }
        }

        private void btn_formuTemizle_Click(object sender, EventArgs e)
        {
            lb_SecilecekSutunlar.Items.Clear();
        }

        private void btn_temizle_Click(object sender, EventArgs e)
        {
            //dataGridView1.Rows.Clear(); //Hata verdi. 
        }
    }
}
