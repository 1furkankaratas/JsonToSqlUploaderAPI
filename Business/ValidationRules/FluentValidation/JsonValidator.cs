using System.IO;
using Core.Entities.Concrete;
using Entities.Concrete;
using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace Business.ValidationRules.FluentValidation
{
    public class JsonValidator : AbstractValidator<JsonData>
    {
        public JsonValidator()
        {
            RuleFor(p => p.ItDatas.Length).GreaterThan(0);
            RuleFor(p => Path.GetExtension(p.ItDatas.FileName) == ".json");
            RuleFor(p => p.TrDatas.Length).GreaterThan(0);
            RuleFor(p => Path.GetExtension(p.TrDatas.FileName) == ".json");
        }

 
    }
}