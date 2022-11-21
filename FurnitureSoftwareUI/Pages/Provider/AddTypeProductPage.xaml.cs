using System;
using System.Collections.Generic;
using System.IO;
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
using Microsoft.Win32;

namespace FurnitureSoftwareUI.Pages.Provider
{
    /// <summary>
    /// Логика взаимодействия для AddTypeProductPage.xaml
    /// </summary>
    public partial class AddTypeProductPage : Page
    {
        byte[] image;
        public AddTypeProductPage()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) || image == null)
            {
                MessageBox.Show("Fill in all the fields");
                return;
            }
            else
            {
                DBMethodsFromTypeProduct.AddProductType(txtName.Text, image);
                NavigationService.Navigate(new AddTypeProductPage());
            }
            
        }

        private void imgType_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.FilterIndex = 1;
            if (ofd.ShowDialog() == true)
            {
                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.UriSource = new Uri(ofd.FileName);
                bitmapImage.EndInit();
                image = File.ReadAllBytes(ofd.FileName);
                imgType.Source = bitmapImage;
            }
        }
    }
}
