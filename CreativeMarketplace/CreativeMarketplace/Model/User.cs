using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CreativeMarketplace.Model
{
    public class User
    {
        [JsonProperty("id")]
        public int Id { get; private set; }

        [JsonProperty("username")]
        public string Name { get; private set; }

        [JsonProperty("score")]
        public int Score { get; private set; }
    }
}
