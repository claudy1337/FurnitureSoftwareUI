using FurnitureSoftwareUI.Data.Classes;
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

namespace FurnitureSoftwareUI.Windws
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public Registration()
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

        private void txtAuth_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Auth auth = new Auth();
            auth.Show();
            this.Close();
        }

        private void btnReg_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPassword.Password) || string.IsNullOrWhiteSpace(txtLogin.Text) || string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("data is not complete");
                return;
            }
            else
            {
                if (DBMethodsFromUser.isСorrectUserData(txtLogin.Text, txtPassword.Password) == false)
                {
                    DBMethodsFromUser.AddAuthorization(txtLogin.Text, txtPassword.Password);
                    DBMethodsFromUser.AddClient(txtName.Text);
                    MainWindow main = new MainWindow(DBMethodsFromUser.CurrentClient);
                    MessageBox.Show($"Welcome: {DBMethodsFromUser.CurrentClient.Name}");
                    main.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("данные уже есть!");
                }
            }
        }
    }
}
