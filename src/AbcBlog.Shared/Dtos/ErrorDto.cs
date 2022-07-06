using AbcBlog.Shared.Enums;

namespace AbcBlog.Shared.Dtos
{
    public class ErrorDto
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? Code { get; set; }
        public string? Content { get; set; }
        public ErrorType Type { get; set; }
    }
}
