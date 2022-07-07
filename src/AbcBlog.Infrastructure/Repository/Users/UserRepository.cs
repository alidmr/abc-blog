using AbcBlog.Domain.Aggregates.Users;
using AbcBlog.Domain.Interfaces.Users;
using AbcBlog.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace AbcBlog.Infrastructure.Repository.Users
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(AbcBlogContext context) : base(context)
        {
        }


        public async Task<User> GetUserByEmailAsync(string email)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == email);
            return user;
        }
    }
}
