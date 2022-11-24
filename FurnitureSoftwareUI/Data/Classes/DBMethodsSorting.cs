using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FurnitureSoftwareUI.Data.Classes;
using FurnitureSoftwareUI.Data.Model;

namespace FurnitureSoftwareUI.Data.Classes
{
    internal class DBMethodsSorting
    {
        public static IEnumerable<Product> GetProductsName(string name)
        {
            return DBMethodsFromProducts.GetProducts().Where(p=>p.Name == name).ToList();
        }
        public static IEnumerable<Product> GetProductsPrice(int price)
        {
            return DBMethodsFromProducts.GetProducts().Where(p=> Convert.ToInt32(p.Configurator.Price) == price).ToList();
        }
        public static IEnumerable<Product> GetProductsType(int idType)
        {
            return DBMethodsFromProducts.GetProducts().Where(p => p.ProductType.id == idType).ToList();
        }
        public static IEnumerable<Product> GetProductsConfigurator(int idConfigurator)
        {
            return DBMethodsFromProducts.GetProducts().Where(p => p.Configurator.id == idConfigurator).ToList();
        }
        public static IEnumerable<Product> GetProductsTypeOrConfigurator(int idConfigurator, int idType)
        {
            return DBMethodsFromProducts.GetProducts().Where(p => p.Configurator.id == idConfigurator && p.ProductType.id == idType).ToList();
        }
        public static IEnumerable<Product> GetProductsPriceOrType(int idType, int price)
        {
            return DBMethodsFromProducts.GetProducts().Where(p=> Convert.ToInt32(p.Configurator.Price) == price && p.ProductType.id == idType).ToList();
        }
        public static IEnumerable<Product> GetProductsPriceOrConfigurate(int idConfigurator, int price)
        {
            return DBMethodsFromProducts.GetProducts().Where(p => Convert.ToInt32(p.Configurator.Price) == price && p.Configurator.id == idConfigurator).ToList();
        }
        public static IEnumerable<Product> GetProductsAllSort(int idConfigurator, int price, int idType)
        {
            return DBMethodsFromProducts.GetProducts().Where(p => Convert.ToInt32(p.Configurator.Price) == price && p.Configurator.id == idConfigurator && p.ProductType.id == idType).ToList();
        }
    }
}
