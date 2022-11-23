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
using FurnitureSoftwareUI.Pages.Provider;

namespace FurnitureSoftwareUI.Pages.AdminControl
{
    /// <summary>
    /// Логика взаимодействия для MoreInformation.xaml
    /// </summary>
    public partial class MoreInformation : Page
    {
        public static Client Client;
        public MoreInformation(Client client)
        {
            Client = client;
            InitializeComponent();
        }

        private void BtnClientOrder_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ClientOrderPage());
        }

        private void btnProduct_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ProductControlPage(Client));
        }
    }
}
