using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Assignment
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FlyoutPage1Detail : ContentPage
    {
        public SQLiteConnection conn;
        public Registration regmodel;
        List<string> listItems = new List<string>();
        public FlyoutPage1Detail()
        {
            /*  InitializeComponent();
              imgBanner.Source = ImageSource.FromResource("XamarinListView.images.banner.png");
              listItems.Add("Xamarin.Forms");
              listItems.Add("Xamarin.Android");
              listItems.Add("Xamarin.iOS");
              listPlatforms.ItemsSource = listItems;*/
            InitializeComponent();
            conn = DependencyService.Get<Isqlite>().GetConnection();
            conn.CreateTable<Registration>();
            DisplayDetails();
        }
        private async void NavigateButton_OnClicked_To_Form(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new RegistrationFormxaml());
        }
        public void DisplayDetails()
        {

            var details = (from x in conn.Table<Registration>() select x).ToList();
            myListView.ItemsSource = details;
        }
    }
}