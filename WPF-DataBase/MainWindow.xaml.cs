using System.Windows;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Controls;
using System;
using System.Windows.Data;
using WpfApplication3.Model;

namespace WpfApplication3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public static int SelectedOrderId;

        public static string ConnectionString
        {
            get
            {
                return @"Data Source=DESKTOP-24E48FP\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            }
        }

        private void BaseLoaded(object sender, RoutedEventArgs e)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Orders", conn);
                SqlDataReader dr = cmd.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGrid1.ItemsSource = dt.AsDataView();
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Orders", conn);
                SqlDataReader dr = cmd.ExecuteReader();

                DataTable dt = new DataTable();
                AddOrder ao = new AddOrder();
                ao.Show();
                dt.Load(dr);
                dataGrid1.ItemsSource = dt.AsDataView();
            }
        }

        private void ReadButton_Click(object sender, RoutedEventArgs e)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Orders", conn);
                SqlDataReader dr = cmd.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGrid1.ItemsSource = dt.AsDataView();
                conn.Close();
            }
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            if ((DataRowView)dataGrid1.SelectedItem!=null)
            {
                using (var conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    DataRowView drv = (DataRowView)dataGrid1.SelectedItem;
                    Order order = new Order((DateTime)drv[3], (DateTime)drv[4], (DateTime)drv[5], (int)drv[6], Decimal.Parse(drv[7].ToString()), drv[8]?.ToString(), drv[9]?.ToString(), drv[10]?.ToString(),
                        drv[11]?.ToString(), drv[12]?.ToString(), drv[13]?.ToString());

                    Services.DataBaseOperation.UpdateOrder(order, (int)((DataRowView)dataGrid1.SelectedItem)[0]);

                    SqlCommand cmd2 = new SqlCommand("SELECT * FROM Orders", conn);
                    SqlDataReader dr = cmd2.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(dr);
                    dataGrid1.ItemsSource = dt.AsDataView();
                    conn.Close();
                }
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if ((DataRowView)dataGrid1.SelectedItem != null)
            {
                using (var conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    DataRowView drv = (DataRowView)dataGrid1.SelectedItem;

                    string deleteRowQuery = "DELETE FROM Orders WHERE orderid=@id";

                    using (SqlCommand cmd = new SqlCommand(deleteRowQuery, conn))
                    {

                        cmd.Parameters.Add("@id", SqlDbType.Int).Value = ((DataRowView)dataGrid1.SelectedItem)[0];

                        cmd.ExecuteNonQuery();
                        SqlCommand cmd2 = new SqlCommand("SELECT * FROM Orders", conn);
                        SqlDataReader dr = cmd2.ExecuteReader();
                        DataTable dt = new DataTable();
                        dt.Load(dr);
                        dataGrid1.ItemsSource = dt.AsDataView();
                        conn.Close();
                    }

                }
            }
        }
    }
}
