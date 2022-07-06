namespace AbcBlog.Api.Application.Queries.GetUserById.Dtos
{
    public class GetUserByIdDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

    }
}
