using AbcBlog.Api.Application.Queries.GetUserById.Dtos;
using AbcBlog.Domain.Interfaces.User;
using AbcBlog.Shared.Exceptions;
using MediatR;

namespace AbcBlog.Api.Application.Queries.GetUserById
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, GetUserByIdQueryResult>
    {
        private readonly IUserRepository _userRepository;

        public GetUserByIdQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<GetUserByIdQueryResult> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id);

            if (user == null)
                throw new BusinessException("", "User Not Found");

            // todo : mapper implementation
            var result = new GetUserByIdQueryResult()
            {
                Result = new GetUserByIdDto()
                {
                    Id = user.Id,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    IsActive = user.IsActive,
                    IsDeleted = user.IsDeleted,
                    LastName = user.LastName
                }
            };

            return result;
        }
    }
}
