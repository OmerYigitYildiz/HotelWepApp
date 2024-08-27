using HotelDomain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelInfrastructure.Seeds
{
    public class ReservedSeed : IEntityTypeConfiguration<Reserved>
    {
        private readonly Guid[] _roomIds;

        public ReservedSeed(Guid[] roomIds)
        {
            _roomIds = roomIds;
        }

        public void Configure(EntityTypeBuilder<Reserved> builder)
        {
            builder.HasData(new Reserved
            {
                Id = Guid.NewGuid(),
                RoomName = "Standart-101",
                RoomType = "Standart",
                checkInDate = "2024-05-12",
                checkOutDate = "2024-05-15",
                Guests = 3,
                FullName = "Ali Yagız",
                Tc_PassportNo = "784548547824",
                Phone = "052484345",
                RoomId = _roomIds[0] // Room-1'in Id'si
            },
            new Reserved
            {
                Id = Guid.NewGuid(),
                RoomName = "VIP-809",
                RoomType = "VIP",
                checkInDate = "2024-06-18",
                checkOutDate = "2024-06-28",
                Guests = 2,
                FullName = "Gokdeniz Sahin",
                Tc_PassportNo = "8849995584",
                Phone = "05364854",
                RoomId = _roomIds[1] // Room-2'nin Id'si
            },
            new Reserved
            {
                Id = Guid.NewGuid(),
                RoomName = "Standart-206",
                RoomType = "Standart",
                checkInDate = "2024-08-02",
                checkOutDate = "2024-08-09",
                Guests = 4,
                FullName = "Beyza Nur",
                Tc_PassportNo = "231515354745",
                Phone = "0535889414",
                RoomId = _roomIds[2] // Room-3'ün Id'si
            });
        }
    }
}
