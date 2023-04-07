using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuissnessLayer.Valitadion
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Name is required !")
                .MinimumLength(3).WithMessage("Min 3 characters must be entered")
                .MaximumLength(20).WithMessage("Max 3 characters must be entered");
        }
    }
}
