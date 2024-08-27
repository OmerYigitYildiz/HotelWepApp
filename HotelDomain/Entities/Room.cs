using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using HotelDomain.Entities.BaseEntity;

namespace HotelDomain.Entities
{
    public class Room : Ids
    {
        public string RoomType { get; set; }
        public string RoomName { get; set; }
        public int Guests { get; set; }
        public int Beds { get; set; }
        public string BedType { get; set; }
        public string RoomDescription { get; set; }

    }
}
