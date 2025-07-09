using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ImageValidator : AbstractValidator<Image>
    {
        public ImageValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Boş geçilemez");
            RuleFor(x => x.Title).MaximumLength(20).WithMessage("Lütfen En fazla 20 karakter veri girişi Yapınız");
            RuleFor(x => x.Title).MinimumLength(8).WithMessage("Lütfen En fazla 20 karakter veri girişi Yapınız");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Boş geçilemez");
            RuleFor(x => x.Description).MaximumLength(50).WithMessage("Lütfen En fazla 20 karakter veri girişi Yapınız");
            RuleFor(x => x.Description).MinimumLength(20).WithMessage("Lütfen En fazla 20 karakter veri girişi Yapınız");
            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Boş geçilemez");
        }
    }
}
