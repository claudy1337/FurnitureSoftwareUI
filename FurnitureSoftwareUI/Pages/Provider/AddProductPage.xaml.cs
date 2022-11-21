using FurnitureSoftwareUI.Data.Classes;
using FurnitureSoftwareUI.Data.Model;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
using static System.Net.Mime.MediaTypeNames;

namespace FurnitureSoftwareUI.Pages.Provider
{
    /// <summary>
    /// Логика взаимодействия для AddProductPage.xaml
    /// </summary>
    public partial class AddProductPage : Page
    {
        public static Product Product;
        public static Client Client;
        byte[] image1;
        byte[] image2;
        byte[] image3;
        byte[] type;
        public AddProductPage(Product product, Client client)
        {
            Product = product;
            Client = client;
            InitializeComponent();
            if (Product == null)
            {
                BindingNullDataFurniture();
            }
            else
            {
                BindingNotNullDataFurniture();
            }
            BindingData();
        }
        private void BindingNotNullDataFurniture()
        {
            this.DataContext = Product;
            txtAddOrEdit.Text = "Product Edit";
            cbType.SelectedItem = Product.ProductType.Type;
            btnAdd.Content = "Edit";
            txtPrice.Text = $"{Product.Configurator.Price}";
            cbConfigurate.SelectedIndex = Product.Configurator.id;
            cbType.SelectedIndex = Product.ProductType.id;
            cbIsActive.IsChecked = Product.isActual;
        }
        private void BindingNullDataFurniture()
        {
            imgFurniture1.Source = new BitmapImage(new Uri("/Resources/furniture.png",UriKind.RelativeOrAbsolute));
            imgFurniture2.Source = new BitmapImage(new Uri("/Resources/furniture.png",UriKind.RelativeOrAbsolute));
            imgFurniture3.Source = new BitmapImage(new Uri("/Resources/furniture.png",UriKind.RelativeOrAbsolute));
            imgType.Source = new BitmapImage(new Uri("/Resources/type.png", UriKind.RelativeOrAbsolute));
            txtName.IsReadOnly = true;
            txtCode.IsReadOnly = true;
            txtAddOrEdit.Text = "Product Add";
            btnAdd.Content = "Add";
        }
        private void BindingData()
        {
            cbConfigurate.ItemsSource = DBConnection.connect.Configurator.ToList();
            cbType.ItemsSource = DBConnection.connect.ProductType.ToList();
        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            var selectedType = cbType.SelectedItem as ProductType;
            var selectedConfigurate = cbConfigurate.SelectedItem as Configurator;
            DBMethodsFromProducts.AddImageProduct(image1, image2, image3, txtCode.Text); //image edit
            var getImage = DBMethodsFromProducts.GetProductsImage(txtCode.Text);
            if (Product == null)
            {
                if (string.IsNullOrWhiteSpace(txtCount.Text) || string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtPrice.Text))
                {
                    MessageBox.Show("data is not complete");
                    return;
                }
                else
                {

                    DBMethodsFromProducts.AddProduct(txtCode.Text, txtName.Text, txtDescrition.Text, selectedType.id, Convert.ToInt32(txtCount.Text), Convert.ToBoolean(cbIsActive.IsChecked), Convert.ToInt32(selectedConfigurate.Price), selectedConfigurate.id);
                    NavigationService.Navigate(new ProductControlPage(Client));
                }
            }
            else
            {
                DBMethodsFromProducts.EditProduct(Product, Convert.ToInt32(txtCount.Text), Convert.ToBoolean(cbIsActive.IsChecked), txtDescrition.Text);
            }
        }
        private void txtCount_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        private void imgFurniture1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.FilterIndex = 1;
            if (ofd.ShowDialog() == true)
            {
                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.UriSource = new Uri(ofd.FileName);
                bitmapImage.EndInit();
                image1 = File.ReadAllBytes(ofd.FileName);
                imgFurniture1.Source = bitmapImage;
            }
        }
        private void imgFurniture2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.FilterIndex = 1;
            if (ofd.ShowDialog() == true)
            {
                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.UriSource = new Uri(ofd.FileName);
                bitmapImage.EndInit();
                image2 = File.ReadAllBytes(ofd.FileName);
                imgFurniture2.Source = bitmapImage;
            }
        }
        private void imgFurniture3_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.FilterIndex = 1;
            if (ofd.ShowDialog() == true)
            {
                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.UriSource = new Uri(ofd.FileName);
                bitmapImage.EndInit();
                image3 = File.ReadAllBytes(ofd.FileName);
                imgFurniture3.Source = bitmapImage;
            }
        }

        private void cbType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectType = cbType.SelectedItem as ProductType;
           // imgType.Source = new BitmapImage(new Uri(selectType.Image, UriKind.RelativeOrAbsolute));
        }

        private void cbConfigurate_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedConfigurate = cbConfigurate.SelectedItem as Configurator;
            txtPrice.Text = $"{selectedConfigurate.Price}";
        }
    }
}
