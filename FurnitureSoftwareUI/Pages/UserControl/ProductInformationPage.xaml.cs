using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            cbDiscount.ItemsSource = DBConnection.connect.Discount.Where(d => d.isActual == true).ToList();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txtCount.Text) || cbDiscount.SelectedIndex == -1)
            {
                MessageBox.Show("count is 0");
                return;
            }
            else
            {
                var selectDiscount = cbDiscount.SelectedItem as Discount;
                int price = DBMethodsFromOrder.PriceOrderProduct(Convert.ToInt32(Product.Configurator.Price));
                DBMethodsFromOrder.AddProductOrder(Product, Convert.ToInt32(txtCount.Text), price.ToString(), selectDiscount.id, Client.id);
                DBMethodsFromOrder.EditCount(Product, Convert.ToInt32(txtCount.Text));
                NavigationService.Navigate(new ProductControlPage(Client));

            }
        }

        private void txtCount_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void cbDiscount_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectDiscount = cbDiscount.SelectedItem as Discount;
            Txtprocent.Text = $"Procent: {selectDiscount.Value}";
        }
    }
}
