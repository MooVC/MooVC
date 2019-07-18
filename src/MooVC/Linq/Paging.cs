namespace MooVC.Linq
{
    using System;
    using System.Linq;

    public class Paging
    {
        public const ushort DefaultSize = 10,
            FirstPage = 1,
            MinimumSize = 1;

        public Paging(ushort page = FirstPage, ushort size = DefaultSize)
        {
            Page = Math.Max(page, FirstPage);
            Size = Math.Max(size, MinimumSize);
        }

        public ushort Page { get; }

        public ushort Size { get; }

        public virtual IQueryable<T> Apply<T>(IQueryable<T> queryable)
        {
            int skip = (Page - FirstPage) * Size;

            return queryable.Skip(skip).Take(Size);
        }
    }
}