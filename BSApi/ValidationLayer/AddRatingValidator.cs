using Dtos.RatingsDtos;
using FluentValidation;

namespace Validators.RatingsValidators
{
    public class AddRatingValidator : AbstractValidator<addRatingDtos>
    {
        public AddRatingValidator()
        {
            // ✅ التحقق من AppointmentID
            RuleFor(x => x.AppointmentID)
                .GreaterThan(0)
                .WithMessage("رقم الموعد يجب أن يكون أكبر من صفر.");

            // ✅ التحقق من BarberID
            RuleFor(x => x.BarberID)
                .GreaterThan(0)
                .WithMessage("رقم الحلاق يجب أن يكون أكبر من صفر.");

            // ✅ التحقق من CustomerID
            RuleFor(x => x.CustomerID)
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
