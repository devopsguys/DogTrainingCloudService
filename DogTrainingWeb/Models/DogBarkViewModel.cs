using System.ComponentModel.DataAnnotations;

namespace DogTrainingWeb.Models
{
    public class DogBarkViewModel
    {
        [StringLength(80), Required]
        public string Bark { get; set; }

        [StringLength(28), Required]
        public string Secret { get; set; }
    }
}