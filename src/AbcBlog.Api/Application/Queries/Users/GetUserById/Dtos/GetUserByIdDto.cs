namespace AbcBlog.Api.Application.Queries.Users.GetUserById.Dtos
{
    public class GetUserByIdDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

    }
}
