using FurnitureSoftwareUI.Data.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using FurnitureSoftwareUI.Data.Classes;

namespace FurnitureSoftwareUI.Data.Classes
{
    internal class DBMethodsFromProducts
    {
        public static Product Product;
        public static ProductsImage ProdctImages;
        public static ObservableCollection<Product> GetProducts()
        {
            return new ObservableCollection<Product>(DBConnection.connect.Product);
        }
        public static ObservableCollection<ProductsImage> GetProductsImages()
        {
            return new ObservableCollection<ProductsImage>(DBConnection.connect.ProductsImage);
        }
        public static Product GetProduct(string name)
        {
            return GetProducts().FirstOrDefault(p => p.Name == name);
        }
        public static IEnumerable<Product> GetProducts(int idType, bool isAcive = true)
        {
            return GetProducts().Where(p => p.idType == idType && p.isActual == isAcive && p.Count > 0).ToList();
        }
        public static IEnumerable<Product> GetProducts(string name)
        {
            return GetProducts().Where(p => p.Name == name && p.isActual == true && p.Count == 0).ToList();
        }
        public static ProductsImage GetProductsImage(string code)
        {
            return GetProductsImages().FirstOrDefault(i=>i.Code == code);
        }
        public static void AddImageProduct(byte[] image1, byte[] image2, byte[] image3)
        {
            ProductsImage prodct = new ProductsImage
            {
                Image1 = image1,
                Image2 = image2,
                Image3 = image3
            };
            DBConnection.connect.ProductsImage.Add(prodct);
            DBConnection.connect.SaveChanges();
            ProdctImages = prodct;

        }
        public static void AddProduct(string name, string description, int idType, int count, bool isActual, int price, int idConfigurator, int idImage)
        {
            try
            {
                var getProduct = GetProduct(name);
                if (getProduct == null)
                {
                    Product product = new Product
                    {
                        Name = name,
                        idConfigurator = idConfigurator,
                        Descrition = description,
                        idType = idType,
                        Count = count,
                        isActual = true,
                        idImage = ProdctImages.id
                    };
                    DBConnection.connect.Product.Add(product);
                    DBConnection.connect.SaveChanges();
                    MessageBox.Show("добавлен");

                }
                else
                {
                    getProduct.Count += count;
                    getProduct.Descrition = description;
                    getProduct.isActual = isActual;
                    DBConnection.connect.SaveChanges();
                }

            }
            catch (FormatException)
            {
                MessageBox.Show("ошибка формата");
                return;
            }
        }
        public static ProductType GetProductTypes(string type)
        {
            ObservableCollection<ProductType> productTypes = new ObservableCollection<ProductType>(DBConnection.connect.ProductType);
            return productTypes.FirstOrDefault(t=>t.Type == type);
        }
    }
}
