using System.IO;
using Core.Entities.Concrete;
using Entities.Concrete;
using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace Business.ValidationRules.FluentValidation
{
    public class ItDataModelAddValidator : AbstractValidator<ItData>
    {
        public ItDataModelAddValidator()
        {
            RuleFor(p => p.dc_Categoria).NotEmpty();
            RuleFor(p => p.dc_Evento).NotEmpty();
            RuleFor(p => p.dc_Orario).NotEmpty();
        }
    }
}