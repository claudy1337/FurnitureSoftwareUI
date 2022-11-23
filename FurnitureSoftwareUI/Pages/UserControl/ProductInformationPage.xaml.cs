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
    /// Логика взаимодействия для ProductInformationPage.xaml
    /// </summary>
    public partial class ProductInformationPage : Page
    {
        public static Product Product;
        public static Client Client;
        public ProductInformationPage(Product product, Client client)
        {
            Product = product;
            Client = client;
            InitializeComponent();
            this.DataContext = Product;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
