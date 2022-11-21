using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using FurnitureSoftwareUI.Data.Classes;
using FurnitureSoftwareUI.Data.Model;

namespace FurnitureSoftwareUI.Data.Classes
{
    internal class DBMethodsFromProduct
    {
        public static ObservableCollection<Product> GetProducts()
        {
            return new ObservableCollection<Product>(DBConnection.connect.Product);
        }
        public static ObservableCollection<ProductType> GetProductTypes()
        {
            return new ObservableCollection<ProductType>(DBConnection.connect.ProductType);
        }
        public static ProductType GetProductType(string type)
        {
            return GetProductTypes().FirstOrDefault(t=>t.Type == type);
        }
        public static void AddProductType(string type, byte[] image)
        {
            var getProductType = GetProductType(type);
            if (getProductType == null)
            {
                ProductType productType = new ProductType
                {
                    Type = type,
                    Image = image
                };
                DBConnection.connect.ProductType.Add(productType);
                DBConnection.connect.SaveChanges();
                MessageBox.Show("add new type");
            }
            else
            {
                MessageBox.Show("this type already exists.");
                return;
            }
        }

    }
}
