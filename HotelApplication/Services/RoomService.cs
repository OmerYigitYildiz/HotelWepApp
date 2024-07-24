using HotelApplication.Services.BaseServices;
using HotelInfrastructure.Repositories;
using HotelDomain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelDomain.IRepositories;

namespace HotelApplication.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _repository;

        public RoomService(IRoomRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Room>> GetAllTable()
        {
            var Room = await _repository.GetAllAsync();
            return Room;
        }

        public async Task<Room> GetTable(int id)
        {
            var Room = await _repository.GetByIdAsync(id);
            //var user = MainProjectMapper.Mapper.Map<PersonelResponseModel>(Room);

            return Room;

        }

        public async Task<Room> AddTable(Room Room)
        {
            await _repository.AddAsync(Room);
            return Room;
        }

        public async Task<Room> UpdateTable(Room Room)
        {
            await _repository.UpdateAsync(Room);
            return Room;
        }

        public async Task<Room> DeleteTable(int id)
        {
            var Room = await _repository.DeleteAsync(id);
            return Room;


        }
    }
}
