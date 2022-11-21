using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using FurnitureSoftwareUI.Data.Classes;
using FurnitureSoftwareUI.Data.Model;

namespace FurnitureSoftwareUI.Data.Classes
{
    internal class DBMethodsFromConfigurate
    {
        public static ObservableCollection<Configurator> GetConfigurators()
        {
            return new ObservableCollection<Configurator>(DBConnection.connect.Configurator);
        }
        public static Configurator GetConfigurator(int idOuter, int idInner)
        {
            return GetConfigurators().FirstOrDefault(c=>c.idOuter == idOuter && c.idInner == idInner);
        }
        public static Configurator GetConfigurator(string name)
        {
            return GetConfigurators().FirstOrDefault(c => c.Name == name);
        }
        public static void AddConfigurator(OuterMaterial outer, InnerMaterial inner, string name)
        {
            var getConfigurator = GetConfigurator(name);
            int price = PriceConfigurate(outer, inner);
            if (getConfigurator == null)
            {
                Configurator configurator = new Configurator
                {
                    idInner = inner.id,
                    idOuter = outer.id,
                    Name = name,
                    Price = price
                };
                DBConnection.connect.Configurator.Add(configurator);
                DBConnection.connect.SaveChanges();
                MessageBox.Show("configuration add");
            }
            else
            {
                MessageBox.Show("already have this configuration");
                return;
            }
        }
        public static int PriceConfigurate(OuterMaterial outer, InnerMaterial inner)
        {
            int price = outer.Price + inner.Price;
            price += (price * 10 ) / 100;
            return price;
        }
    }
}
