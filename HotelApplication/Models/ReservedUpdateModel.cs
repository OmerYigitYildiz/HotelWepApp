using HotelDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApplication.Models
{
    public class ReservedUpdateModel
    {
        public Guid Id { get; set; }
        public string RoomName { get; set; }
        public string RoomType { get; set; }
        public string checkInDate { get; set; }
        public string checkOutDate { get; set; }
        public int Guests { get; set; }
        public string FullName { get; set; }
        public string TC_PassportNo { get; set; }
        public string Phone { get; set; }

        public Guid RoomId { get; set; }

    }
}
