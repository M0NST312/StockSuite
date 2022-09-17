#nullable enable
namespace StockSuite.Models
{
    public class Account
    {
        public int Id { get; set; }
        public float Subscriptions { get; set; }
        public float Loan { get; set; }
        public float Savings { get; set; }
        public virtual UserDetails? UserDetails { get; set; }
    }
}
