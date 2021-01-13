namespace MooVC.Dynamic.ExpandoObjectExtensionsTests
{
    using System;
    using System.Collections.Generic;
    using System.Dynamic;
    using Xunit;

    public sealed class WhenCloneIsCalled
    {
        public static IEnumerable<object[]> GivenAnInitializedObjectThenItWillReturnANewObjectWithTheSameMembersData()
        {
            dynamic first = new ExpandoObject();
            dynamic second = new ExpandoObject();
            dynamic third = new ExpandoObject();

            first.Property1 = "Hello";
            first.Property2 = "World";

            second.Hello = 1;
            second.World = true;

            third.Alpha = 1.0;
            third.Beta = new object();

            yield return new object[] { first };
            yield return new object[] { second };
            yield return new object[] { third };
        }

        [Theory]
        [MemberData(nameof(GivenAnInitializedObjectThenItWillReturnANewObjectWithTheSameMembersData))]
        public void GivenAnInitializedObjectThenItWillReturnANewObjectWithTheSameMembers(ExpandoObject original)
        {
            ExpandoObject clone = original.Clone();

            Assert.NotStrictEqual(original, clone);
            Assert.Equal(original, clone);
        }

        [Fact]
        public void GivenAnInitializedObjectWithAnExpandoObjectContainedWithinThenItWillReturnANewObjectWithTheChildCloned()
        {
            dynamic parent = new ExpandoObject();
            dynamic child = new ExpandoObject();

            parent.Child = child;
            child.Value = "Hello World";

            dynamic clone = ((ExpandoObject)parent).Clone();

            Assert.NotStrictEqual(parent, clone);
            Assert.NotStrictEqual(parent.Child, clone.Child);

            Assert.Equal(parent.Child, clone.Child);
        }

        [Fact]
        public void GivenANullObjectWithDefaultIfNullSetToFalseThenAnArgumentNullExceptionIsThrown()
        {
            ExpandoObject? source = default;

            _ = Assert.Throws<ArgumentNullException>(() => source.Clone(defaultIfNull: false));
        }

        [Fact]
        public void GivenANullObjectWithDefaultIfNullSetToTrueThenAnEmptyObjectIsReturned()
        {
            ExpandoObject? source = default;
            ExpandoObject value = source.Clone(defaultIfNull: true);

            Assert.NotNull(value);
            Assert.True(((IDictionary<string, object?>)value).Count == 0);
        }
    }
}