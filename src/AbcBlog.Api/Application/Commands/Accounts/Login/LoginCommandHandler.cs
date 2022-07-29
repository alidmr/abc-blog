using AbcBlog.Api.Application.Commands.Accounts.Login.Dtos;
using AbcBlog.Api.Application.Constants;
using AbcBlog.Domain.Interfaces.Users;
using AbcBlog.Domain.Proxies;
using AbcBlog.Shared.Exceptions;
using AbcBlog.Shared.Helpers;
using MediatR;

namespace AbcBlog.Api.Application.Commands.Accounts.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginCommandResult>
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenProxy _tokenProxy;

        public LoginCommandHandler(IUserRepository userRepository, ITokenProxy tokenProxy)
        {
            _userRepository = userRepository;
            _tokenProxy = tokenProxy;
        }

        public async Task<LoginCommandResult> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByEmailAsync(request.Email);
            if (user == null)
                throw new BusinessException(nameof(ApplicationErrorCode.Error13), ApplicationErrorCode.Error13);

            var pass = PasswordHelper.HashPassword(request.Password, user.PasswordSalt);
            if (pass != user.Password)
                throw new BusinessException(nameof(ApplicationErrorCode.Error13), ApplicationErrorCode.Error13);

            var accessToken = _tokenProxy.CreateAccessToken(user);

            var result = new LoginCommandResult()
            {
                Result = new LoginResponseDto()
                {
                    Email = user.Email,
                    FullName = user.FullName,
                    AccessToken = accessToken
                }
            };

            return result;
        }
    }
}
