using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuissnessLayer.Valitadion
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Name is required !")
                .MinimumLength(3).WithMessage("Min 3 characters must be entered")
                .MaximumLength(20).WithMessage("Max 3 characters must be entered");
            RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("Category Description is required !");
        }
    }
}
