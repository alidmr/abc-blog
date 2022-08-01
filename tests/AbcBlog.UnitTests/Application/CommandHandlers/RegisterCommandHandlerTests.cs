using AbcBlog.Api.Application.Commands.Accounts.Register;
using AbcBlog.Domain.Interfaces.Users;
using Bogus;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace AbcBlog.UnitTests.Application.CommandHandlers
{
    [TestFixture]
    public class RegisterCommandHandlerTests
    {
        private Mock<IUserRepository> _userRepositoryMock;

        [SetUp]
        public void Init()
        {
            _userRepositoryMock = new Mock<IUserRepository>();
        }

        [TearDown]
        public void Dispose()
        {
            _userRepositoryMock.Reset();
        }
        private RegisterCommand GetRegisterCommand()
        {
            var faker = new Faker("tr");
            return new RegisterCommand()
            {
                FirstName = faker.Person.FirstName,
                LastName = faker.Person.LastName,
                Email = faker.Internet.Email(),
                Password = faker.Internet.Password(10),
                RePassword = faker.Internet.Password(10)
            };
        }

        [Test]
        public async Task Handle_Should_Success()
        {
            _userRepositoryMock.Setup(x => x.GetUserByEmailAsync(It.IsAny<string>()))!
                .ReturnsAsync((AbcBlog.Domain.Aggregates.Users.User)null);

            _userRepositoryMock.Setup(x => x.AddAsync(It.IsAny<AbcBlog.Domain.Aggregates.Users.User>()));

            _userRepositoryMock.Setup(x => x.UnitOfWork.SaveEntitiesAsync(CancellationToken.None))
                .ReturnsAsync(true);

            var command = GetRegisterCommand();

            var handler = new RegisterCommandHandler(_userRepositoryMock.Object);

            var result = await handler.Handle(command, CancellationToken.None);

            result.Should().NotBeNull();
            result.Result.Should().BeTrue();
            result.Errors.Should().BeNull();
        }
    }
}
