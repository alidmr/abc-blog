using AbcBlog.Domain.Constants;
using AbcBlog.Domain.Events.Users;
using AbcBlog.Domain.Exceptions;
using AbcBlog.Domain.Interfaces.Users;
using MediatR;

namespace AbcBlog.Domain.EventHandlers.Users
{
    public class UserDeletedEventHandler : INotificationHandler<UserDeletedEvent>
    {
        private readonly IUserRepository _userRepository;

        public UserDeletedEventHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task Handle(UserDeletedEvent notification, CancellationToken cancellationToken)
        {
            // user db update operations
            var user = await _userRepository.GetByIdAsync(notification.UserId);
            if (user == null)
                throw new DomainException(nameof(DomainErrorCode.Error10), DomainErrorCode.Error10);

            await _userRepository.UpdateAsync(user);

            await _userRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
