using HotelApplication.Controllers;
using HotelApplication.Services;
using HotelDomain.Entities;
using HotelDomain.IRepositories;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using HotelApplication.Mapper;

namespace HotelTests
{
    public class CustomerServiceTests
    {
        private Mock<ICustomerRepository> mockRepository;
        private CustomerService serviceUnderTest;
        private CustomerController customerContoller;

        public CustomerServiceTests()
        {
            mockRepository = new Mock<ICustomerRepository>();
            serviceUnderTest = new CustomerService(mockRepository.Object);
            customerContoller = new CustomerController(serviceUnderTest);
        }

        [Fact]
        public async Task GetAllCustomer_ReturnsExpectedResult()
        {
            // Arrange
            var expectedCustomers = new List<Customer>
            {
                new Customer { Id = 5, Name = "Baha Aydınlı", FirstName = "Baha", LastName = "Aydınlı", Email = "aydinli@Profen.com" },
                new Customer { Id = 10, Name = "İlknur Temel", FirstName = "İlknur", LastName = "Temel", Email = "ilknur@Profen.com" }
            };



            mockRepository.Setup(repo => repo.GetAllAsync().Result).Returns(expectedCustomers);

            {

                // Act
                var result = await customerContoller.GetAllCustomerTable();
                var deneme = result.Result as OkObjectResult;

                var customerlist = ((List<Customer>)deneme.Value);

                // Assert
                Assert.NotNull(result);
                Assert.Equal(expectedCustomers.Count, customerlist.Count);


                foreach (var expectedCustomer in expectedCustomers)
                {
                    Assert.Contains(expectedCustomer, customerlist);
                }


            }
        }

        [Fact]
        public async Task GetById_ReturnsExpectedCustomer()
        {
            // Arrange
            var expectedCustomer = new Customer
            {
                Id = 5,
                Name = "Baha Aydınlı",
                FirstName = "Baha",
                LastName = "Aydınlı",
                Email = "aydinli@Profen.com"
            };

            mockRepository.Setup(repo => repo.GetByIdAsync(expectedCustomer.Id)).ReturnsAsync(expectedCustomer);

            // Act
            var actionResult = await customerContoller.GetTable(expectedCustomer.Id);
            var result = actionResult.Result as OkObjectResult;
            var value = result.Value as Customer;

            // Assert
            Assert.NotNull(value);
            Assert.Equal(expectedCustomer.Id, value.Id);
            Assert.Equal(expectedCustomer.Name, value.Name);
            Assert.Equal(expectedCustomer.FirstName, value.FirstName);
            Assert.Equal(expectedCustomer.LastName, value.LastName);
            Assert.Equal(expectedCustomer.Email, value.Email);
        }


        [Fact]

        public async Task UpdateCutomer_ReturnsTrue_WhenCustomerExists()
        {
            // Arrange
            var existingCustomer = new Customer
            {
                Id = 5,
                Name = "Baha Aydınlı",
                FirstName = "Baha",
                LastName = "Aydınlı",
                Email = "aydinli@Profen.com",
                Phone = "053015",
                Country = "Updated Turkiye"
            };

            var updateCustomer = new Customer
            {
                Id = existingCustomer.Id,
                Name = "Updated Name",
                FirstName = "Updated FirstName",
                LastName = "Updated LastName",
                Email = "updated.email@example.com",
                Phone = "000001",
                Country = "Updated France"
            };

            mockRepository.Setup(r => r.UpdateAsync(It.IsAny<Customer>())).Returns(Task.FromResult(updateCustomer));
            mockRepository.Setup(repo => repo.GetByIdAsync(existingCustomer.Id)).ReturnsAsync(existingCustomer);

           // Act
           //var result = await customerContoller.UpdateCustomer(updateCustomer);
           // var deneme = result.Result as OkObjectResult;


           // Assert
           // Assert.NotNull(result.Value);
           // var customer = Assert.IsType<Customer>(result.Value);

        }
    }
}
