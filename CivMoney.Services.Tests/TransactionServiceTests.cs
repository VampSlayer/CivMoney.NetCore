using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CivMoney.DataAccess.Mocks;
using CivMoney.DataAccess.Models;
using CivMoney.Services.Contracts;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CivMoney.Services.Tests
{
    [TestClass]
    public class TransactionServiceTests
    {
        private ITransactionService _transactionService;
        private MockUnitOfWork _unitOfWork;

        [TestInitialize]
        public void SetUp()
        {
            var config = new MapperConfiguration(opts => { opts.AddProfile(new AutoMapperProfile()); });

            var userHelper = new Mock<IUserHelper>();

            userHelper.Setup(x => x.GetCurrentUser()).ReturnsAsync(new ApplicationUser
            {
                Id = "1"
            });

            _unitOfWork = MockUnitOfWorkFactory.CreateMockUnitOfWork();

            _transactionService = new TransactionService(userHelper.Object, _unitOfWork, config.CreateMapper());
        }

        [TestMethod]
        public async Task GetTransactionsForDate_ShouldReturnOneTransaction_ForDate_2000_01_01()
        {
            // arrange
            _unitOfWork.Transaction.Add(new Transaction
            {
                UserId = "1",
                Date = new DateTime(2000, 01, 01),
                Amount = 1,
                Description = "Rent"
            });

            // act
            var result = await _transactionService.GetTransactionsForDate(new DateTime(2000, 01, 01));

            // assert
            result.Should().HaveCount(1);
            result.First().Description.Should().Be("Rent");
            result.First().Amount.Should().Be(1);
            result.First().Date.Should().Be(new DateTime(2000, 01, 01));

        }
    }
}
