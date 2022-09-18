#nullable enable

using System.ComponentModel.DataAnnotations.Schema;

namespace StockSuite.Models
{
    
    public class Transaction
    {
        public int Id { get; set; }
        public float Amount { get; set; }
        public string? Reference { get; set; }
        public string? Type { get; set; }
        public DateTime? CreatedDate { get; set; }

        [ForeignKey("UserDetails")]
        public int UserId { get; set; }
        public virtual UserDetails? UserDetails { get; set; }
    }
}
