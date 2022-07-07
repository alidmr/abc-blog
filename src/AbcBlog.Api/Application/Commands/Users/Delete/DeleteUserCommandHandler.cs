using AbcBlog.Api.Application.Constants;
using AbcBlog.Domain.Interfaces.Users;
using AbcBlog.Shared.Exceptions;
using MediatR;

namespace AbcBlog.Api.Application.Commands.Users.Delete
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, DeleteUserCommandResult>
    {
        private readonly IUserRepository _userRepository;

        public DeleteUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<DeleteUserCommandResult> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.UserId);
            if (user == null)
                throw new BusinessException(nameof(ApplicationErrorCode.Error6), ApplicationErrorCode.Error6);

            if (user.IsDeleted)
                throw new BusinessException(nameof(ApplicationErrorCode.Error8), ApplicationErrorCode.Error8);

            user.ChangeIsDeleted();

            await _userRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

            return new DeleteUserCommandResult()
            {
                Message = "İşlem başarılı"
            };
        }
    }
}
