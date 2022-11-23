using FurnitureSoftwareUI.Data.Model;
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
using System.Text.RegularExpressions;

namespace FurnitureSoftwareUI.Pages
{
    /// <summary>
    /// Логика взаимодействия для AccountPage.xaml
    /// </summary>
    public partial class AccountPage : Page
    {
        public static Client Client;
        public AccountPage(Client client)
        {
            Client = client;
            InitializeComponent();
            if (DBMethodsFromUser.GetProviderRole(Client.Authorization.Login) == true)
            {
                txtBalance.Visibility = Visibility.Hidden;
                txtStat.Visibility = Visibility.Hidden;
                cbRole.IsReadOnly = true;
                cbRole.IsEnabled = false;
            }
            else if (DBMethodsFromUser.GetUserRole(Client.Authorization.Login) == true)
            {
                cbRole.IsEnabled = false;
            }
            BindingData();
        }
        private void BindingData()
        {
            this.DataContext = Client;
            cbRole.ItemsSource = DBConnection.connect.Role.ToList();
            cbRole.SelectedIndex = Client.idRole;
        }
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (cbRole.SelectedIndex == -1 || string.IsNullOrWhiteSpace(txtLogin.Text) || string.IsNullOrWhiteSpace(txtName.Text) ||
                string.IsNullOrWhiteSpace(txtLastName.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    MessageBox.Show("Fill in all the fields");
                    return;
                }
                else
                {
                    DBMethodsFromUser.EditClient(Client, txtPassword.Text, txtName.Text, txtLastName.Text, Convert.ToInt32(txtBalance.Text));
                }
            }
            catch(FormatException)
            {
                return;
            }
        }

        private void imgAccount_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DBMethodsFromUser.EditImageClient(Client);
            NavigationService.Navigate(new AccountPage(Client));
        }

        private void txtBalance_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[0-9]");
        }
    }
}
