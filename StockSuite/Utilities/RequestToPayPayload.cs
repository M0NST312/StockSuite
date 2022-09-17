namespace StockSuite.Utilities
{
    public class RequestToPayPayload
    {

            public string amount { get; set; }
            public string currency { get; set; }
            public string externalId { get; set; }
            public Payer payer { get; set; }
            public string payerMessage { get; set; }
            public string payeeNote { get; set; }
    

    }
}
