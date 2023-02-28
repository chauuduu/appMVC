using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AppCrud.Models
{
    public enum Status
    {
        Available,
        Rental,
        NeedToSell,
        Sold
    }
    public enum Size
    {
        Small,
        Medium,
        Large
    }
    [Table("Clothes")]
    public class Clothes
    {
        private Clothes() { }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int Id { get; private set; }
        [Required(ErrorMessage = "Name is required")]
        [MaxLength(50)]
        public string Name { get; private set; } = "Unknown Clothes";
        [Required(ErrorMessage = "Description is required")]
        [MaxLength(50)]
        public string Description { get; private set; } = "None";
        public Size Size { get; private set; }
        public decimal Price { get; private set; }
        public int RentalTime { get; private set; }
        public int RentalPrice { get; private set; }
        [ForeignKey("Id")]
        public int TypeClothesId { get; private set; }
        [ForeignKey("Id")]
        public Status Status { get; private set; }
        [JsonIgnore]
        public TypeClothes TypeClothes { get; private set; }

        public Clothes(string name, string description, Size size, decimal price, int rentalPrice, int typeClothesId, Status status)
        {
            RentalTime = 0;
            Update(name, description, size, price, rentalPrice, typeClothesId, status);
        }
        public void Update(string name, string description, Size size, decimal price, int rentalPrice, int typeClothesId, Status status)
        {
            Name = name.Trim();
            Description = description.Trim();
            Size = size;
            Price = price > 0 ? price : 0;
            RentalPrice = rentalPrice > 10000 ? rentalPrice : 10000;
            TypeClothesId = typeClothesId;
            Status = status;
        }
        public void ChangeStatus(Status status)
        {
            if (status != Status.Sold) Status = status;
        }
        public void ChangeRentalTime()
        {
            if (RentalTime < TypeClothes.Limit) RentalTime++;
            else Status = Status.NeedToSell;
        }
    }
}