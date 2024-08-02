using FluentValidation;
using LibraryApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApplication.Validations
{
    public class AuthorUpdateModelValidation : AbstractValidator<AuthorUpdateModel>
    {
        public AuthorUpdateModelValidation()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id Can Not Be Empty");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name Can Not Be Empty");
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("FirstName Can Not Be Empty");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("LastName Can Not Be Empty");
            RuleFor(x => x.Age).NotEmpty().WithMessage("Age Can Not Be Empty");
        }
    }
}
