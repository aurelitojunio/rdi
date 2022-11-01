using FluentValidation;
using System.Net;
using Domain.Entities;
using Domain;
using CrossCutting.Extensions;

namespace Application.Utils
{
    public class ValidationEntity
    {
        public static void Execute<TV, TE>(TV validation, TE entity) where TV : AbstractValidator<TE> where TE : Entity
        {
            var validator = validation.Validate(entity);

            if (!validator.IsValid)
                throw new HttpException(HttpStatusCode.BadRequest, validator.Errors.ToString());

        }
    }
}
