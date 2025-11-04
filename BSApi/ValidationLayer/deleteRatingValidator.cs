using Dtos.RatingsDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationLayer
{
    public class deleteRatingValidator:AbstractValidator<deleteRatingDtos>
    {
        public deleteRatingValidator() 
        {
            RuleFor(x => x.BarberID)
               .GreaterThan(0)
               .WithMessage("رقم الحلاق يجب أن يكون أكبر من صفر.");

            // ✅ التحقق من CustomerID
            RuleFor(x => x.RatingID)
                .GreaterThan(0)
                .WithMessage("رقم الزبون يجب أن يكون أكبر من صفر.");

        }

    }
}
