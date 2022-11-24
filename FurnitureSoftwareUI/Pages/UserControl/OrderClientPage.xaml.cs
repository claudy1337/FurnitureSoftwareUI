using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using FurnitureSoftwareUI.Data.Classes;
using FurnitureSoftwareUI.Data.Model;

namespace FurnitureSoftwareUI.Pages.UserControl
{
    /// <summary>
    /// Логика взаимодействия для OrderClientPage.xaml
    /// </summary>
    public partial class OrderClientPage : Page
    {
        public static Client Client;
        public OrderClientPage(Client client)
        {
            Client = client;
            InitializeComponent();
            if (DBMethodsFromUser.GetAdminRole(Client.Authorization.Login) == true)
            {
                lstvOrderClient.ItemsSource = DBConnection.connect.OrderProduct.ToList();
            }
            else if (DBMethodsFromUser.GetUserRole(Client.Authorization.Login) == true)
            {
                lstvOrderClient.ItemsSource = DBConnection.connect.OrderProduct.Where(p=>p.DiscountClient.idClient == Client.id).ToList();
            }
        }
    }
}
