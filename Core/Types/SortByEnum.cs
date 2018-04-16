namespace Core.Types
{
    public enum SortByEnum
    {
        Unordered = 1,
        Asc,
        Desc
    }

    public class SortBy
    {
        public const string Unordered = "Unordered";
        public const string Ascending = "Ascending";
        public const string Descending = "Descending";

        public static SortByEnum From(string value)
        {
            switch (value)
            {
                case Unordered:
                    return SortByEnum.Unordered;
                case Ascending:
                    return SortByEnum.Asc;
                case Descending:
                    return SortByEnum.Desc;
                default:
                    return SortByEnum.Unordered;
            }
        }
    }
}