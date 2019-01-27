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
    }
}
