using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebApiSolo.CustomApiService
{
    public class Api_service
    {



        public async Task<string> GetDataOfHighLight()
        {
            using (var Client = new HttpClient())
            {
                var res = await Client.GetAsync("https://api.the-odds-api.com/v3/odds/?sport=upcoming&region=uk&mkt=h2h&apiKey=2f1f57773f6a60abf38d7bc817b4367a");
                
                if (!res.IsSuccessStatusCode) return null;
                var content = res.Content;
               return await content.ReadAsStringAsync();
               
            }

        }







    }
}
