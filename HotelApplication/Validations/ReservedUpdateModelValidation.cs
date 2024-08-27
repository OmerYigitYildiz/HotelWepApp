using FluentValidation;
using HotelApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApplication.Validations
{
    public class ReservedUpdateModelValidation : AbstractValidator<ReservedUpdateModel>
    {
        public ReservedUpdateModelValidation()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id Can Not Be Empty");
            RuleFor(x => x.RoomName).NotEmpty().WithMessage("RoomName Can Not Be Empty");
            RuleFor(x => x.RoomType).NotEmpty().WithMessage("RoomType Can Not Be Empty");
            RuleFor(x => x.checkInDate).NotEmpty().WithMessage("checkInDate Can Not Be Empty");
            RuleFor(x => x.checkOutDate).NotEmpty().WithMessage("checkOutDate Can Not Be Empty");
            RuleFor(x => x.Guests).NotEmpty().WithMessage("Guests Can Not Be Empty");
            RuleFor(x => x.FullName).NotEmpty().WithMessage("FullName Can Not Be Empty");
            RuleFor(x => x.TC_PassportNo).NotEmpty().WithMessage("TC_PassportNo Can Not Be Empty");
            RuleFor(x => x.Phone).NotEmpty().WithMessage("Phone Can Not Be Empty");
            RuleFor(x => x.RoomId).NotEmpty().WithMessage("RoomId Can Not Be Empty");
        }
    }
}
