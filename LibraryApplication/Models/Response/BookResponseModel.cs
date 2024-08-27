using HotelDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace LibraryApplication.Models.Response
{
    public class BookResponseModel
    {
        public Guid Id { get; set; }
        public string Category { get; set; }

        public Guid AuthorId { get; set; }

        [JsonIgnore]
        public Author Author { get; set; }
    }
}
