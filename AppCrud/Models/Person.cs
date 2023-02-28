using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AppCrud.Models
{
    [Table("person")]
    public class Person
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int id { get; set; } // int, not null
        [MaxLength(50)]
        public string name { get; set; } // nvarchar(50), null
        public int? age { get; set; } // int, null
    }
}
