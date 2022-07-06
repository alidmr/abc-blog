namespace AbcBlog.Api.Application.Queries.GetUsers.Dtos
{
    public class GetUsersDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
