namespace Domain.Entities
{
    public class Card : Entity
    {
        public int CustomerId { get; set; }
        public long CardNumber { get; set; }
        public int CVV { get; set; }
        public long Token { get; set; }
        
    }
}