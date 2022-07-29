using AbcBlog.Api.Application.Constants;
using AbcBlog.Domain.Interfaces.Users;
using AbcBlog.Shared.Exceptions;
using MediatR;

namespace AbcBlog.Api.Application.Commands.Users.ChangeEmail
{
    public class ChangeUserEmailCommandHandler : IRequestHandler<ChangeUserEmailCommand, ChangeUserEmailCommandResult>
    {
        private readonly IUserRepository _userRepository;

        public ChangeUserEmailCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ChangeUserEmailCommandResult> Handle(ChangeUserEmailCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id);
            if (user == null)
                throw new BusinessException(nameof(ApplicationErrorCode.Error6), ApplicationErrorCode.Error6);

            if (user.IsDeleted)
                throw new BusinessException(nameof(ApplicationErrorCode.Error9), ApplicationErrorCode.Error9);

            if (user.Email == request.Email)
                throw new BusinessException(nameof(ApplicationErrorCode.Error15), ApplicationErrorCode.Error15);

            user.ChangeEmail(request.Email);

            await _userRepository.UpdateAsync(user);

            var result = await _userRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

            return new ChangeUserEmailCommandResult()
            {
                Result = result > 0,
                Message = "İşlem başarılı"
            };
        }
    }
}
