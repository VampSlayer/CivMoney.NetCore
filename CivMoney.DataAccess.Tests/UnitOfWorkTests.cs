using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Threading;
using System.Threading.Tasks;

namespace CivMoney.DataAccess.Tests
{
    [TestClass]
    public class UnitOfWorkTests
    {
        [TestMethod]
        public void UnitOfWork_ShouldCreateRepositories_AndShouldNotBeNull()
        {
            // arrange
            var mockContext = new Mock<ApplicationDbContext>();
            mockContext.Setup(x => x.SaveChanges()).Verifiable();

            // act
            var unitOfWork = new UnitOfWork(mockContext.Object);

            // assert
            unitOfWork.TransactionsRepository.Should().NotBeNull();

            // cleanup
            unitOfWork.Dispose();
        }

        [TestMethod]
        public void Save_CallsSaveChangesOnContext_Once()
        {
            // arrange
            var mockContext = new Mock<ApplicationDbContext>();
            mockContext.Setup(x => x.SaveChanges()).Verifiable();
            var unitOfWork = new UnitOfWork(mockContext.Object);

            // act
            unitOfWork.Save();

            // assert
            mockContext.Verify(x => x.SaveChanges(), Times.Once);

            // cleanup
            unitOfWork.Dispose();
        }

        [TestMethod]
        public async Task SaveAsync_CallsSaveOnContext_OnceAsync()
        {
            // arrange
            var mockContext = new Mock<ApplicationDbContext>();
            mockContext.Setup(x => x.SaveChangesAsync(CancellationToken.None)).Verifiable();
            var unitOfWork = new UnitOfWork(mockContext.Object);

            // act
            await unitOfWork.SaveAsync();

            // assert
            mockContext.Verify(x => x.SaveChangesAsync(CancellationToken.None), Times.Once);

            // cleanup
            unitOfWork.Dispose();
        }
    }
}
