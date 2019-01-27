using System;
using System.Windows;

namespace WpfApplication3.Model
{
    class Order
    {

        private int customerID;
        private int employeeID;
        private DateTime orderDate;
        private DateTime requredDate;
        private DateTime shippedDate;
        private int shipVia;
        private decimal freight;
        private string shipName;
        private string shipAddress;
        private string shipCity;
        private string shipRegion;
        private string shipPostalCode;
        private string shipCountry;

        #region get/set
        public int CustomerID
        {
            get
            {
                return customerID;
            }
            set
            {
                customerID = value;
            }
        }

        public int EmployeeID
        {
            get
            {
                return employeeID;
            }
            set
            {
                employeeID = value;
            }
        }

        public DateTime OrderDate
        {
            get
            {
                return orderDate;
            }
            set
            {
                if (orderDate!=null)
                {
                    orderDate = value;
                }
                else
                {
                    MessageBox.Show("Order date can not by empty");
                }
            }
        }

        public DateTime RequredDate
        {
            get
            {
                return requredDate;
            }
            set
            {
                if (requredDate != null)
                {
                    requredDate = value;
                }
                else
                {
                    MessageBox.Show("Requred date can not by empty");
                }
            }
        }

        public DateTime ShippedDate
        {
            get
            {
                return shippedDate;
            }
            set
            {
                if (shippedDate != null)
                {
                    shippedDate = value;
                }
                else
                {
                    MessageBox.Show(" date can not by empty");
                }
            }
        }

        public int ShipVia
        {
            get
            {
                return shipVia;
            }
            set
            {
                if (shipVia != 0)
                {
                    shipVia = value;
                }
                else
                {
                    MessageBox.Show(" This value can not be 0");
                }
            }
        }

        public decimal Freight
        {
            get
            {
                return freight;
            }
            set
            {
                if (freight != 0)
                {
                    freight = Freight;
                }
                else
                {
                    MessageBox.Show(" Freight can not be 0");
                }
            }
        }

        public string ShipName
        {
            get
            {
                return shipName;
            }
            set
            {
                if (shipName != null)
                {
                    shipName = value;
                }
                else
                {
                    MessageBox.Show(" Ship name can not be empty");
                }
            }
        }

        public string ShipAddress
        {
            get
            {
                return shipAddress;
            }
            set
            {
                if (shipAddress != null)
                {
                    shipAddress = value;
                }
                else
                {
                    MessageBox.Show(" Ship address can not be empty");
                }
            }
        }

        public string ShipCity
        {
            get
            {
                return shipCity;
            }
            set
            {
                if (shipCity != null)
                {
                    shipCity = value;
                }
                else
                {
                    MessageBox.Show(" Ship city can not be empty");
                }
            }
        }

        public string ShipRegion
        {
            get
            {
                return shipRegion;
            }
            set
            {
                if (shipRegion != null)
                {
                    shipRegion = value;
                }
                else
                {
                    MessageBox.Show(" Ship region can not be empty");
                }
            }
        }

        public string ShipPostalCode
        {
            get
            {
                return shipPostalCode;
            }
            set
            {
                if (shipPostalCode != null)
                {
                    shipPostalCode = value;
                }
                else
                {
                    MessageBox.Show(" Ship postal code can not be empty");
                }
            }
        }

        public string ShipCountry
                    {
            get
            {
                return shipCity;
            }
            set
            {
                if (shipCity != null)
                {
                    shipCity = value;
                }
                else
                {
                    MessageBox.Show(" ShipCity can not be empty");
                }
            }
        }
        #endregion

        public Order(DateTime OrderDate, DateTime RequredDate, DateTime ShippedDate, 
                     int ShipVia, decimal Freight, string ShipName, string ShipAddress, 
                     string ShipCity, string ShipRegion, string ShipPostalCode, string ShipCountry)
        {
            orderDate = OrderDate;
            requredDate = RequredDate;
            shippedDate = ShippedDate;
            shipVia = ShipVia;
            freight = Freight;
            shipName = ShipName;
            shipAddress = ShipAddress;
            shipCity = ShipCity;
            shipRegion = ShipRegion;
            shipPostalCode = ShipPostalCode;
            shipCountry = ShipCountry;
        }
    }
}
