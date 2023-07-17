using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CustomerPurchasesApp.Models
{
    public class OrderDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Order_ID { get; set; }

        [ForeignKey(nameof(CustomerDetail))]
        public int Customer_ID { get; set; }

        [ForeignKey(nameof(Products))]
        public int Product_ID { get; set; }



    }
}
