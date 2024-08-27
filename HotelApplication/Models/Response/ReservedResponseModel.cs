using HotelDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApplication.Models.Response
{
    public class ReservedResponseModel
    {
        public Guid Id { get; set; }
        public string RoomName { get; set; }
        public string RoomType { get; set; }
        public string checkInDate { get; set; }
        public string checkOutDate { get; set; }
        public int Guests { get; set; }

        public Guid RoomId { get; set; }

        public Room Room { get; set; }
    }
}
