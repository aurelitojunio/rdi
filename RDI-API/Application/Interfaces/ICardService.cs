using Application.ViewModels;

namespace Application.Interfaces
{
    public interface ICardService
    {
        public Task<IEnumerable<CardViewModel>> FindAll();
        public Task<CardViewModel> FindById(int CardId);
        public Task<CardViewModel> Create(CustomerCardViewModel obj);
        public Task<bool> ValidateToken(TokenViewModel obj);
    }
}
