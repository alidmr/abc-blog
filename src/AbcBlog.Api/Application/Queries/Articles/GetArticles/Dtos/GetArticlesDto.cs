namespace AbcBlog.Api.Application.Queries.Articles.GetArticles.Dtos
{
    public class GetArticlesDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        public int CreatedUserId { get; set; }
        public string CreatedUserName { get; set; }
        public int StatusId { get; set; }
        public string Status { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
