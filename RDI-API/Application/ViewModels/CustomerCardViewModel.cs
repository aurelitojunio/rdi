using System.ComponentModel.DataAnnotations;

namespace Application.ViewModels
{
    public class CustomerCardViewModel
    {
        [Required]
        public int CustomerId { get; set; }
        [Required]
        public long CardNumber { get; set; }
        [Required]
        public int CVV { get; set; }
    }
}