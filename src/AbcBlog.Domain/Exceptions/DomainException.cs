﻿namespace AbcBlog.Domain.Exceptions
{
    public class DomainException : Exception
    {
        public string Code { get; private set; }

        public DomainException(string code, string message) : base(message)
        {
            Code = code;
        }

        public DomainException(string code, string message, Exception innerException) : base(message, innerException)
        {
            Code = code;
        }
    }
}
