using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Assignment
{
    public class LoginViewModel : INotifyPropertyChanged
    {
         public SQLiteConnection conn;
        //public Person regmodel;
        public event PropertyChangedEventHandler PropertyChanged;
        public LoginViewModel()
        {
            conn = DependencyService.Get<Isqlite>().GetConnection();
            conn.CreateTable<Person>();

        }
        private string email;
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Email"));
            }
        }
        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Password"));
            }
        }
        public Command LoginCommand
        {
            get
            {
                return new Command(Login);
            }
        }
        public Command SignUpCommand
        {
            get
            {
                return new Command(SignUp);
            }
        }

        private void SignUp()
        {
            if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password))
                App.Current.MainPage.DisplayAlert("Empty Values", "Please enter Email and Password", "OK");
            else
            {
                Person reg = new Person();
                reg.Email = Email;

                reg.Pass = Password;
                int x = 0;
                try
                {
                    x = conn.Insert(reg);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                if (x == 1)
                {
                    App.Current.MainPage.DisplayAlert("Registration", "Thanks for Registration", "Cancel");
                    App.Current.MainPage = new FlyoutPage1();

                }
                else
                {
                    App.Current.MainPage.DisplayAlert("Registration Failled!!!", "Please try again", "ERROR");
                }
            }
            }
        private void Login()
        {
            if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password))
                App.Current.MainPage.DisplayAlert("Empty Values", "Please enter Email and Password", "OK");
            else
            {

                var items = conn.Table<Person>().Where(array => array.Email == Email && array.Pass == Password);
                if (items?.Count() != 0)
                {


                    App.Current.MainPage.DisplayAlert("Login Success", "", "Ok");
                    App.Current.MainPage = new FlyoutPage1();


                }
                else
                {
                    App.Current.MainPage.DisplayAlert("Login Fail", "Please enter correct Email and Password", "OK");

                }
               
            }
        }
    }
}