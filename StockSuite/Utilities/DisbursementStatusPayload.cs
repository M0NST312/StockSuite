namespace StockSuite.Utilities
{
    public class DisbursementStatusPayload
    {
        public string amount { get; set; }
        public string currency { get; set; }
        public string externalId { get; set; }
        public Payee payee { get; set; }
        public string status { get; set; }
      
    }
}
