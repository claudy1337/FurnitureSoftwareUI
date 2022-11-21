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
    internal class DBMethodsFromMaterial
    {
        public static ObservableCollection<InnerMaterial> GetInnerMaterials()
        {
            return new ObservableCollection<InnerMaterial>(DBConnection.connect.InnerMaterial);
        }
        public static ObservableCollection<OuterMaterial> GetOuterMaterials()
        {
            return new ObservableCollection<OuterMaterial>(DBConnection.connect.OuterMaterial);
        }
        public static InnerMaterial GetInnerMaterial(string name)
        {
            return GetInnerMaterials().FirstOrDefault(i=>i.Name == name);
        }
        public static OuterMaterial GetOuterMaterial(string name)
        {
            return GetOuterMaterials().FirstOrDefault(o=>o.Name == name);
        }
        public static void AddOuter(string name, int price)
        {
            var getOuter = GetOuterMaterial(name);
            if (getOuter == null)
            {
                OuterMaterial outer = new OuterMaterial
                {
                    Name = name,
                    Price = price
                };
                DBConnection.connect.OuterMaterial.Add(outer);
                DBConnection.connect.SaveChanges();
                MessageBox.Show("add");
            }
            else
            {
                MessageBox.Show("this material already exists");
                return;
            }
        }
        public static void AddInner(string name, int price)
        {
            var getInner = GetInnerMaterial(name);
            if (getInner == null)
            {
                InnerMaterial inner = new InnerMaterial
                {
                    Name = name,
                    Price = price
                };
                DBConnection.connect.InnerMaterial.Add(inner);
                DBConnection.connect.SaveChanges();
                MessageBox.Show("add");
            }
            else
            {
                MessageBox.Show("this material already exists");
                return;
            }
        }
    }
}
