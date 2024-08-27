﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelDomain.Entities.BaseEntity;

namespace HotelDomain.Entities
{
    public class Customer : Ids
    {
        //public int Id { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Country { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
