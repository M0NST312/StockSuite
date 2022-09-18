using System.Net.Http.Headers;
using System.Text;
using System.Web;

namespace StockSuite.MomoAPI
{
    public class APIToken
    {
        public APIToken()
        {

        }
        public async Task<string> GenerateToken(string username, string password, string subscriptionKey)
        {
            var client = new HttpClient();
            var queryString = HttpUtility.ParseQueryString(string.Empty);

            string UserName = username;
            string Password = password;
            var byteArray = Encoding.ASCII.GetBytes($"{UserName}:{Password}");
            string encodeString = Convert.ToBase64String(byteArray);

            // Request headers
            client.DefaultRequestHeaders.Add("Authorization", "Basic " + encodeString);
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", subscriptionKey);

            var uri = "https://sandbox.momodeveloper.mtn.com/disbursement/token/" + queryString;

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
