using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StockSuite.Utilities;
using System.Net.Http.Headers;
using System.Text;
using System.Web;

namespace StockSuite.MomoAPI
{
    public class CreateAPIToken
    {
        public CreateAPIToken()
        {

        }
        public async Task<string> MakeRequest()
        {
            var client = new HttpClient();
            var queryString = HttpUtility.ParseQueryString(string.Empty);

            string UserName = "be81183b-1d22-4486-a6d5-1878a7fcdc46";
            string Password = "623ee10e0d5f441498434d93c529dad7";
            var byteArray = Encoding.ASCII.GetBytes($"{UserName}:{Password}");
            string encodeString = Convert.ToBase64String(byteArray);

            // Request headers
            client.DefaultRequestHeaders.Add("Authorization", "Basic "+ encodeString);
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "fb58b243f3fb48108dccf84eb993d516");

            var uri = "https://sandbox.momodeveloper.mtn.com/collection/token/?" + queryString;

            HttpResponseMessage response;

            // Request body
            byte[] byteData = Encoding.UTF8.GetBytes("{body}");

            using (var content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                response = await client.PostAsync(uri, content);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                //if (response != null)
                //{
                //    var jsonString = await response.Content.ReadAsStringAsync();
                //    TokenAttributes tokenValues = new TokenAttributes();
                //    if (jsonString != null)
                //    {
                //         tokenValues = JsonConvert.DeserializeObject<TokenAttributes>(jsonString);
                //    }
                //    return jsonString;

                //}else
                //    return ;
                return responseBody;

            }

        }
    }
}

