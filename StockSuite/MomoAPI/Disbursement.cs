using Newtonsoft.Json;
using StockSuite.Utilities;
using System.Net.Http.Headers;
using System.Text;
using System.Web;

namespace StockSuite.MomoAPI
{
    public class Disbursement
    {
        public APIToken token = new APIToken();
        public TokenAttributes apiTokenAttributes = new TokenAttributes();
        public GenerateUUID generateUUID4 = new GenerateUUID();
        public string apiToken = "";
        public string tokenId = "";
        string uuid;

        public Disbursement()
        {
            apiToken = token.GenerateToken("59483a1b-3684-425d-b303-c8f971901f45", "135b2e70b1e0407bb87e81351a2a3a35", "a8e6419ee58d438fbbebcfb21ec2f5ff").Result;
            tokenId = JsonConvert.DeserializeObject<TokenAttributes>(apiToken).access_token;
            uuid = generateUUID4.UUUID4();
        }

        public async Task<DisbursementStatusPayload> DisbursementRequest(string type)
        {
            var client = new HttpClient();
            var queryString = HttpUtility.ParseQueryString(string.Empty);

            uuid = uuid.Replace("[\"", "");
            uuid = uuid.Replace("\"]", "");

            // Request headers
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + tokenId);
            //client.DefaultRequestHeaders.Add("X-Callback-Url", "");
            client.DefaultRequestHeaders.Add("X-Reference-Id", uuid);
            client.DefaultRequestHeaders.Add("X-Target-Environment", "sandbox");
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "a8e6419ee58d438fbbebcfb21ec2f5ff");

            var uri = "https://sandbox.momodeveloper.mtn.com/disbursement/v1_0/deposit?" + queryString;

            HttpResponseMessage response;

            DisbursementPayload payload = new DisbursementPayload()
            {
                amount = "100",
                currency = "EUR",
                externalId = "1234567",
                payee = new Payee { partyIdType = "MSISDN", partyId = "1278431618" },
                payerMessage = "Test Message",
                payeeNote = type
            };
            var body = JsonConvert.SerializeObject(payload);
            // Request body
            byte[] byteData = Encoding.UTF8.GetBytes(body);

            using (var content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                response = await client.PostAsync(uri, content);
                var error = response.Content.ReadAsStringAsync().Result;
            }
            string disbursementStatusString = await DisbursementStatus(uuid);
            DisbursementStatusPayload disbursementStatus = JsonConvert.DeserializeObject<DisbursementStatusPayload>(disbursementStatusString);

            return disbursementStatus;

        }
 
        public async Task<string> DisbursementStatus(string uuid)
        {
            var client = new HttpClient();
            var queryString = HttpUtility.ParseQueryString(string.Empty);

            // Request headers
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + tokenId);
            client.DefaultRequestHeaders.Add("X-Target-Environment", "sandbox");
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "a8e6419ee58d438fbbebcfb21ec2f5ff");

            var uri = "https://sandbox.momodeveloper.mtn.com/disbursement/v1_0/deposit/" + uuid + "?" + queryString;

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
