using AbcBlog.Shared.Dtos;

namespace AbcBlog.Shared.Exceptions
{
    public class ValidationException : CoreException
    {
        public List<ErrorDto> Errors { get; set; }

        public ValidationException(List<ErrorDto> errors)
        {
            Errors = errors;
        }
    }
}
