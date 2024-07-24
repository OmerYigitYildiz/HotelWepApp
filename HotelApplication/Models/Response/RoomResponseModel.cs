using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApplication.Models
{
    public class RoomResponseModel
    {
        public int Id { get; set; }
        public string RoomType { get; set; }
        public string RoomName { get; set; }
        public int Guests { get; set; }
        public string BedType { get; set; }
    }
}
