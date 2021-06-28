using System.IO;
using Core.Entities.Concrete;
using Entities.Concrete;
using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace Business.ValidationRules.FluentValidation
{
    public class TrDataModelAddValidator : AbstractValidator<TrData>
    {
        public TrDataModelAddValidator()
        {
            RuleFor(p => p.dc_Kategori).NotEmpty();
            RuleFor(p => p.dc_Olay).NotEmpty();
            RuleFor(p => p.dc_Zaman).NotEmpty();
        }
    }
}