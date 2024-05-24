using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PiggyPalAPI.Models
{
    public class TransactionModel
    {
        [Key]
        [Column("transactionId")]
        public int TransactionId { get; set; }

        [Column("transactionDate")]
        public DateOnly TransactionDate { get; set; }

        [Column("transactionAmount")]
        public decimal TransactionAmount { get; set; }

        [Column("categoryId")]
        public int CategoryId { get; set; }

        [Column("transactionDescription")]
        public string TransactionDescription { get; set; }

        //[Column("userId")]
        //public int UserId { get; set; }

    }
}
