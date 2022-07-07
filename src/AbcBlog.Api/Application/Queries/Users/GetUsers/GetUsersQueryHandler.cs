using AbcBlog.Api.Application.Queries.Users.GetUsers.Dtos;
using AbcBlog.Domain.Interfaces.Users;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AbcBlog.Api.Application.Queries.Users.GetUsers
{
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, GetUsersQueryResult>
    {
        private readonly IUserRepository _userRepository;

        public GetUsersQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<GetUsersQueryResult> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var query = _userRepository.Table;

            query = query.OrderByDescending(x => x.CreatedDate);

            var users = await query.Skip((request.Page - 1) * request.PageSize).Take(request.PageSize).ToListAsync(cancellationToken: cancellationToken);

            var result = new GetUsersQueryResult()
            {
                Result = users.Select(x => new GetUsersDto()
                {
                    Id = x.Id,
                    CreatedDate = x.CreatedDate,
                    Email = x.Email,
                    FirstName = x.FirstName,
                    IsActive = x.IsActive,
                    IsDeleted = x.IsDeleted,
                    LastName = x.LastName
                }).ToList()
            };

            return result;
        }
    }
}
