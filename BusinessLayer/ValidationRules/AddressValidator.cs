using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AddressValidator : AbstractValidator<Address>
    {
        public AddressValidator()
        {
            RuleFor(x => x.Description1)
                .MaximumLength(20).WithMessage("Maximum 20 karakterli olmalıdır")
                .MinimumLength(3).WithMessage("minimum 5 karakter olmalıdır")
                .NotEmpty().WithMessage("Açıklama Boş geçilemez ");
            RuleFor(x => x.Description2)
                .MaximumLength(20).WithMessage("Maximum 20 karakterli olmalıdır")
                .MinimumLength(3).WithMessage("minimum 5 karakter olmalıdır")
                .NotEmpty().WithMessage("Açıklama Boş geçilemez ");
            RuleFor(x => x.Description3)
                .MaximumLength(20).WithMessage("Maximum 20 karakterli olmalıdır")
                .MinimumLength(3).WithMessage("minimum 5 karakter olmalıdır")
                .NotEmpty().WithMessage("Açıklama Boş geçilemez ");
            RuleFor(x => x.Description4)
                .MaximumLength(20).WithMessage("Maximum 20 karakterli olmalıdır")
                .MinimumLength(3).WithMessage("minimum 5 karakter olmalıdır")
                .NotEmpty().WithMessage("Açıklama Boş geçilemez ");
            RuleFor(x => x.Mapinfo).NotEmpty().WithMessage("Harita Boş geçilemez");

        }
    }
}
