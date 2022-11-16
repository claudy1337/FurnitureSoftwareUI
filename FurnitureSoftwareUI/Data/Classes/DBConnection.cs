using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FurnitureSoftwareUI.Data.Model;
namespace FurnitureSoftwareUI.Data.Classes
{
    internal class DBConnection
    {
        public static SoftwareFurnitureEntities connect = new SoftwareFurnitureEntities();
    }
}
