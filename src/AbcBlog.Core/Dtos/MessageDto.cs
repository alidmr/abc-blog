using AbcBlog.Core.Enums;

namespace AbcBlog.Core.Dtos
{
    public class MessageDto
    {
        public Guid Id { get; set; }
        public string? Code { get; set; }
        public string? Message { get; set; }
        public MessageType MessageType { get; set; }
    }
}
