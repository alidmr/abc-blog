namespace AbcBlog.Domain.ValueObjects
{
    public class AccessToken
    {
        public string Token { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}
