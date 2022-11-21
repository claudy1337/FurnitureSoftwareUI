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
using FurnitureSoftwareUI.Data.Model;
using FurnitureSoftwareUI.Data.Classes;
using FurnitureSoftwareUI.Pages;

namespace FurnitureSoftwareUI.Pages.Provider
{
    /// <summary>
    /// Логика взаимодействия для ProductControlPage.xaml
    /// </summary>
    public partial class ProductControlPage : Page
    {
        public static Client Client;
        public ProductControlPage(Client client)
        {
            Client = client;
            InitializeComponent();
            BindingData();
        }
        private void BindingData()
        {
            cbTypeProduct.ItemsSource = DBConnection.connect.ProductType.ToList();
            lstvProduct.ItemsSource = DBConnection.connect.Product.Where(p=>p.isActual == true && p.Count>0).ToList();
        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Provider.AddProductPage(null, Client));
        }

        private void txtName_TextChanged(object sender, TextChangedEventArgs e)
        {
            //sort
        }

        private void txtPrice_TextChanged(object sender, TextChangedEventArgs e)
        {
            //sort
        }
        private void cbTypeProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) && string.IsNullOrWhiteSpace(txtPrice.Text))
                //sort type
                return;
            else if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                //sort price & type
            }
            else if (string.IsNullOrWhiteSpace(txtPrice.Text))
            {
                //sort name & type
            }
            else
            {
                //all sort
            }
        }
        private void txtClear_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new ProductControlPage(Client));
        }

        private void txtAddType_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new Provider.AddTypeProductPage());
        }

        private void cbConfigurator_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void txtAddConfigurate_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new ApplicationPage());
        }

        private void lstvProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectProduct = lstvProduct.SelectedItem as Product;
            NavigationService.Navigate(new AddProductPage(selectProduct, Client));
        }
    }
}
