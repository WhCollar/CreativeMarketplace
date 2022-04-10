using Acr.UserDialogs;
using CreativeMarketplace.Model;
using CreativeMarketplace.Pages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static CreativeMarketplace.Model.Requests;

namespace CreativeMarketplace
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LogInPage : ContentPage
    {
        private string _href = @"http://172.29.98.45:8000/auth/token/login";

        public static Session Session { get; private set; }

        public LogInPage()
        {
            InitializeComponent();
        }           


        private async void TryLogInButton(object sender, EventArgs e)
        {            
            string login = LoginEntry.Text;
            string password = PasswordEntry.Text;

            if (login is null == true || password is null == true)
            {
                UserDialogs.Instance.Alert("Заполните все поля для авторизации", "Внимание", "Понятно");
                return;
            }

            UserDialogs.Instance.ShowLoading("Loading Please Wait...");

            await Task.Delay(100);

            LogIn(login, password);
        }

        private void LogIn(string login, string password)
        {
            if (password is null == true || login is null == true)
                return; 

            FormParam[] formParams = new FormParam[2]
            {
                new FormParam("password", password),
                new FormParam("username", login)
            };

            string result = null;

            try { result = PostRequest(_href, GeneratePostRequestParams(formParams)).Result; }
            catch {  }

            UserDialogs.Instance.HideLoading();

            if (result is null == true)
            {
                UserDialogs.Instance.Alert("Проблемы с подключением к серверу", "Ошибка", "Закрыть");
                return;
            }
            if(result == "Unable to log in with provided credentials.")
            {
                UserDialogs.Instance.Alert("Проблемы с подключением к серверу", "Ошибка", "Закрыть");
                return;
            }

            Session = JsonConvert.DeserializeObject<Session>(result);

            LoadCatalogPage();
            

        }

        private void LoadCatalogPage()
        {
            Navigation.PushModalAsync(new CatalogWithBar(), true);
        }
    }
}