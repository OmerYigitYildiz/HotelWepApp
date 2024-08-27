using HotelDomain.Entities.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HotelDomain.Entities
{
    public class Book : Ids

    {
        //public int Id { get; set; }
        public string Name { get; set; }
        public int Page { get; set; }
        public string Category { get; set; }

        public Guid AuthorId { get; set; }

        [JsonIgnore]
        public Author Author { get; set; }

    }
}
