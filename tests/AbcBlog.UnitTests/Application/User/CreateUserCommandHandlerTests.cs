using AbcBlog.Api.Application.Commands.Users.Create;
using AbcBlog.Api.Application.Constants;
using AbcBlog.Domain.Interfaces.User;
using AbcBlog.Shared.Exceptions;
using Bogus;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace AbcBlog.UnitTests.Application.User
{
    [TestFixture]
    public class CreateUserCommandHandlerTests
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

        [Test]
        public void Handle_ShouldInValid_WhenCreateUserAlreadyExitsEmail()
        {
            var faker = new Faker("tr");
            var firstName = faker.Person.FirstName;
            var lastName = faker.Person.LastName;
            var email = faker.Internet.Email();
            var password = faker.Internet.Password();
            var salt = faker.Random.String();

            var user = AbcBlog.Domain.Aggregates.Users.User.Load(firstName, lastName, email, true, false, password, salt);

            _userRepositoryMock.Setup(x => x.GetUserByEmailAsync(email))
                .ReturnsAsync(user);

            var handler = new CreateUserCommandHandler(_userRepositoryMock.Object);

            var command = new CreateUserCommand()
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Password = password
            };

            var result = Assert.ThrowsAsync<BusinessException>(async () =>
            {
                await handler.Handle(command, CancellationToken.None);
            });

            result.Should().NotBeNull();
            result?.Code.Should().Be(nameof(ApplicationErrorCode.Error5));
            result?.Message.Should().Be(ApplicationErrorCode.Error5);
        }

        [Test]
        public async Task Handle_ShouldValid_WhenCreateUserSuccess()
        {
            var faker = new Faker("tr");
            var firstName = faker.Person.FirstName;
            var lastName = faker.Person.LastName;
            var email = faker.Internet.Email();
            var password = faker.Internet.Password();


            _userRepositoryMock.Setup(x => x.GetUserByEmailAsync(email))
                .ReturnsAsync((AbcBlog.Domain.Aggregates.Users.User)null!);

            _userRepositoryMock.Setup(x => x.AddAsync(It.IsAny<AbcBlog.Domain.Aggregates.Users.User>()));

            _userRepositoryMock.Setup(x => x.UnitOfWork.SaveEntitiesAsync(CancellationToken.None));

            var handler = new CreateUserCommandHandler(_userRepositoryMock.Object);

            var command = new CreateUserCommand()
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Password = password
            };

            var result = await handler.Handle(command, CancellationToken.None);

            result.Success.Should().BeTrue();
            result.Errors.Should().BeNull();
        }
    }
}
