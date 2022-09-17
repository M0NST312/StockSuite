using RestSharp;

namespace StockSuite.MomoAPI
{
    public class CreateAPIUser
    {
        GenerateUUID generateUUID = new GenerateUUID();
        public String uuid;

        public CreateAPIUser()
        {
            uuid = generateUUID.UUUID4();
        }
       
        public string CreateUser()
        {
            var options = new RestClientOptions("https://sandbox.momodeveloper.mtn.com/v1_0/apiuser")
            {
                ThrowOnAnyError = true,
                //MaxTimeout = 1000
            };
            var client = new RestClient(options);
            String formated = uuid.Replace("[", "");
            formated = formated.Replace("]", "");
            //client.Timeout = -1;
            var request = new RestRequest("",Method.Post);
            request.AddHeader("X-Reference-Id", "5dd6b82c-673d-40ec-b554-eeb95ec7a729"); 
            request.AddHeader("Ocp-Apim-Subscription-Key", "a8e6419ee58d438fbbebcfb21ec2f5ff");
            //var body = @"{" + "\n" +@"  ""providerCallbackHost"": ""https://webhook.site/500c4315-42fa-4093-b7df-377d858c01ed""" + "\n" + @"}";
            //request.AddParameter("application/json", body, ParameterType.RequestBody);
            //var response = await client.ExecutePutAsync<MyRequest, MyResponse>(request, cancellationToken);
            //var response = await client.GetJsonAsync<TResponse>(request, cancellationToken);
            RestResponse response = client.Execute(request);
            if (response.Content != null)
            {
                return response.Content;
            }
            else
            {
                return "error";
            }
        }
    }
}
