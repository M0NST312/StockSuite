using System;
using System.Net.Http.Headers;
using System.Text;
using System.Net.Http;
using System.Web;

namespace StockSuite.MomoAPI
{

    public class CreateUser
    {
        GenerateUUID generateUUID = new GenerateUUID();
        public String uuid ;

        public CreateUser()
        {
            uuid = generateUUID.UUUID4();
        }
        //public async void MakeRequest()
        //{
        //    var client = new HttpClient();

        //    var queryString = HttpUtility.ParseQueryString(string.Empty);
        //    String formated = string.Empty;
        //    if (uuid != null)
        //    {
        //         formated = uuid.Replace("[", "");
        //        formated = formated.Replace("]", "");
        //    }


        //    // Request headers
        //    client.DefaultRequestHeaders.Add("X-Reference-Id", formated);
        //    client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "a8e6419ee58d438fbbebcfb21ec2f5ff");

        //    var uri = "https://sandbox.momodeveloper.mtn.com/v1_0/apiuser";

        //    HttpResponseMessage response;
        //    var body = @"{" + "\n" + @"  ""providerCallbackHost"": ""https://webhook.site/500c4315-42fa-4093-b7df-377d858c01ed""" + "\n" + @"}";
        //    // Request body
        //    byte[] byteData = Encoding.UTF8.GetBytes(body);

        //    using (var content = new ByteArrayContent(byteData))
        //    {
        //        content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        //        response = await client.PostAsync(uri, content);
        //    }
        //    var resp = response.Content;
        //}

        public async void MakeRequest()
        {
            var client = new HttpClient();
            var queryString = HttpUtility.ParseQueryString(string.Empty);

            // Request headers
            client.DefaultRequestHeaders.Add("X-Reference-Id", "16e3e2ec-243a-4fe1-ac98-cc88606b396b");
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "a8e6419ee58d438fbbebcfb21ec2f5ff");

            var uri = "https://sandbox.momodeveloper.mtn.com/v1_0/apiuser?" + queryString;

            HttpResponseMessage response;

            // Request body
            byte[] byteData = Encoding.UTF8.GetBytes("\"providerCallbackHost\": \"https://webhook.site/500c4315-42fa-4093-b7df-377d858c01ed\"");

            using (var content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                response = await client.PostAsync(uri, content);
            }

        }
    }

    
    
}
