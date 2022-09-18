using Newtonsoft.Json;
using StockSuite.Utilities;
using System.Net.Http.Headers;
using System.Text;
using System.Web;

namespace StockSuite.MomoAPI
{

    public class RequestToPay
    {
        //CreateAPIToken token = new CreateAPIToken();
        //public string tokenInfo = "";
        //GenerateUUID generateUUID = new GenerateUUID();
        //public String uuid = "";
        //public TokenAttributes access_token = new TokenAttributes();
        //string tkn = "";
        public CreateAPIToken token = new CreateAPIToken();
        public GenerateUUID generateUUID4 = new GenerateUUID();
        TokenAttributes access_token = new TokenAttributes();
        //UUIDToken uuid = new UUIDToken();
        string tokenInfo = "";
        string uuid;
        public RequestToPay()
        {
            //tokenInfo = token.MakeRequest().Result;
            uuid = generateUUID4.UUUID4();
            tokenInfo = token.MakeRequest().Result;
            access_token = JsonConvert.DeserializeObject<TokenAttributes>(tokenInfo);
            //access_token = JsonConvert.DeserializeObject<TokenAttributes>(tokenInfo);
            //tkn = access_token.access_token.ToString();
        }

        public async Task<RequestToPayAttributes> SendPayRequest(string note)
        {
            var client = new HttpClient();
            var queryString = HttpUtility.ParseQueryString(string.Empty);

            uuid = uuid.Replace("[\"", "");
            uuid = uuid.Replace("\"]", "");
            //        formated = formated.Replace("]", "");

            //if (tokenInfo != null)
            //{
            //    access_token = JsonConvert.DeserializeObject<TokenAttributes>(tokenInfo);
            //}

            // Request headers
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + access_token.access_token.ToString());
            //client.DefaultRequestHeaders.Add("X-Callback-Url", "https://webhook.site/500c4315-42fa-4093-b7df-377d858c01ed");
            client.DefaultRequestHeaders.Add("X-Reference-Id", uuid);
            client.DefaultRequestHeaders.Add("X-Target-Environment", "sandbox");
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "fb58b243f3fb48108dccf84eb993d516");

            var uri = "https://sandbox.momodeveloper.mtn.com/collection/v1_0/requesttopay?" + queryString;

            HttpResponseMessage response;

            RequestToPayPayload payload = new RequestToPayPayload()
            {
                amount = "100",
                currency = "EUR",
                externalId = "1234567",
                payer = new Payer{ partyIdType = "MSISDN", partyId = "1278431618" },
                payerMessage = "Test Message",
                payeeNote = note
            };

            var body = JsonConvert.SerializeObject(payload);
            //var body = @"{" + "\n" +
            //    @"  ""amount"": ""100""," + "\n" +
            //    @"  ""currency"": ""EUR""," + "\n" +
            //    @"  ""externalId"": ""1234567""," + "\n" +
            //    @"  ""payer"": {" + "\n" +
            //    @"    ""partyIdType"": ""MSISDN""," + "\n" +
            //    @"    ""partyId"": ""1278431618""" + "\n" +
            //    @"  }," + "\n" +
            //    @"  ""payerMessage"": ""Testing 123""," + "\n" +
            //    @"  ""payeeNote"": ""Test""" + "\n" +
            //    @"}";
            // Request body
            byte[] byteData = Encoding.UTF8.GetBytes(body);

            using (var content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                response = await client.PostAsync(uri, content);
                var error = response.Content.ReadAsStringAsync().Result;
            }
            string requestToPayStatusString = await RequestToPayStatus(uuid);
            RequestToPayAttributes requestStatus = JsonConvert.DeserializeObject<RequestToPayAttributes>(requestToPayStatusString);

            return requestStatus;
        }


        public async Task<string> RequestToPayStatus(string uuid)
        {
            var client = new HttpClient();
            var queryString = HttpUtility.ParseQueryString(string.Empty);

            // Request headers
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + access_token.access_token.ToString());
            client.DefaultRequestHeaders.Add("X-Target-Environment", "sandbox");
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "fb58b243f3fb48108dccf84eb993d516");

            var uri = "https://sandbox.momodeveloper.mtn.com/collection/v1_0/requesttopay/" + uuid + "?"+ queryString;

            var response = await client.GetAsync(uri);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            return responseBody;
        }
        //public async Task<string> CreateToken()
        //{
        //    var client = new HttpClient();
        //    var queryString = HttpUtility.ParseQueryString(string.Empty);

        //    string UserName = "be81183b-1d22-4486-a6d5-1878a7fcdc46";
        //    string Password = "623ee10e0d5f441498434d93c529dad7";
        //    var byteArray = Encoding.ASCII.GetBytes($"{UserName}:{Password}");
        //    string encodeString = Convert.ToBase64String(byteArray);

        //    // Request headers
        //    client.DefaultRequestHeaders.Add("Authorization", "Basic " + encodeString);
        //    client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "fb58b243f3fb48108dccf84eb993d516");

        //    var uri = "https://sandbox.momodeveloper.mtn.com/collection/token/?" + queryString;

        //    HttpResponseMessage response;

        //    // Request body
        //    byte[] byteData = Encoding.UTF8.GetBytes("{body}");

        //    using (var content = new ByteArrayContent(byteData))
        //    {
        //        content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        //        response = await client.PostAsync(uri, content);
        //        response.EnsureSuccessStatusCode();
        //        string responseBody = await response.Content.ReadAsStringAsync();

        //        //if (response != null)
        //        //{
        //        //    var jsonString = await response.Content.ReadAsStringAsync();
        //        //    TokenAttributes tokenValues = new TokenAttributes();
        //        //    if (jsonString != null)
        //        //    {
        //        //         tokenValues = JsonConvert.DeserializeObject<TokenAttributes>(jsonString);
        //        //    }
        //        //    return jsonString;

        //        //}else
        //        //    return ;
        //        return responseBody;

        //    }

        //}
    }
  
}

