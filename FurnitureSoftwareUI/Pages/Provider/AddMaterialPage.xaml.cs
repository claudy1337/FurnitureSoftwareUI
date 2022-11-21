using FurnitureSoftwareUI.Data.Classes;
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

namespace FurnitureSoftwareUI.Pages.Provider
{
    /// <summary>
    /// Логика взаимодействия для AddMaterialPage.xaml
    /// </summary>
    public partial class AddMaterialPage : Page
    {
        public AddMaterialPage()
        {
            InitializeComponent();
        }

        private void btnAddInner_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNameInner.Text) || string.IsNullOrWhiteSpace(txtPriceInner.Text))
            {
                MessageBox.Show("Fill in all the fields");
                return;
            }
            else
            {
                DBMethodsFromMaterial.AddInner(txtNameInner.Text, Convert.ToInt32(txtPriceInner.Text));
                UpdateInner();
            }
        }

        private void btnAddOuter_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNameOuter.Text) || string.IsNullOrWhiteSpace(txtPriceOuter.Text))
            {
                MessageBox.Show("Fill in all the fields");
                return;
            }
            else
            {
                DBMethodsFromMaterial.AddOuter(txtNameOuter.Text, Convert.ToInt32(txtPriceOuter.Text));
                UpdateOuter();
            }
            
        }
        private void UpdateOuter()
        {
            txtNameOuter.Text = null;
            txtPriceOuter.Text = null;
        }
        private void UpdateInner()
        {
            txtPriceInner.Text = null;
            txtNameInner.Text = null;
        }

        private void txtPriceOuter_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void txtPriceInner_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
