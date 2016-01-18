using System.ComponentModel.DataAnnotations;

namespace DogTrainingWeb.Models
{
    public class DogBarkViewModel
    {
        public DogBarkViewModel() {}

        public DogBarkViewModel(DogBarkModel model)
        {
            Bark = model.Bark;
        }

        [StringLength(80), Required]
        public string Bark { get; set; }

        [StringLength(28), Required]
        public string Secret { get; set; }
    }
}