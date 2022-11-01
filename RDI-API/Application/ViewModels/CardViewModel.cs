using System.ComponentModel.DataAnnotations;

namespace Application.ViewModels
{
    public class CardViewModel
    {
        [Required]
        public int CustomerId { get; set; }
        [Required]
        public long CardNumber { get; set; }
        [Required]
        public int CVV { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public long Token { get; set; }
        [Key]
        public int CardId { get; set; }
    }
}