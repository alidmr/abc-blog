using AbcBlog.Domain.Aggregates.Users;
using AbcBlog.Domain.ValueObjects;

namespace AbcBlog.Domain.Proxies
{
    public interface ITokenProxy
    {
        AccessToken CreateAccessToken(User user);
    }
}
