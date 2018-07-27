using System.Collections.Generic;
using System.Net.Http;
using FindAndShare.Models;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Text;
using System;

namespace FindAndShare.Services
{
    public class UserLogin
    {
        private string URL = "https://bfg0r8yoij.execute-api.eu-west-1.amazonaws.com/User-TestPhase/single/";
        private string _postUrl = "https://bfg0r8yoij.execute-api.eu-west-1.amazonaws.com/User-TestPhase/users";
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

        public async Task<bool> OnRegister(UserPostModel user)
        {
            try
            {
                var content = JsonConvert.SerializeObject(user);
                var JsontoPost = new StringContent(content, Encoding.UTF8, "application/json");
                var response = await _client.PostAsync(this._postUrl, JsontoPost);
                if (response.IsSuccessStatusCode)
                    return true;
                else
                    return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
    }
}

 