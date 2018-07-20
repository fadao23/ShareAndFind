using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FindAndShare.Models;
using Newtonsoft.Json;

namespace FindAndShare.Services
{
    public class AnnoncesServices
    {
        private HttpClient _client;
        private string _getAllUrl = "https://kobvde8y1f.execute-api.eu-west-1.amazonaws.com/Annoncestest/all/001";
        private string _postUrl = "https://kobvde8y1f.execute-api.eu-west-1.amazonaws.com/Annoncestest/users";

        public ObservableCollection<AnnonceModel> ListAnnonce;

        public AnnoncesServices()
        {
            this._client = new HttpClient();
        }

        public async Task<ObservableCollection<AnnonceModel>> GetAll()
        {
            var reponse = await this._client.GetAsync(this._getAllUrl);
            if (reponse.IsSuccessStatusCode)
            {
                var content = await reponse.Content.ReadAsStringAsync();
                this.ListAnnonce = JsonConvert.DeserializeObject<ObservableCollection<AnnonceModel>>(content);
                if (this.ListAnnonce.Count >= 1)
                    return this.ListAnnonce;
                else
                    return null;

            }
            return null;
        }

        public async Task<int> Post(AnnoncePostModel annonceModel)
        {
            try
            {
                var content = JsonConvert.SerializeObject(annonceModel);
                var JsontoPost = new StringContent(content, Encoding.UTF8, "application/json");
                var response = await _client.PostAsync(this._postUrl, JsontoPost);
                var test = response;
                if (response.IsSuccessStatusCode)
                    return 200;
                else
                    return 0;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return 0;
            }
        }
    }
}
