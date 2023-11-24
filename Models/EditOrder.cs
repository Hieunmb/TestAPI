using System.ComponentModel.DataAnnotations;
namespace TestAPI.Models
{
    public class EditOrder
    {
        [Required]
        public int Itemcode { get; set;}
        [Required]
        public DateTime OrderDelivery {  get; set; }
        [Required]
        public string OrderAddress { get; set; }
    }
}
