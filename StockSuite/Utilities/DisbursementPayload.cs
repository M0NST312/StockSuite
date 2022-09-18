namespace StockSuite.Utilities
{
    public class DisbursementPayload
    {

            public string amount { get; set; }
            public string currency { get; set; }
            public string externalId { get; set; }
            public Payee payee { get; set; }
            public string payerMessage { get; set; }
            public string payeeNote { get; set; }


    }
}
