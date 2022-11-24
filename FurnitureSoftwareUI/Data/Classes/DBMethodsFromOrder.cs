using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using FurnitureSoftwareUI.Data.Classes;
using FurnitureSoftwareUI.Data.Model;

namespace FurnitureSoftwareUI.Data.Classes
{
    internal class DBMethodsFromOrder
    {
        public static ObservableCollection<OrderProduct> GetOrderProducts()
        {
            return new ObservableCollection<OrderProduct>(DBConnection.connect.OrderProduct);
        }
        public static int PriceOrderProduct(int price)
        {
            int oldpeice = (price * 10) / 100;
            return price - oldpeice;
        }
        public static Product GetProduct(string name)
        {
            return DBMethodsFromProducts.GetProducts().FirstOrDefault(p=>p.Name == name);
        }
        public static void EditCount(Product product, int count)
        {
            product.Count -= count;
            DBConnection.connect.SaveChanges();
        }
        public static void AddProductOrder(Product product, int count, string price, int idDiscount, int idClient, bool isActual = true)
        {
            DiscountClient discountClient = new DiscountClient
            {
                idClient = idClient,
                idDiscount = idDiscount,
                isActual = isActual
            };
            DBConnection.connect.DiscountClient.Add(discountClient);
            DBConnection.connect.SaveChanges();
            var getProduct = GetProduct(product.Name);
            OrderProduct orderProduct = new OrderProduct
            {
                date = DateTime.Now,
                Price = price,
                Count = count,
                idProduct = product.id,
                idDiscountClient = discountClient.id

            };
            DBConnection.connect.OrderProduct.Add(orderProduct);
            DBConnection.connect.SaveChanges();
            MessageBox.Show("buying");
        }

    }
}
