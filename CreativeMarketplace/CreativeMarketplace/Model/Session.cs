using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CreativeMarketplace.Model
{
    public class Session
    {
        [JsonProperty("auth_token")]
        public string Token { get; private set; }
    }
}
