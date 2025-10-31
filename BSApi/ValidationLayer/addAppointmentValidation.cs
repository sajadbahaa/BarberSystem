using Dtos.AppointmentDtos;
using FluentValidation;

namespace ValidationLayer
{
    public class addAppointmentValidation : AbstractValidator<addAppointmentDtos>
    {
        public addAppointmentValidation()
        {
            // CustomerID لازم يكون أكبر من صفر
            RuleFor(x => x.CustomerID)
                .GreaterThan(0)
                .WithMessage("CustomerID is required and must be greater than 0.");

            // BarberServiceID لازم يكون أكبر من صفر
            RuleFor(x => x.BarberServiceID)
                .GreaterThan(0)
                .WithMessage("BarberServiceID is required and must be greater than 0.");

            RuleFor(x => x.StartDate)
.Must(date =>
{
   var utcDate = date.Kind == DateTimeKind.Utc ? date : date.ToUniversalTime();
   return utcDate > DateTime.UtcNow;
})
.WithMessage("Start date must be in the future (UTC).");


            RuleFor(x => x.Duration)
    .GreaterThan(TimeSpan.Zero)
    .WithMessage("Duration must be greater than zero.");

            // الملاحظة (اختيارية)، لكن إذا موجودة لازم تكون قصيرة (مثلاً أقل من 200 حرف)
            RuleFor(x => x.Note)
                .MaximumLength(200)
                .WithMessage("Note must be less than 200 characters.");
        }
    }
}
