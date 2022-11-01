
namespace Domain.Entities
{
    public abstract class Entity
    {
        protected Entity()
        {
            CardId = new int();
        }
        public int CardId { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
