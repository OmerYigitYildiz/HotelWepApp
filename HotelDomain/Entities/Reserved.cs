using HotelDomain.Entities.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HotelDomain.Entities
{
    public class Reserved : Ids
    {
        public string RoomName { get; set; }
        public string RoomType { get; set; }
        public string checkInDate { get; set; }
        public string checkOutDate { get; set; }
        public int Guests { get; set; }
        public string FullName { get; set; }
        public string Tc_PassportNo { get; set; }
        public string Phone { get; set; }
        public Guid RoomId { get; set; }
        public Room Room { get; set; }
    }
}
