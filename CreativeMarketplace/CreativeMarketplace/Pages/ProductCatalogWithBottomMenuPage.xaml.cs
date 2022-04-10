using CreativeMarketplace.Model;
using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.PlatformConfiguration;
using System;
using System.Collections.ObjectModel;

namespace CreativeMarketplace.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductCatalogWithBottomMenuPage : ContentPage
    {
        public ObservableCollection<Product> Products { get; set; }
        public static ObservableCollection<Product> CartProducts;
        public Dictionary<int, Product> ProductsDictionary = new Dictionary<int, Product>();
        private string _href = @"http://172.29.98.45:8000/api/catalog/";

        public ProductCatalogWithBottomMenuPage()
        {
            InitializeComponent();
            InitializeProducts();
        }

        private void InitializeProducts()
        {
            Products = new ObservableCollection<Product>();
            CartProducts = new ObservableCollection<Product>();

            var result = Requests.GetRequest(_href);

            JObject arrayObject = JObject.Parse(result.Result);
            var token = arrayObject.SelectToken($@".results");

            JArray jArray = JArray.Parse(token.ToString());


            foreach (JObject obj in jArray.Children<JObject>())
            {
                Product product = JsonConvert.DeserializeObject<Product>(obj.ToString());

                Uri uri = new Uri(product.PhotoHref);
                product.Image.Source = ImageSource.FromUri(uri);
                Products.Add(product);
                CartProducts.Add(product);
                ProductsDictionary.Add(product.Id, product);
            }

            BindingContext = this;
        }

        private void AddProduct(object sender, EventArgs e)
        {

        }

        private void ProductList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Products[e.ItemIndex].Count++;
            CartPage.Instance.UpdateContent();
        }
    }
}