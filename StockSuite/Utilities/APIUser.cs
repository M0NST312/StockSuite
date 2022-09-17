using StockSuite.MomoAPI;
using System.Net.Http.Headers;

namespace StockSuite.Utilities
{
   
    public class APIUser
    {
        GenerateUUID generateUUID = new GenerateUUID();
        public String uuid;
        public APIUser()
        {
            uuid = generateUUID.UUUID4();
        }

        public async void MakeUser()
        {
            HttpClient client = new HttpClient();
            HttpRequestMessage request;
            HttpResponseMessage response;

            string responseBody;

            request = new HttpRequestMessage(HttpMethod.Post, "https://sandbox.momodeveloper.mtn.com/v1_0/apiuser");

            String formated = string.Empty;
            if (uuid != null)
            {
                formated = uuid.Replace("[", "");
                formated = formated.Replace("]", "");
            }

            List<NameValueHeaderValue> headers = new List<NameValueHeaderValue>();
            headers.Add(new NameValueHeaderValue("X-Reference-Id", "8bd1a2c8-af02-4ab9-ae45-d4d86cd0733e"));
            headers.Add(new NameValueHeaderValue("Ocp-Apim-Subscription-Key", "a8e6419ee58d438fbbebcfb21ec2f5ff"));

            foreach (var head in headers)
            {
                request.Headers.Add(head.Name, head.Value);
            }

            response = await client.SendAsync(request);

            responseBody = await response.Content.ReadAsStringAsync();
        }
    }
}
