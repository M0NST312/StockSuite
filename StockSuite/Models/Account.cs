#nullable enable

using System.ComponentModel.DataAnnotations.Schema;

namespace StockSuite.Models
{
    [NotMapped]
    public class Account
    {
        public int Id { get; set; }
        public float Subscriptions { get; set; }
        public float Loan { get; set; }
        public float Savings { get; set; }
        public virtual UserDetails? UserDetails { get; set; }
    }
}
