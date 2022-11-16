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
            if (cbRole.SelectedIndex == -1 || string.IsNullOrWhiteSpace(txtLogin.Text) || string.IsNullOrWhiteSpace(txtName.Text) ||
                string.IsNullOrWhiteSpace(txtLastName.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {

            }
        }
    }
}
