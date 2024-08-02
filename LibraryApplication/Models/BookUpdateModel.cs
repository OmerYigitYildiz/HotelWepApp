using HotelDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApplication.Models
{
    public class BookUpdateModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Page { get; set; }
        public string Category { get; set; }

        public int AuthorId { get; set; }
        public Author AuthorName { get; set; }
    }
}
