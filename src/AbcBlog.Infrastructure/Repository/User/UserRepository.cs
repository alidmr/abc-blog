using AbcBlog.Domain.Interfaces.User;
using AbcBlog.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace AbcBlog.Infrastructure.Repository.User
{
    public class UserRepository : BaseRepository<Domain.Aggregates.Users.User>, IUserRepository
    {
        public UserRepository(AbcBlogContext context) : base(context)
        {
        }


        public async Task<Domain.Aggregates.Users.User> GetUserByEmailAsync(string email)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == email);
            return user;
        }
    }
}
