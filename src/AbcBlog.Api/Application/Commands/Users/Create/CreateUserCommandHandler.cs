using AbcBlog.Api.Application.Commands.Users.Create.Dtos;
using AbcBlog.Api.Application.Constants;
using AbcBlog.Domain.Aggregates.Users;
using AbcBlog.Domain.Interfaces.Users;
using AbcBlog.Shared.Exceptions;
using MediatR;

namespace AbcBlog.Api.Application.Commands.Users.Create
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CreateUserCommandResult>
    {
        private readonly IUserRepository _userRepository;

        public CreateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<CreateUserCommandResult> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var userCheck = await _userRepository.GetUserByEmailAsync(request.Email);
            if (userCheck != null)
                throw new BusinessException(nameof(ApplicationErrorCode.Error5), ApplicationErrorCode.Error5);

            var user = User.Load(Guid.NewGuid(), request.FirstName, request.LastName, request.Email, true, false,false,"","");

            await _userRepository.AddAsync(user);

            await _userRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

            var result = new CreateUserCommandResult()
            {
                Result = new CreateUserDto()
                {
                    Id = user.Id,
                    FullName = $"{user.FirstName} {user.LastName}"
                }
            };

            return result;
        }
    }
}
