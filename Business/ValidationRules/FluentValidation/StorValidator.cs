   using Entities.Concrete;
using Business.ValidationRules.FluentValidation;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class StorValidator : AbstractValidator<Stor>
    {
        public StorValidator()
        {
            RuleFor(s => s.stor_name).NotEmpty();
            RuleFor(s => s.stor_name).Length(2, 30);
            RuleFor(s => s.stor_address).NotEmpty();
        }

    }
}
