using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;
using HotelDomain.Entities;

namespace HotelApplication.Models
{
    public class CustomerValidation : AbstractValidator<CustomerModel>
    {
        public CustomerValidation()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name Can Not Be Empty");
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("FirstName Can Not Be Empty");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("LastName Can Not Be Empty");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email Can Not Be Empty");
            RuleFor(x => x.Phone).NotEmpty().WithMessage("Phone Can Not Be Empty");
            RuleFor(x => x.Country).NotEmpty().WithMessage("Country Can Not Be Empty");
        }
    }

}
