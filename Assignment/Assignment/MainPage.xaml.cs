using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Assignment;
using SQLite;
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace Assignment
{
    public partial class MainPage : ContentPage
    {
        LoginViewModel loginViewModel;

        private static ISettings AppSettings =>
    CrossSettings.Current;
        public SQLiteConnection conn;
        public Person regmodel;
        public MainPage()
        {
            loginViewModel = new LoginViewModel();
            InitializeComponent();
            BindingContext = loginViewModel;
                       NavigationPage.SetHasNavigationBar(this, false);
    
        }




    }
}
