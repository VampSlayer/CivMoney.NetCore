using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CivMoney.DataAccess.Mocks;
using CivMoney.DataAccess.Models;
using CivMoney.Services.Contracts;
using CivMoney.Services.Dtos;
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
            _unitOfWork.Transactions.Add(new Transaction
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

        [TestMethod]
        public async Task GetTransactionsForRange_ShouldReturnTwoTransactions_ForDateRange()
        {
            // arrange
            _unitOfWork.Transactions.Add(new Transaction
            {
                Id = 1,
                Amount = 1,
                Date = new DateTime(2000, 01, 01),
                UserId = "1"
            });

            _unitOfWork.Transactions.Add(new Transaction
            {
                Id = 2,
                Amount = 2,
                Date = new DateTime(2000, 01, 31),
                UserId = "1"
            });

            _unitOfWork.Transactions.Add(new Transaction
            {
                Id = 3,
                Amount = 3,
                Date = new DateTime(2000, 01, 31),
                UserId = "2"
            });

            _unitOfWork.Transactions.Add(new Transaction
            {
                Id = 4,
                Amount = 4,
                Date = new DateTime(2000, 02, 01),
                UserId = "1"
            });

            // act
            var result = await _transactionService.GetTransactionsForRange(new DateTime(2000, 01, 01), new DateTime(2000, 01, 31));
            
            // assert
            result.Should().HaveCount(2);
            result.First().Delete.Should().Be(1);
            result.First().Date.Should().Be(new DateTime(2000, 01, 01));
            result.ToArray()[1].Delete.Should().Be(2);
            result.ToArray()[1].Date.Should().Be(new DateTime(2000, 01, 31));
        }

        [TestMethod]
        public async Task AddMonthlyFixedTransaction_Adds31TransactionsToDatabase_ForMonthJanuary_Of1AmountEach()
        {
            // act
            await _transactionService.AddMonthlyFixedTransaction(new TransactionDto
            {
                Amount = 31,
                Date = new DateTime(2000, 01, 01),
                Description = "Wage"
            });

            // assert
            _unitOfWork.Transactions.Should().HaveCount(31);
            var i = 1;
            foreach (var transaction in _unitOfWork.Transactions)
            {
                transaction.Date.Should().Be(new DateTime(2000, 01, i));
                transaction.Amount.Should().Be(1);
                transaction.Description.Should().Be("Wage");
                transaction.UserId.Should().Be("1");
                i++;
            }
        }

        [TestMethod]
        public async Task AddTransaction_ShouldAddOneTransaction_WithDate2000_01_01_AndAmount1_AndDescriptionWage_AndForUserId1()
        {
            // act
            await _transactionService.AddTransaction(new TransactionDto
            {
                Amount = 1,
                Date = new DateTime(2000, 01, 01),
                Description = "Wage"
            });

            // assert
            _unitOfWork.Transactions.Should().HaveCount(1);
            _unitOfWork.Transactions.First().Date.Should().Be(new DateTime(2000, 01, 01));
            _unitOfWork.Transactions.First().Amount.Should().Be(1);
            _unitOfWork.Transactions.First().Description.Should().Be("Wage");
            _unitOfWork.Transactions.First().UserId.Should().Be("1");
        }

        [TestMethod]
        public async Task DeleteTransaction_ShouldRemoveOneTransactionFromDatabase_WithId2()
        {
            // arrange
            _unitOfWork.Transactions.Add(new Transaction
            {
                Id = 1,
                UserId = "2"
            });

            _unitOfWork.Transactions.Add(new Transaction
            {
                Id = 2,
                UserId = "1"
            });

            // act
            await _transactionService.DeleteTransaction(2);

            // assert
            _unitOfWork.Transactions.Should().HaveCount(1);
            _unitOfWork.Transactions.Should().NotContain(x => x.Id == 2);
        }

        [TestMethod]
        public async Task DeleteTransaction_ShouldRemoveNoTransaction_AsId2IsNotFound()
        {
            // arrange
            _unitOfWork.Transactions.Add(new Transaction
            {
                Id = 1,
                UserId = "1"
            });

            // act
            await _transactionService.DeleteTransaction(2);

            // assert
            _unitOfWork.Transactions.Should().HaveCount(1);
        }
    }
}
