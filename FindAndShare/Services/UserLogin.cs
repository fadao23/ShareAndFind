using System.Collections.Generic;
using System.Net.Http;
using FindAndShare.Models;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace FindAndShare.Services
{
    public class UserLogin
    {
        private string URL = "https://bfg0r8yoij.execute-api.eu-west-1.amazonaws.com/User-TestPhase/single/";
        private HttpClient _client = new HttpClient();
        public List<UserModel> Items;

        public async Task<UserModel> OnLog(string username, string password)
        {

            var url = this.URL + username;

            var response = await _client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                this.Items = JsonConvert.DeserializeObject<List<UserModel>>(content);
                if (this.Items.Count >= 1)
                    return this.Items[0];
                else
                    return null;
            }
            return null;
        }
    }
}

