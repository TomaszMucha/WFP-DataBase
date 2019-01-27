using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApplication3.Model;
using System.Data.SqlClient;
using System.Data;

namespace WpfApplication3.Services
{
    class DataBaseOperation
    {
        public static void AddOrder(Order order)
        {
            string connectionString = MainWindow.ConnectionString;
            string query = "INSERT INTO Orders " +
                    "(CustomerID, EmployeeID, OrderDate, RequiredDate, ShippedDate, ShipVia, Freight, ShipName, ShipAddress, " +
                    "ShipCity, ShipRegion, ShipPostalCode, ShipCountry) " +
                    "VALUES('vinet', 5, @orderDate, @requiredDate, @shippedDate, 3, @freight, @shipName," +
                    " @shipAddress, @shipCity, @shipRegion, @shipPostalCode, @shipCountry)";

            using (var conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();

                    cmd.Parameters.Add("@orderDate", SqlDbType.Date).Value = order.OrderDate;
                    cmd.Parameters.Add("@requiredDate", SqlDbType.Date).Value = order.RequredDate;
                    cmd.Parameters.Add("@shippedDate", SqlDbType.Date).Value = order.ShippedDate;
                    cmd.Parameters.Add("@freight", SqlDbType.Money).Value = order.Freight;
                    cmd.Parameters.Add("@shipName", SqlDbType.Text).Value = order.ShipName;
                    cmd.Parameters.Add("@shipAddress", SqlDbType.Text).Value = order.ShipAddress;
                    cmd.Parameters.Add("@shipCity", SqlDbType.Text).Value = order.ShipCity;
                    cmd.Parameters.Add("@shipRegion", SqlDbType.Text).Value = order.ShipRegion;
                    cmd.Parameters.Add("@shipPostalCode", SqlDbType.Text).Value = order.ShipPostalCode;
                    cmd.Parameters.Add("@shipCountry", SqlDbType.Text).Value = order.ShipCountry;

                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public static void UpdateOrder(Order order, int id)
        {
            using (var conn = new SqlConnection(MainWindow.ConnectionString))
            {
                conn.Open();
                UpdateOrder uo = new UpdateOrder();
                uo.OrderDateDatePicker.DisplayDate = order.OrderDate;
                uo.RequiredDateDatePicker.DisplayDate = order.RequredDate;
                uo.ShippedDateDatePicker.DisplayDate = order.ShippedDate;
                uo.FreightTextBox.Text = order.Freight.ToString();
                uo.ShipNameTextBox.Text = order.ShipName;
                uo.ShipAddressTextBox.Text = order.ShipAddress;
                uo.ShipCityTextBox.Text = order.ShipCity;
                uo.ShipRegionTextBox.Text = order.ShipRegion;
                uo.ShipPostalTextBox.Text = order.ShipPostalCode;
                uo.ShipCountryTextBox.Text = order.ShipCountry;
                uo.ShowDialog();

                string query = "UPDATE Orders " +
                        "SET OrderDate = @orderDate, RequiredDate = @requiredDate, ShippedDate = @shippedDate, Freight = @freight," +
                        " ShipName = @shipName, ShipAddress = @shipAddress, ShipCity = @shipCity, ShipRegion = shipRegion, " +
                        "ShipPostalCode = @shipPostalCode, ShipCountry = @shipCountry" +
                        " WHERE orderid=@id";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add("@orderDate", SqlDbType.Date).Value = uo.OrderDateDatePicker.DisplayDate;
                    cmd.Parameters.Add("@requiredDate", SqlDbType.Date).Value = uo.RequiredDateDatePicker.DisplayDate;
                    cmd.Parameters.Add("@shippedDate", SqlDbType.Date).Value = uo.ShippedDateDatePicker.DisplayDate;
                    cmd.Parameters.Add("@freight", SqlDbType.Money).Value = $"{uo.FreightTextBox.Text:C2}";
                    cmd.Parameters.Add("@shipName", SqlDbType.Text).Value = uo.ShipNameTextBox.Text;
                    cmd.Parameters.Add("@shipAddress", SqlDbType.Text).Value = uo.ShipAddressTextBox.Text;
                    cmd.Parameters.Add("@shipCity", SqlDbType.Text).Value = uo.ShipCityTextBox.Text;
                    cmd.Parameters.Add("@shipRegion", SqlDbType.Text).Value = uo.ShipRegionTextBox.Text;
                    cmd.Parameters.Add("@shipPostalCode", SqlDbType.Text).Value = uo.ShipPostalTextBox.Text;
                    cmd.Parameters.Add("@shipCountry", SqlDbType.Text).Value = uo.ShipCountryTextBox.Text;

                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;

                    cmd.ExecuteNonQuery();
                    conn.Close();
                }

            }
        }
    }
}
