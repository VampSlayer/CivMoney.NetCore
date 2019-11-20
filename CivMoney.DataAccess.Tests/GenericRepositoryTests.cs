using CivMoney.DataAccess.Contracts;
using CivMoney.DataAccess.Models;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace CivMoney.DataAccess.Tests
{
    [TestClass]
    public class GenericRepositoryTests
    {
        private GenericRepository<Transaction> _genericRepository;
        private List<Transaction> _data;

        [TestInitialize]
        public void SetUp()
        {
            _data = new List<Transaction>
            {
                new Transaction { Id = 1,Description = "A" },
                new Transaction { Id = 2, Description = "B" },
                new Transaction { Id = 3, Description = "C" },
            };

            var mockSet = new Mock<DbSet<Transaction>>();
            mockSet.As<IQueryable<Transaction>>().Setup(m => m.Provider).Returns(_data.AsQueryable().Provider);
            mockSet.As<IQueryable<Transaction>>().Setup(m => m.Expression).Returns(_data.AsQueryable().Expression);
            mockSet.As<IQueryable<Transaction>>().Setup(m => m.ElementType).Returns(_data.AsQueryable().ElementType);
            mockSet.As<IQueryable<Transaction>>().Setup(m => m.GetEnumerator()).Returns(_data.AsQueryable().GetEnumerator());

            mockSet.Setup(x => x.Find(1)).Returns(_data.First());

            mockSet.Setup(x => x.Add(It.IsAny<Transaction>())).Callback<Transaction>((arg) => _data.Add(arg));
            mockSet.Setup(x => x.AddRange(It.IsAny<IEnumerable<Transaction>>())).Callback<IEnumerable<Transaction>>((arg) => _data.AddRange(arg));

            mockSet.Setup(x => x.Remove(It.IsAny<Transaction>())).Callback<Transaction>((arg) => _data.Remove(arg));
            mockSet.Setup(x => x.RemoveRange(It.IsAny<IEnumerable<Transaction>>())).Callback<IEnumerable<Transaction>>((arg) =>
            {
                foreach (var a in arg)
                {
                    _data.Remove(a);
                }
            });

            mockSet.Setup(x => x.Update(It.IsAny<Transaction>())).Callback<Transaction>((arg) =>
            {
                _data.Remove(_data.Find(x => x == arg));
                _data.Add(arg);
            });
            mockSet.Setup(x => x.UpdateRange(It.IsAny<IEnumerable<Transaction>>())).Callback<IEnumerable<Transaction>>((arg) =>
            {
                foreach (var a in arg)
                {
                    _data.Remove(_data.Find(x => x == a));
                    _data.Add(a);
                }
            });

            var mockContext = new Mock<IApplicationDbContext>();
            mockContext.Setup(m => m.Set<Transaction>()).Returns(mockSet.Object);
            mockContext.Setup(m => m.IsDetached(It.IsAny<object>())).Returns(false);
            mockContext.Setup(m => m.SetModified(It.IsAny<object>())).Verifiable();

            _genericRepository = new GenericRepository<Transaction>(mockContext.Object);
        }

        [TestMethod]
        public void GetAll_ShouldGetAllTransactions_HaveCountOfThree()
        {
            // act
            var transactions = _genericRepository.GetAll();

            // assert
            transactions.Should().HaveCount(3);
        }

        [TestMethod]
        public void Add_ShouldAddTransactionToList_ShouldNowHaveCountFour()
        {
            // act
            _genericRepository.Add(new Transaction { Id = 4, Description = "D" });

            // assert
            _data.Should().HaveCount(4);
        }

        [TestMethod]
        public void AddRange_ShouldAddTransactionListToList_ShouldNowHaveCountFive()
        {
            // arrange
            var transactions = new List<Transaction>
            {
                new Transaction { Id = 4, Description = "D" },
                new Transaction { Id = 5, Description = "E" },
            };

            // act
            _genericRepository.Add(transactions);

            // assert
            _data.Should().HaveCount(5);
        }

        [TestMethod]
        public void Find_ShouldFindEntityById_ReturnTransactionWithDescription_A()
        {
            // act
            var transaction = _genericRepository.Find(1);

            // assert
            transaction.Description.Should().Be("A");
        }

        [TestMethod]
        public void Delete_ShouldRemoveItemWithId1_ShouldNowHaveCountTwo()
        {
            // act
            _genericRepository.Delete(1);

            // assert
            _data.Should().HaveCount(2);
        }


        [TestMethod]
        public void Delete_ShouldRemoveFirstItemInData_ShouldNowHaveCountTwo()
        {
            // act
            _genericRepository.Delete(_data.First());

            // assert
            _data.Should().HaveCount(2);
        }

        [TestMethod]
        public void Delete_ShouldRemoveTwoItemsInData_ShouldNowHaveCountOne()
        {
            // arrange
            var transactions = new List<Transaction>
            {
                _data.First(),
                _data[1],
            };

            // act
            _genericRepository.Delete(transactions);

            // assert
            _data.Should().HaveCount(1);
        }

        [TestMethod]
        public void Update_UpdatesFirstItemInData_DescriptionShouldBe_Changed()
        {
            var transaction = _data.First();
            transaction.Description = "Changed";

            // act
            _genericRepository.Update(transaction);

            // assert
            _data.First().Description.Should().Be("Changed");
        }

        [TestMethod]
        public void Update_ShouldUpdateTwoItemsInData_DescriptionShouldBe_Changed1AndChanged2()
        {
            // arrange
            var transactions = new List<Transaction>
            {
                _data.First(),
                _data[1],
            };

            transactions.First().Description = "Changed1";
            transactions[1].Description = "Changed2";

            // act
            _genericRepository.Update(transactions);

            // assert
            _data.First().Description.Should().Be("Changed1");
            _data[1].Description.Should().Be("Changed2");
        }
    }
}
