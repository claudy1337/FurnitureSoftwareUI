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
using System.Diagnostics;

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
            if (DBMethodsFromUser.GetAdminRole(Client.Authorization.Login) == true)
            {
                btnAdd.Visibility = Visibility.Hidden;
                txtAddConfigurate.Visibility = Visibility.Hidden;
                txtAddType.Visibility = Visibility.Hidden;
            }
            BindingData();
        }
        private void BindingData()
        {
            cbTypeProduct.ItemsSource = DBConnection.connect.ProductType.ToList();
            lstvProduct.ItemsSource = DBConnection.connect.Product.ToList();
            cbConfigurator.ItemsSource = DBConnection.connect.Configurator.ToList();
        }
        
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Provider.AddProductPage(null, Client));
        }

        private void txtName_TextChanged(object sender, TextChangedEventArgs e)
        {
            lstvProduct.ItemsSource = DBMethodsSorting.GetProductsName(txtName.Text);
            txtPrice.Text = null;
            cbConfigurator.SelectedIndex = -1;
            cbTypeProduct.SelectedIndex = -1;
        }

        private void txtPrice_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                var selectTypeProduct = cbTypeProduct.SelectedItem as ProductType;
                var selectConfigurator = cbConfigurator.SelectedItem as Configurator;
                if (selectConfigurator == null && selectTypeProduct == null)
                {
                    lstvProduct.ItemsSource = DBMethodsSorting.GetProductsPrice(Convert.ToInt32(txtPrice.Text));
                }
                else if (selectConfigurator == null)
                {
                    lstvProduct.ItemsSource = DBMethodsSorting.GetProductsPriceOrType(selectTypeProduct.id, Convert.ToInt32(txtPrice.Text));
                }
                else if (selectTypeProduct == null)
                {
                    lstvProduct.ItemsSource = DBMethodsSorting.GetProductsPriceOrConfigurate(selectConfigurator.id, Convert.ToInt32(txtPrice.Text));
                }
                else
                {
                    lstvProduct.ItemsSource = DBMethodsSorting.GetProductsAllSort(selectConfigurator.id, Convert.ToInt32(txtPrice.Text), selectTypeProduct.id);
                }

            }
            catch (NullReferenceException)
            {
                return;
            }
           

        }
        private void cbTypeProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var selectTypeProduct = cbTypeProduct.SelectedItem as ProductType;
                var selectConfigurator = cbConfigurator.SelectedItem as Configurator;
                if (string.IsNullOrWhiteSpace(txtPrice.Text) && selectConfigurator == null)
                {
                    lstvProduct.ItemsSource = DBMethodsSorting.GetProductsType(selectTypeProduct.id);
                }
                else if (selectConfigurator == null)
                {
                    lstvProduct.ItemsSource = DBMethodsSorting.GetProductsPriceOrType(selectTypeProduct.id, Convert.ToInt32(txtPrice.Text));
                }
                else if (string.IsNullOrWhiteSpace(txtPrice.Text))
                {
                    lstvProduct.ItemsSource = DBMethodsSorting.GetProductsTypeOrConfigurator(selectConfigurator.id, selectTypeProduct.id);
                }
                else
                {
                    lstvProduct.ItemsSource = DBMethodsSorting.GetProductsAllSort(selectConfigurator.id, Convert.ToInt32(txtPrice.Text), selectTypeProduct.id);
                }
            }
            catch (NullReferenceException)
            {
                return;
            }
            
        }
        private void cbConfigurator_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var selectTypeProduct = cbTypeProduct.SelectedItem as ProductType;
                var selectConfigurator = cbConfigurator.SelectedItem as Configurator;
                if (string.IsNullOrWhiteSpace(txtPrice.Text) && selectTypeProduct == null)
                {
                    lstvProduct.ItemsSource = DBMethodsSorting.GetProductsConfigurator(selectConfigurator.id);
                }
                else if (selectTypeProduct == null)
                {
                    lstvProduct.ItemsSource = DBMethodsSorting.GetProductsPriceOrConfigurate(selectConfigurator.id, Convert.ToInt32(txtPrice.Text));
                }
                else if (string.IsNullOrWhiteSpace(txtPrice.Text))
                {
                    lstvProduct.ItemsSource = DBMethodsSorting.GetProductsTypeOrConfigurator(selectConfigurator.id, selectTypeProduct.id);
                }
                else
                {
                    lstvProduct.ItemsSource = DBMethodsSorting.GetProductsAllSort(selectConfigurator.id, Convert.ToInt32(txtPrice.Text), selectTypeProduct.id);
                }
            }
            catch(NullReferenceException)
            {
                return;
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
        private void txtAddConfigurate_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new ApplicationPage());
        }

        private void lstvProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DBMethodsFromUser.GetAdminRole(Client.Authorization.Login) == false)
            {
                var selectProduct = lstvProduct.SelectedItem as Product;
                NavigationService.Navigate(new AddProductPage(selectProduct, Client));
            }
                
        }
    }
}
