using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using HotelDomain.Entities;
using FluentValidation.Results;

namespace HotelApplication.Models
{
    public class RoomUpdateModelValidation : AbstractValidator<RoomUpdateModel>
    {
        public RoomUpdateModelValidation()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id Can Not Be Empty");
            RuleFor(x => x.RoomType).NotEmpty().WithMessage("RoomType Can Not Be Empty");
            RuleFor(x => x.RoomName).NotEmpty().WithMessage("RoomName Can Not Be Empty");
            RuleFor(x => x.Guests).NotEmpty().WithMessage("Guests Can Not Be Empty");
            RuleFor(x => x.Beds).NotEmpty().WithMessage("Beds Can Not Be Empty");
            RuleFor(x => x.BedType).NotEmpty().WithMessage("BedType Can Not Be Empty");
            RuleFor(x => x.RoomDescription).NotEmpty().WithMessage("RoomDescription Can Not Be Empty");
        }
    }
}
