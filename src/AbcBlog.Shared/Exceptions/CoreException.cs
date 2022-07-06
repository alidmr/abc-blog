namespace AbcBlog.Shared.Exceptions
{
    public class CoreException : Exception
    {
        public CoreException()
        {
            
        }
        public CoreException(string message) : this(message, null)
        {

        }

        public CoreException(string message, Exception? innerException) : base(message, innerException)
        {

        }
    }
}
