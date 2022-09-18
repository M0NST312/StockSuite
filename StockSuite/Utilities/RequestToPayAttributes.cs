namespace StockSuite.Utilities
{
    public class RequestToPayAttributes
    {
        public string amount { get; set; }
        public string currency { get; set; }
        public string externalId { get; set; }
        public Payer payer { get; set; }
        public string status{ get; set; }
       
    }
}
