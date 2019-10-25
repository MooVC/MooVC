namespace MooVC.Linq
{
    using System;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.Security.Permissions;

    [Serializable]
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

        protected Paging(SerializationInfo info, StreamingContext context)
        {
            Page = (ushort)info.GetValue(nameof(Page), typeof(ushort));
            Size = (ushort)info.GetValue(nameof(Size), typeof(ushort));
        }

        public ushort Page { get; }

        public ushort Size { get; }

        public virtual IQueryable<T> Apply<T>(IQueryable<T> queryable)
        {
            int skip = (Page - FirstPage) * Size;

            return queryable.Skip(skip).Take(Size);
        }

        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(nameof(Page), Page);
            info.AddValue(nameof(Size), Size);
        }
    }
}