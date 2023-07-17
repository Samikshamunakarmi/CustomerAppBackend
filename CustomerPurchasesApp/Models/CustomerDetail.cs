using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerPurchasesApp.Models
{
    public class CustomerDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Customer_ID { get; set; }

        [StringLength(100)]
        [Required(ErrorMessage =" The First-Name should not be blank")]
        [RegularExpression(@"^[A-Z][a-z]+$", ErrorMessage = " The First-Name should start with capital alphabet")]
        public string First_Name { get; set; }

        [StringLength(100)]
        [Required(ErrorMessage = "The Last-Name should not be blank")]
        [RegularExpression(@"^[A-Z][a-z]+$", ErrorMessage = " The Last-Name should start with capital alphabet")]

        public string Last_Name { get; set; }

        [StringLength(100)]
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9.]+@[a-zA-z]+\.[a-zA-z]+$", ErrorMessage = "Invalid email format.")]
        public string Email { get; set; }

       
    }
}
