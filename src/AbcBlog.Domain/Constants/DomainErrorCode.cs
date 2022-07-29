namespace AbcBlog.Domain.Constants
{
    public static class DomainErrorCode
    {
        public static readonly string Error1 = "First Name can not be null";
        public static readonly string Error2 = "Last Name can not be null";
        public static readonly string Error3 = "Email can not be null";
        public static readonly string Error4 = "User Id can not be null";
        public static readonly string Error5 = "Article Id can not be null";
        public static readonly string Error6 = "Article Title can not be null";
        public static readonly string Error7 = "Article Description can not be null";
        public static readonly string Error8 = "Article Owner Id can not be null";
        public static readonly string Error9 = "Article Created Date can not be null";
        public static readonly string Error10 = "User already been deleted";
        public static readonly string Error11 = "Does not exists {0} in ArticleStatus";
        public static readonly string Error12 = "Article Slug can not be null";
    }
}
