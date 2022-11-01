using Application.Interfaces;
using Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using static Domain.Validations.CardValidation;

namespace RDI_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CardController : ControllerBase
    {
        private readonly ICardService _cardService;
        public CardController(ICardService cardService)
        {
            _cardService = cardService;
        }

        [HttpPost]
        public async Task<ActionResult<CardViewModel>> Create(CustomerCardViewModel obj)
        {
            var result = await _cardService.Create(obj);
            return Ok(result);
        }

        [HttpGet()]
        public async Task<ActionResult<IEnumerable<CardViewModel>>> FindAllCards()
        {
            var result = await _cardService.FindAll();
            return Ok(result);
        }

        [HttpGet("{cardId}")]
        public async Task<ActionResult<CardViewModel>> FindCardById(int cardId)
        {
            var result = await _cardService.FindById(cardId);
            return Ok(result);
        }

    }
}
