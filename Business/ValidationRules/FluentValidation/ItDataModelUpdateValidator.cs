﻿using System.IO;
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

           
        }
    }
}