using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AppCrud.Models
{
    [Table("TypeClothes")]
    public class TypeClothes
    {
        private TypeClothes() { }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int Id { get; private set; }
        [MaxLength(50)]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; private set; } = "Unknown type";
        public int Limit { get; private set; }

        public List<Clothes> Clothes { get; private set; } = new List<Clothes>();
        public TypeClothes(string name, int limit)
        {
            Update(name, limit);
        }
        public void Update(string name, int limit)
        {
            Name = name.Trim();
            Limit = limit > 1 ? limit : 1;
        }
    }
}
