namespace MooVC.Linq.PagingTests
{
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;
    using Xunit;

    public sealed class WhenPagingIsSerialized
    {
        [Theory]
        [InlineData(Paging.FirstPage, Paging.MinimumSize)]
        [InlineData(Paging.FirstPage + 5, Paging.MinimumSize + 10)]
        [InlineData(Paging.FirstPage, ushort.MaxValue)]
        [InlineData(ushort.MaxValue, Paging.MinimumSize)]
        public void GivenAnInstanceThenAllPropertiesAreSerialized(ushort page, ushort size)
        {
            var paging = new Paging(page: page, size: size);
            Paging deserialized;

            var binaryFormatter = new BinaryFormatter();

            using (var stream = new MemoryStream())
            {
                binaryFormatter.Serialize(stream, paging);
                _ = stream.Seek(0, SeekOrigin.Begin);

                deserialized = (Paging)binaryFormatter.Deserialize(stream);
            }

            Assert.Equal(paging.Page, deserialized.Page);
            Assert.Equal(paging.Size, deserialized.Size);
            Assert.NotStrictEqual(paging, deserialized);
        }
    }
}