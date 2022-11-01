using Domain.Entities;
using Domain.Interfaces;
using Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories
{
    public class CardRepository : ICardRepository
    {
        private readonly DataContext _context;

        public CardRepository(DataContext context) { 
            _context = context; 
        }

        public async Task<IEnumerable<Card>> FindAll()
        {
            var result = await _context.Cards.ToListAsync();
            return result;
        }

        public async Task<Card> FindById(int cardId)
        {
            var result = await _context.Cards.FirstOrDefaultAsync(x => x.CardId == cardId);
            return result;
        }

        public async Task Create(Card obj)
        {
            await _context.Cards.AddAsync(obj);
            await _context.SaveChangesAsync();
        }
    }
}