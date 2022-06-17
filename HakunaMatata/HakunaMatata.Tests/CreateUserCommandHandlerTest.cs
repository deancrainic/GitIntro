using HakunaMatata.Core.Abstractions;
using HakunaMatata.Data;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HakunaMatata.Tests
{
    public class CreateUserCommandHandlerTest
    {
        private static DbContextOptions<HakunaMatataContext> dbContextOptions = new DbContextOptionsBuilder<HakunaMatataContext>()
            .UseInMemoryDatabase(databaseName: "HakunaMatataDbTests")
            .Options;

        private HakunaMatataContext context;

        [SetUp]
        public void Setup()
        {
            context = new HakunaMatataContext(dbContextOptions);
            context.Database.EnsureCreated();
            Mock<IUnitOfWork> _mockUow = new Mock<IUnitOfWork>()
                .Setup(u => u.UserRepository.GetAllAsync()).ReturnsAsync(context.Users.ToListAsync());
        }

        [TearDown]
        public void TearDown()
        {
            context.Database.EnsureDeleted();
        }

        [Test]

    }
}
