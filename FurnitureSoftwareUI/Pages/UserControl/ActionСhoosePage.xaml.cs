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
    /// Логика взаимодействия для ActionСhoosePage.xaml
    /// </summary>
    public partial class ActionСhoosePage : Page
    {
        public static Client Client;
        public ActionСhoosePage(Client client)
        {
            Client = client;
            InitializeComponent();
        }

        private void BtnDiscount_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new DiscountPage());
        }
        private void BtnOrder_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new OrderClientPage(Client));
        }
    }
}
