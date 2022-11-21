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

namespace FurnitureSoftwareUI.Pages.Provider
{
    /// <summary>
    /// Логика взаимодействия для ApplicationPage.xaml
    /// </summary>
    public partial class ApplicationPage : Page
    {
        public ApplicationPage()
        {
            InitializeComponent();
            BindingData();
        }
        private void BindingData()
        {
            lstvConfigurate.ItemsSource = DBConnection.connect.Configurator.ToList();
            cbInner.ItemsSource = DBConnection.connect.InnerMaterial.ToList();
            cbOuter.ItemsSource = DBConnection.connect.OuterMaterial.ToList();
        }
        private void cbInner_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedInner = cbInner.SelectedItem as InnerMaterial;
            var selectedOuter = cbOuter.SelectedItem as OuterMaterial;
            txtInner.Text = "Price: " + selectedInner.Price;
            if (cbOuter.SelectedIndex == -1)
            {
                lstvConfigurate.ItemsSource = DBConnection.connect.Configurator.Where(c=>c.idInner == selectedInner.id).ToList();
            }
            else
            {
                lstvConfigurate.ItemsSource = DBConnection.connect.Configurator.Where(c => c.idInner == selectedInner.id && c.idOuter == selectedOuter.id).ToList();
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            var selectedInner = cbInner.SelectedItem as InnerMaterial;
            var selectedOuter = cbOuter.SelectedItem as OuterMaterial;
            if (cbInner.SelectedIndex == -1 || cbOuter.SelectedIndex == -1  || string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Fill in all the fields");
                return;
            }
            else
            {
                DBMethodsFromConfigurate.AddConfigurator(selectedOuter, selectedInner, txtName.Text);
                NavigationService.Navigate(new ApplicationPage());
            }
        }

        private void cbOuter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedInner = cbInner.SelectedItem as InnerMaterial;
            var selectedOuter = cbOuter.SelectedItem as OuterMaterial;
            txtOuter.Text = "Price: " + selectedOuter.Price;
            if (cbInner.SelectedIndex == -1)
            {
                lstvConfigurate.ItemsSource = DBConnection.connect.Configurator.Where(c => c.idOuter == selectedOuter.id).ToList();
            }
            else
            {
                lstvConfigurate.ItemsSource = DBConnection.connect.Configurator.Where(c => c.idInner == selectedInner.id && c.idOuter == selectedOuter.id).ToList();
            }
        }

        private void txtName_TextChanged(object sender, TextChangedEventArgs e)
        {
            lstvConfigurate.ItemsSource = DBConnection.connect.Configurator.Where(c=>c.Name == txtName.Text).ToList();
        }

        private void txtAddMaterial_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new AddMaterialPage());
        }
    }
}
