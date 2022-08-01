using AbcBlog.Api.Application.Commands.Accounts.Login;
using AbcBlog.Domain.Interfaces.Users;
using AbcBlog.Domain.Proxies;
using AbcBlog.Domain.ValueObjects;
using AbcBlog.Shared.Helpers;
using Bogus;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using UserEntity = AbcBlog.Domain.Aggregates.Users.User;

namespace AbcBlog.UnitTests.Application.CommandHandlers
{
    [TestFixture]
    public class LoginCommandHandlerTests
    {
        private Mock<IUserRepository> _userRepositoryMock;
        private Mock<ITokenProxy> _tokenProxyMock;
        private readonly string _password = "123qwe";
        private readonly string _passwordSalt = "f8d6978921db18fc3e1130c9b44edcfe";

        [SetUp]
        public void Init()
        {
            _userRepositoryMock = new Mock<IUserRepository>();
            _tokenProxyMock = new Mock<ITokenProxy>();
        }

        [TearDown]
        public void Dispose()
        {
            _userRepositoryMock.Reset();
            _tokenProxyMock.Reset();
        }

        private LoginCommand GetLoginCommand()
        {
            var faker = new Faker("tr");
            return new LoginCommand()
            {
                Email = faker.Internet.Email(),
                Password = _password
            };
        }

        private UserEntity GetUser()
        {
            var faker = new Faker("tr");
            return UserEntity.Load(faker.Person.FirstName, faker.Person.LastName,
                faker.Internet.Email(), faker.Random.Bool(), faker.Random.Bool(), faker.Random.Bool(), PasswordHelper.HashPassword(_password, _passwordSalt),
                _passwordSalt);
        }

        [Test]
        public async Task Handle_Should_LoginSuccess()
        {
            var user = GetUser();

            _userRepositoryMock.Setup(x => x.GetUserByEmailAsync(It.IsAny<string>()))
                .ReturnsAsync(user);

            _tokenProxyMock.Setup(x => x.CreateAccessToken(It.IsAny<UserEntity>()))
                .Returns(It.IsAny<AccessToken>());

            var command = GetLoginCommand();

            var handler = new LoginCommandHandler(_userRepositoryMock.Object, _tokenProxyMock.Object);

            var result = await handler.Handle(command, CancellationToken.None);

            result.Should().NotBeNull();
            result.Result.Should().NotBeNull();
            result.Errors.Should().BeNull();
        }
    }
}
