using Application.Interfaces;
using Application.Utils;
using Application.ViewModels;
using AutoMapper;
using CrossCutting.Extensions;
using Domain.Interfaces;
using Domain.Validations;
using System.Net;

namespace Application.Services
{
    public class CardService : ICardService
    {
        private readonly ICardRepository _cardRepository;
        private readonly IMapper _mapper;
        public CardService(ICardRepository cardRepository, IMapper mapper)
        {
            _cardRepository = cardRepository;
            _mapper = mapper;
        }

        public async Task<CardViewModel> Create(CustomerCardViewModel obj)
        {
            var card = new CardFactory(_mapper).Factory(obj);

            ValidationEntity.Execute(new CardValidation(), card);

            var cards = await _cardRepository.FindAll();
            if (cards.Contains(card) == true)
            {
                throw new HttpException(HttpStatusCode.Conflict, "There is already a card registered for this customer!");
            }
            else if (cards.Where(c => c.CardNumber == card.CardNumber).Count() > 0)
            {
                throw new HttpException(HttpStatusCode.Conflict, "There is already a card registered with this number!");
            }

            await _cardRepository.Create(card);

            var result = _mapper.Map<CardViewModel>(card);
            return result;
        }

        public async Task<IEnumerable<CardViewModel>> FindAll()
        {
            var cards = await _cardRepository.FindAll();
            var result = _mapper.Map<IEnumerable<CardViewModel>>(cards);

            return result;
        }

        public async Task<CardViewModel> FindById(int id)
        {
            var card = await _cardRepository.FindById(id);
            if (card == null) throw new HttpException(HttpStatusCode.NotFound, "Card not found!");

            var result = _mapper.Map<CardViewModel>(card);
            return result;
        }

        public async Task<bool> ValidateToken(TokenViewModel obj)
        {
            if (obj == null) throw new HttpException(HttpStatusCode.BadRequest, "There is no card to validate!");

            var card = await _cardRepository.FindById(obj.CardId);
            
            if (card == null) throw new HttpException(HttpStatusCode.BadRequest, "Invalid Card!");
            if (!TokenValidation.IsTokenCreationDateValid(card.RegistrationDate)) throw new HttpException(HttpStatusCode.BadRequest, "Invalid Token!");
            if (obj.CustomerId != card.CustomerId) throw new HttpException(HttpStatusCode.BadRequest, "Customer is not the owner of this card!");
            Console.WriteLine($" CardNumber: {card.CardNumber}");

            var newToken = TokenValidation.CreateToken(card.CardNumber, obj.CVV);
            return (obj.Token == newToken);
        }
    }
}
