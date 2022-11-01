using Application.Interfaces;
using Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using static Domain.Validations.CardValidation;

namespace RDI_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TokenController : Controller
    {
        private readonly ICardService _cardService;
        public TokenController(ICardService cardService)
        {
            _cardService = cardService;
        }

        [HttpPost]
        public async Task<ActionResult<bool>> ValidateToken(TokenViewModel obj)
        {
            var result = await _cardService.ValidateToken(obj);
            return Ok(result);
        }
    }
}
