using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CreativeMarketplace.Model
{
    public static class Requests
    {
        private const int _requestTimeout = 10;

        public static async Task<string> PostRequest(string href, Dictionary<string, string> formParams)
        {
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.Timeout = TimeSpan.FromSeconds(_requestTimeout);
                    Uri uri = new Uri(href);
                    FormUrlEncodedContent formUrlEncodedContent = new FormUrlEncodedContent(formParams);

                    var answer = await httpClient.PostAsync(uri, formUrlEncodedContent).ConfigureAwait(false);

                    string json = answer.Content.ReadAsStringAsync().Result;
                    object deserializedObject = JsonConvert.DeserializeObject(json);

                    string deserializedJson = JsonConvert.SerializeObject(deserializedObject, Formatting.Indented);
                    return deserializedJson;
                }
            }
            catch
            {
                return null;
            }
        }

        public static async Task<string> GetRequest(string href)
        {
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.Timeout = TimeSpan.FromSeconds(_requestTimeout);
                    Uri uri = new Uri(href);

                    var answer = await httpClient.GetAsync(uri).ConfigureAwait(false);

                    string json = answer.Content.ReadAsStringAsync().Result;
                    object deserializedObject = JsonConvert.DeserializeObject(json);

                    string deserializedJson = JsonConvert.SerializeObject(deserializedObject, Formatting.Indented);
                    return deserializedJson;
                }
            }
            catch
            {
                return null;
            }
        }

        public static Dictionary<string, string> GeneratePostRequestParams(FormParam[] formParams)
        {
            Dictionary<string, string> generatedParams = new Dictionary<string, string>();

            if (formParams is null == true || formParams.Length == 0)
                throw new Exception("The array of parameters for the dictionary is not set");

            for (int i = 0; i < formParams.Length; i++)
                generatedParams.Add(formParams[i].Key, formParams[i].Value);

            return generatedParams;
        }

        public struct FormParam
        {
            public string Key { get; private set; }

            public string Value { get; private set; }

            public FormParam(string key, string value)
            {
                Key = key;
                Value = value;
            }
        }
    }
}
