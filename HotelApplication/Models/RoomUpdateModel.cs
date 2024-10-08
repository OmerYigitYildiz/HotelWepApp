﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApplication.Models
{
    public class RoomUpdateModel
    {
        public int Id { get; set; } 
        public string RoomType { get; set; }
        public string RoomName { get; set; }
        public int Guests { get; set; }
        public int Beds { get; set; }
        public string BedType { get; set; }
        public string RoomDescription { get; set; }
    }
}
