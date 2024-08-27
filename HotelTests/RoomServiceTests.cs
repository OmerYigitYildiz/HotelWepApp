using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using HotelApplication.Controllers;
using HotelDomain.Entities;
using HotelInfrastructure.Repositories;
using HotelApplication.Services;
using HotelDomain.IRepositories;
using HotelApplication.Mapper;
using HotelApplication.Models;

namespace HotelTests
{
    public class RoomServiceTests
    {
        private Mock<IRoomRepository> mockRepository;
        private RoomService serviceUnderTest;
        private RoomController roomController;

        public RoomServiceTests()
        {
            mockRepository = new Mock<IRoomRepository>();
            serviceUnderTest = new RoomService(mockRepository.Object);
            roomController = new RoomController(serviceUnderTest);
        }


        // Get All Room
        [Fact]
        public async Task GetAllRoom_ReturnsExpectedResult()
        {
            //Arrange
            var expectedRoom = new List<Room>
            {
                //new Room { Id = 9, RoomType = "SUIT",RoomName = "Suit304", Guests = 2, BedType = "Gold"}
            };

            mockRepository.Setup(repo => repo.GetAllAsync().Result).Returns(expectedRoom);

            //Act
            var result = await roomController.GetAllRoom();
            var deneme = result.Result as OkObjectResult;
            var roomlist = ((List<Room>)deneme.Value);

            Assert.NotNull(roomlist);
            Assert.Equal(expectedRoom.Count, roomlist.Count);

            foreach (var expectedRoomItem in expectedRoom)
            {
                Assert.Contains(expectedRoomItem, roomlist);
            }

        }


        // Get By ID for Room
        [Fact]
        public async Task GetById_ReturnsExpectedRoom()
        {
            //var existingRoom = new Room
            //{
            //    Id = 9,
            //    RoomType = "SUIT",
            //    RoomName = "Suit304",
            //    Guests = 2,
            //    BedType = "Gold"
            //};

            //mockRepository.Setup(repo => repo.GetByIdAsync(existingRoom.Id)).ReturnsAsync(existingRoom);

            ////Act
            //var actionResult = await roomController.GetRoomById(existingRoom.Id);
            //var result = actionResult.Result as OkObjectResult;
            //var value = result.Value as Room;

            ////Assert 
            //Assert.NotNull(value);
            //Assert.Equal(existingRoom.Id, value.Id);
            //Assert.Equal(existingRoom.RoomType, value.RoomType);
            //Assert.Equal(existingRoom.RoomName, value.RoomName);
            //Assert.Equal(existingRoom.Guests, value.Guests);
            //Assert.Equal(existingRoom.BedType, value.BedType);

        }


        // Room Update
        [Fact]
        public async Task UpdateRoom_ReturnsUpdatedRoom_WhenRoomExists()
        {
            //// Arrange
            //var existingRoom = new Room
            //{
            //    Id = 9,
            //    RoomType = "SUIT",
            //    RoomName = "Suit304",
            //    Guests = 2,
            //    BedType = "Gold"
            //};

            //var updatedRoom = new Room
            //{
            //    Id = existingRoom.Id,
            //    RoomType = "VIP",
            //    RoomName = "Vip584",
            //    Guests = 1,
            //    BedType = "Vip"
            //};

            //var updateModel = new RoomUpdateModel
            //{
            //    Id = existingRoom.Id,
            //    RoomType = updatedRoom.RoomType,
            //    RoomName = updatedRoom.RoomName,
            //    Guests = updatedRoom.Guests,
            //    BedType = updatedRoom.BedType
            //};

            //mockRepository.Setup(repo => repo.GetByIdAsync(existingRoom.Id)).ReturnsAsync(existingRoom);
            //mockRepository.Setup(repo => repo.UpdateAsync(It.IsAny<Room>())).ReturnsAsync(updatedRoom);

            //// Act
            //var result = await roomController.UpdateRoom(updateModel);
            //var okResult = result.Result as OkObjectResult;

            //// Assert
            //Assert.NotNull(okResult);
            //var actualUpdatedRoom = Assert.IsType<Room>(okResult.Value);
            //Assert.Equal(updatedRoom.Id, actualUpdatedRoom.Id);
            //Assert.Equal(updatedRoom.RoomType, actualUpdatedRoom.RoomType);
            //Assert.Equal(updatedRoom.RoomName, actualUpdatedRoom.RoomName);
            //Assert.Equal(updatedRoom.Guests, actualUpdatedRoom.Guests);
            //Assert.Equal(updatedRoom.BedType, actualUpdatedRoom.BedType);
        }
    }
}
