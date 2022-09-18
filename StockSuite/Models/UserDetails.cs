#nullable enable
using System.ComponentModel.DataAnnotations;

namespace StockSuite.Models
{
    public class UserDetails
    {
        public int Id { get; set; }
        
       // public string FullName { get; set; }
        //public string? Email { get; set; }
        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
        public string FormalName
        {
            get
            {
                return LastName + ", " + FirstName;
            }
        }
        

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "You cannot leave the first name blank.")]
        [StringLength(50, ErrorMessage = "First name cannot be more than 50 characters long.")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "You cannot leave the last name blank.")]
        [StringLength(50, ErrorMessage = "Last name cannot be more than 50 characters long.")]
        public string LastName { get; set; }

       

        [Required(ErrorMessage = "Email Address is required.")]
        [StringLength(255)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public bool Active { get; set; }

        [Display(Name = "ID Number")]
        public long  NationalID { get; set; }

        [Display(Name = "MTN Phone Number")]
        [Required(ErrorMessage = "You cannot leave the Phonename blank.")]
        //[StringLength(50, ErrorMessage = "Favourite Ice Cream name cannot be more than 50 characters long.")]

        public long PhoneNumber { get; set; }

        public virtual Account? Account { get; set; }
        public virtual ICollection<Transaction>? Transactions { get; set; }
    }
}
