using CreativeMarketplace.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CreativeMarketplace.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserProfilePage : ContentPage
    {
        public User User { get; private set; }
        private const string _profileHref = "http://172.29.98.45:8000/api/user?token=";

        public UserProfilePage()
        {
            InitializeComponent();
            InitializeUser();
        }

        private void InitializeUser()
        {
            var result = Requests.GetRequest($"{_profileHref}{LogInPage.Session.Token}");
            User = JsonConvert.DeserializeObject<User>(result.Result);
            BindingContext = this;
        }
    }
}