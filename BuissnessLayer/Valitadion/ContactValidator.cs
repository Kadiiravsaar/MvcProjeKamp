using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuissnessLayer.Valitadion
{
    public class ContactValidator : AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.UserMail).NotEmpty().WithMessage("{PropertyName} is required !");
                
            RuleFor(x => x.Subject).NotEmpty().WithMessage("{PropertyName} Description is required !");

            RuleFor(x => x.UserName).NotEmpty().WithMessage("{PropertyName} Description is required !");

            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("En az 3 karakter");

            RuleFor(x => x.UserName).MinimumLength(3).WithMessage("En az 3 karakter");

            RuleFor(x => x.Subject).MaximumLength(50).WithMessage("En fazla 50 karakter");


        }
        
    }
}
