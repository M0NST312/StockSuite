using RestSharp;

namespace StockSuite.MomoAPI
{
    public class GenerateUUID
    {
        public GenerateUUID()
        {

        }

        public String UUUID4()
        {
            //var client = new RestClient("https://www.uuidgenerator.net/api/version4");
            var options = new RestClientOptions("https://www.uuidgenerator.net/api/version4")
            {
                ThrowOnAnyError = true,
                //MaxTimeout = 1000
            };
            var client = new RestClient(options);
            //client.Timeout = -1;
            var request = new RestRequest();
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
