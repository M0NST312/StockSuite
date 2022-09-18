using System.Net.Http.Headers;
using System.Text;
using System.Web;

namespace StockSuite.MomoAPI
{
    public class DisbursementToken
    {
        public DisbursementToken()
        {

        }
        public async Task<string> GenerateToken()
        {
            var client = new HttpClient();
            var queryString = HttpUtility.ParseQueryString(string.Empty);

            string UserName = "59483a1b-3684-425d-b303-c8f971901f45";
            string Password = "135b2e70b1e0407bb87e81351a2a3a35";
            var byteArray = Encoding.ASCII.GetBytes($"{UserName}:{Password}");
            string encodeString = Convert.ToBase64String(byteArray);

            // Request headers
            client.DefaultRequestHeaders.Add("Authorization", "Basic " + encodeString);
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "a8e6419ee58d438fbbebcfb21ec2f5ff");

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
