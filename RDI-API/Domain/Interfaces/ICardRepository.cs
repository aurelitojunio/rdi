using Domain.Entities;

namespace Domain.Interfaces
{
    public interface ICardRepository
    {
        public Task<IEnumerable<Card>> FindAll();
        public Task<Card> FindById(int CardId);
        public Task Create(Card obj);
    }
}
