using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Assignment
{
    public class RegisterViewModel : INotifyPropertyChanged
    {
        public SQLiteConnection conn;
        //public Person regmodel;
        public event PropertyChangedEventHandler PropertyChanged;
        public RegisterViewModel()
        {
            conn = DependencyService.Get<Isqlite>().GetConnection();
            conn.CreateTable<Person>();

        }

        private string title;
        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Title"));
            }
        }

        private string mobile;
        public string Mobile
        {
            get { return mobile; }
            set
            {
                mobile = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Mobile"));
            }
        }
        private string telefon;
        public string Telefon
        {
            get { return telefon; }
            set
            {
                telefon = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Telefon"));
            }
        }
        private string corporation;
        public string Corporation
        {
            get { return corporation; }
            set
            {
                corporation = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Corporation"));
            }
        }
        private DatePicker _DOB;
        public DatePicker DOB
        {
            get { return _DOB; }
            set
            {
                _DOB = value;
                PropertyChanged(this, new PropertyChangedEventArgs("DOB"));
            }
        }
        private string address;
        public string Address
        {
            get { return address; }
            set
            {
                address = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Address"));
            }
        }
        private string department;
        public string Department
        {
            get { return department; }
            set
            {
                department = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Department"));
            }
        }
        public Command RegisterCommand
        {
            get
            {
                return new Command(Register);
            }
        }

        private void Register()
        {

            if (string.IsNullOrEmpty(Title) || string.IsNullOrEmpty(Mobile) || string.IsNullOrEmpty(Telefon) || string.IsNullOrEmpty(Corporation) || string.IsNullOrEmpty(Address) || string.IsNullOrEmpty(Department))
                App.Current.MainPage.DisplayAlert("Empty Values", "Please enter Values", "OK");
            else
            {
                Registration reg = new Registration();
                reg.Title = Title;
                reg.Mobile = Mobile;
                reg.Telefon = Telefon;
                reg.Corporation = Corporation;
                reg.Address = Address;
                reg.Department = Department;

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
                }
                else
                {
                    App.Current.MainPage.DisplayAlert("Registration Failled!!!", "Please try again", "ERROR");
                }
            }

        }
    }
}
