using HotelDomain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelInfrastructure.Seeds
{
    public class CustomerSeed : IEntityTypeConfiguration<Customer>
    {
        private readonly Guid[] _ids;

        public CustomerSeed(Guid[] ids)
        {
            _ids = ids;
        }

        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasData(new Customer
            {
                Id = Guid.NewGuid(),
                Name = "Ali Yagız",
                FirstName = "Ali",
                LastName = "Yagız",
                Email = "ali@gmail.com",
                Country = "USA",
                CreatedDate = DateTime.Now,
            },
            new Customer
            {
                Id = Guid.NewGuid(),
                Name = "Gokdeniz Sahin",
                FirstName = "Gokdeniz",
                LastName = "Sahin",
                Email = "gokdeniz@gmail.com",
                Country = "Turkiye",
                CreatedDate = DateTime.Now,
            },
            new Customer
            {
                Id = Guid.NewGuid(),
                Name = "Mirac Kars",
                FirstName = "Mirac",
                LastName = "Kars",
                Email = "mirac@gmail.com",
                Country = "England",
                CreatedDate = DateTime.Now,
            }

            );
        }
    }
}
