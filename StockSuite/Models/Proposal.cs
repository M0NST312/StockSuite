namespace StockSuite.Models
{
    public class Proposal
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int Votes { get; set; }
        public string? Details { get; set; }
        public DateTime? CreatedAt { get; set; }            
        public DateTime EndDate { get; set; }
        public string Title { get; set; }
        public virtual Status? Statuses { get; set; }

    }
}
