#nullable enable
namespace StockSuite.Models
{
    public class UserDetails
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }

        public long  NationalID { get; set; }
        public int PhoneNumber { get; set; }
        public virtual Account? Account { get; set; }
        public virtual ICollection<Transaction>? Transactions { get; set; }
    }
}
