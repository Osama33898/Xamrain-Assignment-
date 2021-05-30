using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Assignment;

namespace Assignment
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistrationFormxaml : ContentPage
    {
        RegisterViewModel registerViewModel;

        public SQLiteConnection conn;
        public Registration regmodel;
        public RegistrationFormxaml()
        {
            registerViewModel = new RegisterViewModel();
            InitializeComponent();
/*            NavigationPage.SetHasNavigationBar(this, false);
*/
            BindingContext = registerViewModel;
          
        }
     
    }
}