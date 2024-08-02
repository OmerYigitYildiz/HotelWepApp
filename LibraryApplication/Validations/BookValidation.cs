using FluentValidation;
using LibraryApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApplication.Validations
{
    public class BookValidation : AbstractValidator<BookModel>
    {
        public BookValidation()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name Can Not Be Empty");
            RuleFor(x => x.Page).NotEmpty().WithMessage("Page Can Not Be Empty");
            RuleFor(x => x.Category).NotEmpty().WithMessage("Category Can Not Be Empty");
            RuleFor(x => x.AuthorId).NotEmpty().WithMessage("AuthorId Can Not Be Empty");
           // RuleFor(x => x.AuthorName).NotEmpty().WithMessage("AuthorName Can Not Be Empty");
        }
    }
}
