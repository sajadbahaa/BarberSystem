using Dtos.RatingsDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationLayer
{
    public  class updateRatingValidator:AbstractValidator<updateRatingDtos>
    {
        public updateRatingValidator()
        {
            RuleFor(x => x.BarberID)
                .GreaterThan(0)
                .WithMessage("رقم الحلاق يجب أن يكون أكبر من صفر.");

            // ✅ التحقق من CustomerID
            RuleFor(x => x.RatingID)
                .GreaterThan(0)
                .WithMessage("رقم الزبون يجب أن يكون أكبر من صفر.");

            // ✅ التحقق من Score
            RuleFor(x => x.Score)
                .InclusiveBetween((byte)1, (byte)5)
                .WithMessage("درجة التقييم يجب أن تكون بين 1 و 5.");

            // ✅ التحقق من التعليق (اختياري لكنه منطقي)
            RuleFor(x => x.Comment)
                .MaximumLength(300)
                .WithMessage("التعليق يجب ألا يتجاوز 300 حرفاً.")
                .When(x => !string.IsNullOrWhiteSpace(x.Comment));
        }
    }
}
