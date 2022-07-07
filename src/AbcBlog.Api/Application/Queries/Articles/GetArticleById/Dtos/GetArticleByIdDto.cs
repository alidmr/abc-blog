namespace AbcBlog.Api.Application.Queries.Articles.GetArticleById.Dtos
{
    public class GetArticleByIdDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid OwnerId { get; set; }
        public string OwnerName { get; set; }
        public int StatusId { get; set; }
        public string Status { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
