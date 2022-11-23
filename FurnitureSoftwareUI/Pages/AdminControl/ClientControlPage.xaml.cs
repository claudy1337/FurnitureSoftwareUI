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

namespace FurnitureSoftwareUI.Pages.AdminControl
{
    /// <summary>
    /// Логика взаимодействия для ClientControlPage.xaml
    /// </summary>
    public partial class ClientControlPage : Page
    {
        public ClientControlPage()
        {
            InitializeComponent();
            BindingData();
        }
        private void BindingData()
        {
            lstvClients.ItemsSource = DBConnection.connect.Client.ToList();
            cbRole.ItemsSource = DBConnection.connect.Role.ToList();
        }
        private void txtSurname_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtLogin_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void cbRole_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLogin.Text) || string.IsNullOrWhiteSpace(txtName.Text)
                || string.IsNullOrWhiteSpace(txtPassword.Text) || cbRole.SelectedIndex == -1)
            {
                MessageBox.Show("Fill in all the fields");
                return;
            }
            else
            {
                if (cbRole.SelectedIndex != 0)
                {
                    var selectRole = cbRole.SelectedItem as Role;
                    DBMethodsFromUser.AddAuthorization(txtLogin.Text, txtPassword.Text);
                    DBMethodsFromUser.AddClient(txtName.Text, selectRole.id);
                    MessageBox.Show("add Account");
                    NavigationService.Navigate(new ClientControlPage());
                }
                else
                {
                    MessageBox.Show("can't set admin role");
                    return;
                }
                
            }
        }

        private void lstvClients_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectClient = lstvClients.SelectedItem as Client;
            NavigationService.Navigate(new AccountPage(selectClient));
        }

        private void txtClear_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new ClientControlPage());
        }

        private void txtName_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }
    }
}
