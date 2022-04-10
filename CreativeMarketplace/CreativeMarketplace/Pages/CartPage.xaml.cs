using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CreativeMarketplace.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CartPage : ContentPage
    {
        public static CartPage Instance { get; private set; }


        public CartPage()
        {
            InitializeComponent();
            Instance = this;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            
        }

        public void UpdateContent()
        {
            ListView.ItemsSource = ProductCatalogWithBottomMenuPage.CartProducts.Where(x => x.Count > 0);
        }
    }
}