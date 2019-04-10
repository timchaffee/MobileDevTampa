using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Essentials;
using TynkerMobile.Models;

namespace TynkerMobile.Services
{
    public class TynkerAPI 
    {
        HttpClient client;

        public TynkerAPI()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri($"<URL GOES HERE>");
        }

        bool IsConnected => Connectivity.NetworkAccess == NetworkAccess.Internet;

        public async Task<bool> ToggleAsync(bool on)
        {
            if (!IsConnected)
                return false;

            string content = on ? "\"on\"" : "\"off\"";

            var response = await client.PostAsync($"api/blink", new StringContent(content, Encoding.UTF8, "application/json"));

            return response.IsSuccessStatusCode;
        }
    }
}
