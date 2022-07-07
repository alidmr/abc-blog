using AbcBlog.Domain.Aggregates.Users;

namespace AbcBlog.Domain.Interfaces.Users
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> GetUserByEmailAsync(string email);
    }
}
