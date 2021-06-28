using System.IO;
using Core.Entities.Concrete;
using Entities.Concrete;
using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace Business.ValidationRules.FluentValidation
{
    public class ItDataModelUpdateValidator : AbstractValidator<ItData>
    {
        public ItDataModelUpdateValidator()
        {
            RuleFor(p => p.Id).NotEmpty();
            RuleFor(p => p.dc_Categoria).NotEmpty();
            RuleFor(p => p.dc_Orario).NotEmpty();
            RuleFor(p => p.dc_Evento).NotEmpty();

        }
    }
}