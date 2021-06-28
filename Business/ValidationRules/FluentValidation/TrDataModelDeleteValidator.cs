﻿using System.IO;
using Core.Entities.Concrete;
using Entities.Concrete;
using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace Business.ValidationRules.FluentValidation
{
    public class TrDataModelDeleteValidator : AbstractValidator<TrData>
    {
        public TrDataModelDeleteValidator()
        {
            RuleFor(p => p.Id).NotEmpty();

        }
    }
}