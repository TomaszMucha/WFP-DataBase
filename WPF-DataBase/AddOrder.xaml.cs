using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using WpfApplication3.Model;

namespace WpfApplication3
{
    /// <summary>
    /// Interaction logic for AddOrder.xaml
    /// </summary>
    public partial class AddOrder : Window
    {
        public AddOrder()
        {
            InitializeComponent();
            this.OrderDateDatePicker.SelectedDate = DateTime.Now;
            this.RequiredDateDatePicker.SelectedDate = DateTime.Now;
            this.ShippedDateDatePicker.SelectedDate = DateTime.Now;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Order order = new Order(OrderDateDatePicker.SelectedDate.Value.Date, RequiredDateDatePicker.SelectedDate.Value.Date,
                                    ShippedDateDatePicker.SelectedDate.Value.Date, 3, Decimal.Parse($"FreightTextBox.Text:C2"),
                                    ShipNameTextBox.Text, ShipAddressTextBox.Text, ShipCityTextBox.Text, ShipRegionTextBox.Text,
                                    ShipPostalTextBox.Text, ShipCountryTextBox.Text);

            Services.DataBaseOperation.AddOrder(order);
            Close();
        }
    }
}
