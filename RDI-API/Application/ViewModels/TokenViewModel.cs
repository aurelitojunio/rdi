using System.ComponentModel.DataAnnotations;

namespace Application.ViewModels
{
    public class TokenViewModel
    {
        [Required]
        public int CustomerId { get; set; }
        [Required]
        public int CardId { get; set; }
        [Required]
        public long Token { get; set; }
        [Required]
        public int CVV { get; set; }
    }
}