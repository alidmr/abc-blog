namespace AbcBlog.Shared.Helpers
{
    public static class BlogHelper
    {
        public static string OptimizeText(string text)
        {
            return text.Trim().ToLower()
                .Replace('ı', 'i')
                .Replace('ğ', 'g')
                .Replace('ü', 'u')
                .Replace('ş', 's')
                .Replace('ö', 'o')
                .Replace('ç', 'c')
                .Replace(".", "")
                .Replace(":", "-")
                .Replace(",", "-")
                .Replace(";", "-")
                .Replace("(", "-")
                .Replace(")", "-")
                .Replace("[", "-")
                .Replace("]", "-")
                .Replace("{", "-")
                .Replace("}", "-")
                .Replace(" ", "-")
                .Replace("_", "-")
                .Replace("/", "-")
                .Replace("\\", "-")
                .Replace("|", "-")
                .Replace("&", "-")
                .Replace("%", "-")
                .Replace("#", "-")
                .Replace("@", "-")
                .Replace("$", "-")
                .Replace("€", "-")
                .Replace("=", "-")
                .Replace("~", "-")
                .Replace("^", "-")
                .Replace("<", "-")
                .Replace(">", "-")
                .Replace("+", "-")
                .Replace("®", "-")
                .Replace("©", "-")
                .Replace("!", "")
                .Replace("`", "")
                .Replace("'", "")
                .Replace("\"", "")
                .Replace("?", "")
                .Replace("*", "")
                .Replace("--", "-")
                .Replace("---", "-")
                .Replace("----", "-")
                .Trim('-');
        }

        public static int GetRandom()
        {
            var random = new Random();
            return random.Next(5, 10000);
        }
    }
}
