using AbcBlog.Shared.Dtos;
using AbcBlog.Shared.Enums;

namespace AbcBlog.Shared.Response
{
    public class BaseResponse
    {
        public string? Message { get; set; }
        public IEnumerable<ErrorDto>? Errors { get; set; }

        public bool Success => Errors == null || Errors.All(x => x.Type == ErrorType.Information);
    }
}
