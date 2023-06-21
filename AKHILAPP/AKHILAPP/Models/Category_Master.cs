using System.ComponentModel.DataAnnotations;

namespace AKHILAPP.Models
{
    public class Category_Master

    {
        [Key]
        public int CatMaster_Id { get; set; }
        public string? Cat_Name { get; set; }
        public ICollection<Product_Master>? Product_Masters { get; set;}

    }
}
