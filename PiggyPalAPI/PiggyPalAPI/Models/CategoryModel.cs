using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PiggyPalAPI.Models
{
    public class CategoryModel
    {
        [Key]
        [Column("categoryid")]
        public int CategoryId { get; set; }

        [Column("categoryname")]
        public string CategoryName { get; set; }

        [Column("categorytype")]
        public string CategoryType { get; set; }
    }
}
