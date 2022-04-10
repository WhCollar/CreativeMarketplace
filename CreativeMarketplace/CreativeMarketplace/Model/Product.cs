using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace CreativeMarketplace.Model
{
    public class Product
    {
        [JsonProperty("id")]
        public int Id { get; private set; }

        [JsonProperty("photo")]
        public string PhotoHref { get; private set; }

        public Image Image { get; private set; } = new Image();

        [JsonProperty("price")]
        public int Price { get; private set; }

        [JsonProperty("title")]
        public string Title { get; private set; }

        [JsonProperty("category")]
        public ProductCategory ProductCategory { get; private set; }

        [JsonProperty("merch_size_num")]
        public ProductSize[] ProductSizes { get; private set; }

        public int Count { get; set; }
    }

    public class ProductCategory
    {
        [JsonProperty("id")]
        public int Id { get; private set; }

        [JsonProperty("title")]
        public string Title { get; private set; }

        public ProductCategory(int id, string title)
        {
            Id = id;
            Title = title;
        }
    }

    public class ProductSize
    {
        [JsonProperty("size")]
        public Size Size { get; set; }

        [JsonProperty("count")]
        public int Count { get; set; }
    }

    public class Size
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }  
    }
}
