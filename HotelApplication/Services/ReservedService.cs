using HotelApplication.Mapper;
using HotelApplication.Models;
using HotelApplication.Models.Response;
using HotelApplication.Services.BaseServices;
using HotelDomain.Entities;
using HotelDomain.IRepositories;
using HotelDomain.IRepositories.IBaseRepositories;
using HotelInfrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApplication.Services
{
    public class ReservedService : IReservedService
    {
        private readonly IReservedRepository _repository;
        private readonly HotelDbContext _context;

        public ReservedService(IReservedRepository repository, HotelDbContext context)
        {
            _repository = repository;
            _context = context;
        }

        public async Task<List<Reserved>> GetAllTable()
        {
            var Reserved = await _repository.GetAllAsync();
            return Reserved;
        }

        public async Task<Reserved> GetTable(Guid id)
        {
            var Reserved = await _repository.GetByIdAsync(id);
            var user = HotelMapper.Mapper.Map<Reserved>(Reserved);

            return Reserved;

        }
        public async Task<ReservedResponseModel> AddTable(ReservedModel reservedModel)
        {
            // Tarihleri string olarak al ve DateTime'a dönüştür
            DateTime checkInDate = DateTime.Parse(reservedModel.checkInDate);
            DateTime checkOutDate = DateTime.Parse(reservedModel.checkOutDate);

            // Mevcut rezervasyonları al
            var existingReservations = await _repository.GetAllWithRoomsAsync();

            // Tarih karşılaştırması yaparken mevcut rezervasyonlardaki tarihler de DateTime'a dönüştürülüyor
            var conflictingReservation = existingReservations
                .FirstOrDefault(r =>
                    r.RoomId == reservedModel.RoomId &&
                    DateTime.Parse(r.checkInDate) < checkOutDate &&
                    DateTime.Parse(r.checkOutDate) > checkInDate);

            if (conflictingReservation != null)
            {
                // Çakışma durumunda işlem yapılabilir
                throw new InvalidOperationException("Bu oda belirtilen tarihler arasında zaten rezerve edilmiş.");
            }

            // Yeni rezervasyon oluştur
            var newReservation = HotelMapper.Mapper.Map<Reserved>(reservedModel);

            // Yeni bir ID oluştur
            newReservation.Id = Guid.NewGuid(); // Bu ID benzersiz olmalı ve her rezervasyon için farklı olmalı

            // Yeni rezervasyonu ekle
            await _repository.AddAsync(newReservation);

            return HotelMapper.Mapper.Map<ReservedResponseModel>(newReservation);
        }


        public async Task<ReservedUpdateModel> UpdateTable(ReservedUpdateModel reservedUpdateModel)
        {
            var user = HotelMapper.Mapper.Map<Reserved>(reservedUpdateModel);
            await _repository.UpdateAsync(user);
            return HotelMapper.Mapper.Map<ReservedUpdateModel>(user);
        }


        public async Task<Reserved> DeleteTable(Guid id)
        {
            var Reserved = await _repository.DeleteAsync(id);
            return Reserved;
        }

        public async Task<IEnumerable<Reserved>> GetAllWithRoomsAsync()
        {
            var reservedsWithBooks = await _repository.GetAllWithRoomsAsync();




            return reservedsWithBooks;
        }
    }
}
