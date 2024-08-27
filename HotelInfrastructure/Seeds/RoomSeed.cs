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
    public class RoomSeed : IEntityTypeConfiguration<Room>
    {
        private readonly Guid[] _ids;

        public RoomSeed(Guid[] ids)
        {
            _ids = ids ?? new Guid[3]; // Eğer ids null ise 3 elemanlı yeni bir dizi oluştur
        }

        public void Configure(EntityTypeBuilder<Room> builder)
        {
            if (_ids.Length < 3)
            {
                throw new InvalidOperationException("Guid array must contain at least 3 elements.");
            }

            var room1Id = _ids[0];
            var room2Id = _ids[1];
            var room3Id = _ids[2];

            builder.HasData(new Room
            {
                Id = room1Id,
                RoomType = "Standart",
                RoomName = "Standart-101",
                Guests = 3,
                Beds = 2,
                BedType = "Tek kişilik",
                RoomDescription = "Klima Mevcut",
            },
            new Room
            {
                Id = room2Id,
                RoomType = "VIP",
                RoomName = "VIP-805",
                Guests = 2,
                Beds = 1,
                BedType = "Çift kişilik",
                RoomDescription = "Klima Mevcut",
            },
            new Room
            {
                Id = room3Id,
                RoomType = "Standart",
                RoomName = "Standart-204",
                Guests = 5,
                Beds = 3,
                BedType = "Tek kişilik",
                RoomDescription = "Klima Mevcut",
            });
        }
    }
}
