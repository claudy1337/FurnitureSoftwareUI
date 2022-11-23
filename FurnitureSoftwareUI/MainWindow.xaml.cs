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
using FurnitureSoftwareUI.Pages;
using FurnitureSoftwareUI.Windws;
using FurnitureSoftwareUI.Data.Classes;
using FurnitureSoftwareUI.Data.Model;
using FurnitureSoftwareUI.Pages.AdminControl;
using FurnitureSoftwareUI.Pages.UserControl;
using FurnitureSoftwareUI.Pages.Provider;

namespace FurnitureSoftwareUI
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Client CurrentClient;
        public MainWindow(Client currentClient)
        {
            CurrentClient = currentClient;
            InitializeComponent();
            FrameContainer.Navigate(new AccountPage(CurrentClient));
            if (DBMethodsFromUser.GetAdminRole(CurrentClient.Authorization.Login) == true)
            {
                btnClientControl.Visibility = Visibility.Visible;
                btnMoreInformation.Visibility = Visibility.Visible;
                txtAdmin.Visibility = Visibility.Visible;
            }
            else if (DBMethodsFromUser.GetProviderRole(CurrentClient.Authorization.Login) == true)
            {
                btnProductControl.Visibility = Visibility.Visible;
                btnApp.Visibility = Visibility.Visible;
                txtProvider.Visibility = Visibility.Visible;
                btnMarket.Visibility = Visibility.Hidden;
                txtHome.Visibility = Visibility.Hidden;
                btnDiscount.Visibility = Visibility.Hidden;
            }
            else
            {
                txtHome.Visibility = Visibility.Visible;
                btnDiscount.Visibility = Visibility.Visible;
                btnMarket.Visibility = Visibility.Visible;
                btnMarket.Visibility = Visibility.Visible;
            }
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (e.ChangedButton == MouseButton.Left)
                    this.DragMove();
            }
            catch (System.InvalidOperationException)
            {
                return;
            }
        }
        private void clClose_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        private void clMinus_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void clLogOut_Click(object sender, RoutedEventArgs e)
        {
            Auth auth = new Auth();
            auth.Show();
            this.Close();
        }

        private void btnAccount_Click(object sender, RoutedEventArgs e)
        {
            FrameContainer.Navigate(new AccountPage(CurrentClient));
        }

        private void btnMarket_Click(object sender, RoutedEventArgs e)
        {
            FrameContainer.Navigate(new ProductControlPage(CurrentClient));
        }

        private void btnProductControl_Click(object sender, RoutedEventArgs e)
        {
            FrameContainer.Navigate(new ProductControlPage(CurrentClient));
        }

        private void btnApp_Click(object sender, RoutedEventArgs e)
        {
            FrameContainer.Navigate(new ApplicationPage());
        }

        private void btnClientControl_Click(object sender, RoutedEventArgs e)
        {
            FrameContainer.Navigate(new ClientControlPage());
        }

        private void btnMoreInformation_Click(object sender, RoutedEventArgs e)
        {
            FrameContainer.Navigate(new MoreInformation(CurrentClient));
        }

        private void btnDiscount_Click(object sender, RoutedEventArgs e)
        {
            FrameContainer.Navigate(new ActionСhoosePage(CurrentClient));
        }
    }
}
