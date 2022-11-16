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
using System.Windows.Shapes;
using FurnitureSoftwareUI.Data.Model;
using FurnitureSoftwareUI.Data.Classes;

namespace FurnitureSoftwareUI.Windws
{
    /// <summary>
    /// Логика взаимодействия для Auth.xaml
    /// </summary>
    public partial class Auth : Window
    {
        public static Client Client;
        public Auth()
        {
            InitializeComponent();
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

        private void btnAuth_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtLogin.Text) || string.IsNullOrWhiteSpace(txtPassword.Password))
                {
                    MessageBox.Show("данные не полные");
                    return;
                }
                else
                {
                    if (DBMethodsFromUser.isСorrectUserData(txtLogin.Text, txtPassword.Password) == true)
                    {
                        Client = DBMethodsFromUser.GetClient(txtLogin.Text, txtPassword.Password);
                        MainWindow main = new MainWindow(Client);
                        MessageBox.Show($"Welcome: {Client.Name}");
                        main.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("аккаунт не существует");
                    }
                }
            }
            catch(FormatException)
            {
                return;
            }
        }

        private void txtReg_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Registration registration = new Registration();
            registration.Show();
            this.Close();
        }
    }
}
