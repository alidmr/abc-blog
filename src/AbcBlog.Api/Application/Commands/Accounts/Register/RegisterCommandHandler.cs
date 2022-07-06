using AbcBlog.Api.Application.Constants;
using AbcBlog.Domain.Aggregates.Users;
using AbcBlog.Domain.Interfaces.User;
using AbcBlog.Shared.Exceptions;
using AbcBlog.Shared.Helpers;
using MediatR;

namespace AbcBlog.Api.Application.Commands.Accounts.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegisterCommandResult>
    {
        private readonly IUserRepository _userRepository;

        public RegisterCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<RegisterCommandResult> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var emailExists = await _userRepository.GetUserByEmailAsync(request.Email);
            if (emailExists != null)
                throw new BusinessException(nameof(ApplicationErrorCode.Error5), ApplicationErrorCode.Error5);

            var salt = PasswordHelper.GetPasswordSalt();
            var password = PasswordHelper.HashPassword(request.Password, salt);

            var user = User.Load(Guid.NewGuid(), request.FirstName, request.LastName, request.Email, true, false, password, salt);

            await _userRepository.AddAsync(user);

            var result = await _userRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

            return new RegisterCommandResult()
            {
                Result = result,
                Message = "İşlem başarılı"
            };
        }
    }
}
