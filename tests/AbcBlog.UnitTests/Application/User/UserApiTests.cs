using AbcBlog.Api.Controllers;
using MediatR;
using Moq;
using NUnit.Framework;

namespace AbcBlog.UnitTests.Application.User
{
    [TestFixture]
    public class UserApiTests
    {
        private Mock<IMediator> _meditorMock;

        [SetUp]
        public void Init()
        {
            _meditorMock = new Mock<IMediator>();
        }

        [TearDown]
        public void Dispose()
        {
            _meditorMock.Reset();
        }

        //[Test]
        //public async Task CreateUser_ShouldInValidRequest()
        //{
        //    //_meditorMock.Setup(x => x.Send(It.IsAny<CreateUserCommand>(), CancellationToken.None))
        //    //    .ReturnsAsync(It.IsAny<CreateUserCommandResult>());

        //    //var userController = new UsersController();

        //    //var command = new CreateUserCommand();

        //    //var result = await userController.CreateUser(_meditorMock.Object, command,
        //    //    CancellationToken.None);


        //    //Assert.Equals(result.Stat)

        //}
    }
}
