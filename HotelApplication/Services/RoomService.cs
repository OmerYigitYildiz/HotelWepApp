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
using HotelApplication.Mapper;
using HotelApplication.Models;

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
            var user = HotelMapper.Mapper.Map<Room>(Room);

            return Room;

        }

        public async Task<RoomResponseModel> AddTable(RoomModel roomModel)
        {
            var user = HotelMapper.Mapper.Map<Room>(roomModel);
            await _repository.AddAsync(user);
            return HotelMapper.Mapper.Map<RoomResponseModel>(user);
        }

        public async Task<RoomResponseModel> UpdateTable(RoomModel roomModel)
        {
            var user = HotelMapper.Mapper.Map<Room>(roomModel);
            await _repository.UpdateAsync(user);
            return HotelMapper.Mapper.Map<RoomResponseModel>(user);
        }

        public async Task<Room> DeleteTable(int id)
        {
            var Room = await _repository.DeleteAsync(id);
            return Room;


        }
    }
}
