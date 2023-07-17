using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerPurchasesApp.Models
{
    public class Products
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Product_ID { get; set; }

        [StringLength(100)]
        [Required]
        [RegularExpression(@"^[A-Za-z]+$", ErrorMessage = " The Product-Name should be alphabet")]
        public string Product_Name { get; set; }

       
    }
}
