namespace AbcBlog.Domain.Interfaces.User
{
    public interface IUserRepository : IBaseRepository<Aggregates.Users.User>
    {
        Task<Aggregates.Users.User> GetUserByEmailAsync(string email);
    }
}
