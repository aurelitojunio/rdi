using Domain.Entities;
using FluentValidation;
using System.Text.RegularExpressions;

namespace Domain.Validations
{
    public class CardValidation : AbstractValidator<Card>
    {
        public CardValidation()
        {
            RuleFor(f => CardNumberValidation.IsCardNumberValid(f.CardNumber)).Equal(true).WithMessage("Card Number Invalid!");
            RuleFor(f => CardCvvValidation.IsCardCvvValid(f.CVV)).Equal(true).WithMessage("CVV Invalid!");
        }

        public class CardNumberValidation
        {
            public static bool IsCardNumberValid(long cardNo)
            {
                var cardCheck = new Regex(@"^(1298|1267|4512|4567|8901|8933)([\-\s]?[0-9]{4}){3}$");
                return cardCheck.IsMatch(Convert.ToString(cardNo));
            }
        }

        public class CardCvvValidation
        {
            public static bool IsCardCvvValid(int cvv)
            {
                var cvvCheck = new Regex(@"^\d{1,5}$");
                return cvvCheck.IsMatch(Convert.ToString(cvv));
            }
        }
    }
}
