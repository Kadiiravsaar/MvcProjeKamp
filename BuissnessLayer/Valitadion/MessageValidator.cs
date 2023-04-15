using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuissnessLayer.Valitadion
{
    public class MessageValidator : AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(x => x.ReceiverMail).NotEmpty().WithMessage("Alıcı adresi boş geçilemez.! ");
            
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu boş geçilemez. !")
                  .MinimumLength(3).WithMessage("Min 3 characters must be entered")
                .MaximumLength(100).WithMessage("Max 100 characters must be entered");

            RuleFor(x => x.MessageContent).NotEmpty().WithMessage("Mesaj alanı boş geçilemez. !");
                
        }
    }
}
