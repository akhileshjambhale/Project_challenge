using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AKHILAPP.Models
{
    public class Product_Master
    {
        [Key]
        public int ProdMaster_Id { get; set; }
        public string? Prod_Name { get; set; }

        [ForeignKey("Category_Master")]
        public int Catmaster_Id { get; set; }


        public Category_Master? Category_Master { get; set; }
    }
}
