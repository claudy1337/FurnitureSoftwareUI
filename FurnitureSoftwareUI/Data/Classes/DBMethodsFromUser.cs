using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FurnitureSoftwareUI.Data.Model;
using System.Collections.ObjectModel;
using FurnitureSoftwareUI.Data.Classes;
using System.Windows;
using Microsoft.Win32;
using System.IO;
using FurnitureSoftwareUI.Properties;
using System.Security.Principal;
using System.Data.Entity.Infrastructure;

namespace FurnitureSoftwareUI.Data.Classes
{
    internal class DBMethodsFromUser
    {
        public static Client CurrentClient;
        public static Authorization CurrentAuthorization;
        public static ObservableCollection<Client> GetClients()
        {
            return new ObservableCollection<Client>(DBConnection.connect.Client);
        }

        public static Client GetClient(string login, string password)
        {
            return GetClients().FirstOrDefault(c => c.Authorization.Login == login && c.Authorization.Password == password);
        }
        public static bool isСorrectUserData(string login, string password)
        {
            ObservableCollection<Client> clients = new ObservableCollection<Client>(DBConnection.connect.Client);
            var currentClient = clients.Where(c => c.Authorization.Login == login && c.Authorization.Password == password).FirstOrDefault();
            return currentClient != null;
        }
        public static void EditClient(Client client, string password, string name, string surname, string balance)
        {
            try
            {
                var getClient = GetClient(client.Authorization.Login, client.Authorization.Password);
                if (getClient != null)
                {
                    getClient.Name = name;
                    getClient.Surname = surname;
                    getClient.Balance = balance;
                    getClient.Authorization.Password = password;
                    DBConnection.connect.SaveChanges();
                    MessageBox.Show("data has changed");
                }
                else
                {
                    MessageBox.Show("dont have account");
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("format is not correct");
                return;
            }

        }
        public static void EditImageClient(Client oldClient)
        {
            var getuser = GetClient(oldClient.Authorization.Login, oldClient.Authorization.Password);
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog().GetValueOrDefault())
            {
                getuser.Image = File.ReadAllBytes(openFileDialog.FileName);
            }
            DBConnection.connect.SaveChanges();
        }
        public static bool GetAdminRole(string login)
        {
            ObservableCollection<Client> admin = new ObservableCollection<Client>(DBConnection.connect.Client);
            var currentAdmin = admin.Where(a => a.Authorization.Login == login && a.idRole == 0).FirstOrDefault();
            return currentAdmin != null;
        }
        public static bool GetUserRole(string login)
        {
            ObservableCollection<Client> user = new ObservableCollection<Client>(DBConnection.connect.Client);
            var currentUser = user.Where(a => a.Authorization.Login == login && a.idRole == 1).FirstOrDefault();
            return currentUser != null;
        }
        public static bool GetProviderRole(string login)
        {
            ObservableCollection<Client> provider = new ObservableCollection<Client>(DBConnection.connect.Client);
            var currentProvider = provider.Where(a => a.Authorization.Login == login && a.idRole == 2).FirstOrDefault();
            return currentProvider != null;
        }
        public static Authorization GetAuthorization(string login, string password)
        {
            ObservableCollection<Authorization> authorizations = new ObservableCollection<Authorization>(DBConnection.connect.Authorization);
            return authorizations.Where(a=>a.Login == login && a.Password == password).FirstOrDefault();
        }
        public static void AddAuthorization(string login, string password)
        {
            try
            {
                var getClient = GetClient(login, password);
                var getAdminRole = GetAdminRole(login);
                var getProviderRole = GetProviderRole(login);
                if (getAdminRole == false && getClient == null || getProviderRole == false)
                {
                    Model.Authorization authorization = new Model.Authorization
                    {
                        Login = login,
                        Password = password
                    };
                    CurrentAuthorization = authorization;
                    DBConnection.connect.Authorization.Add(authorization);
                    DBConnection.connect.SaveChanges();
                }
                else
                {
                    MessageBox.Show("account already exists");
                }
            }
            catch(FormatException)
            {
                return;
            }
        }
        public static void AddClient(string name, int role = 1)
        {
            try
            {
                try
                {
                    byte[] image = File.ReadAllBytes("account.png");
                    if (CurrentAuthorization != null)
                    {
                        Client client = new Client
                        {
                            idAuth = CurrentAuthorization.id,
                            Name = name,
                            idRole = role,
                            Balance = "0",
                            Image = image
                        };
                        CurrentClient = client;
                        DBConnection.connect.Client.Add(client);
                        DBConnection.connect.SaveChanges();
                    }
                    else
                    {
                        return;
                    }
                }
                catch (FormatException)
                {
                    return;
                }
            }
            catch(DbUpdateException)
            {
                return;
            }
            
        }
    }
}
