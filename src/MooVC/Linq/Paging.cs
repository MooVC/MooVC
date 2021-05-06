namespace MooVC.Linq
{
    using System;
    using System.Linq;
    using System.Runtime.Serialization;
    using MooVC.Serialization;
    using static System.Math;

    [Serializable]
    public class Paging
        : ISerializable
    {
        public const ushort DefaultSize = 10;
        public const ushort FirstPage = 1;
        public const ushort MinimumSize = 1;
        private static readonly Lazy<Paging> @default = new Lazy<Paging>(() => new Paging());

        public Paging(ushort page = FirstPage, ushort size = DefaultSize)
        {
            Page = Max(page, FirstPage);
            Size = Max(size, MinimumSize);
        }

        protected Paging(SerializationInfo info, StreamingContext context)
        {
            Page = info.GetValue<ushort>(nameof(Page));
            Size = info.GetValue<ushort>(nameof(Size));
        }

        public static Paging Default => @default.Value;

        public bool IsDefault => this == Default;

        public ushort Page { get; } = FirstPage;

        public ushort Size { get; } = DefaultSize;

        public int Skip => (Page - FirstPage) * Size;

        public virtual IQueryable<T> Apply<T>(IQueryable<T> queryable)
        {
            return queryable.Skip(Skip).Take(Size);
        }

        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(nameof(Page), Page);
            info.AddValue(nameof(Size), Size);
        }
    }
}