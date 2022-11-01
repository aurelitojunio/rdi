using Application.ViewModels;
using AutoMapper;
using Domain.Entities;

namespace Application.Utils
{
    public class CardFactory
    {
        private readonly IMapper _mapper;
        public CardFactory(IMapper mapper)
        {
            _mapper = mapper;
        }
        public Card Factory(CustomerCardViewModel cardViewModel)
        {
            return new Card()
            {
                CustomerId = cardViewModel.CustomerId,
                CardNumber = cardViewModel.CardNumber,
                CVV = cardViewModel.CVV,
                Token = TokenValidation.CreateToken(cardViewModel.CardNumber, cardViewModel.CVV)
            };
        }
    }
}
