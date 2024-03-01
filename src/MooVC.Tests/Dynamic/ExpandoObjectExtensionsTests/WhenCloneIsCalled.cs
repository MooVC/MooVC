namespace MooVC.Dynamic.ExpandoObjectExtensionsTests;

using System.Dynamic;

public sealed class WhenCloneIsCalled
{
    public static TheoryData<ExpandoObject> GivenAnInitializedObjectThenItWillReturnANewObjectWithTheSameMembersData()
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

        return [first, second, third];
    }

    [Theory]
    [MemberData(nameof(GivenAnInitializedObjectThenItWillReturnANewObjectWithTheSameMembersData))]
    public void GivenAnInitializedObjectThenItWillReturnANewObjectWithTheSameMembers(ExpandoObject original)
    {
        // Act
        ExpandoObject clone = original.Clone();

        // Assert
        _ = clone.Should().NotBeSameAs(original);
        _ = clone.Should().BeEquivalentTo(original);
    }

    [Fact]
    public void GivenAnInitializedObjectWithAnExpandoObjectContainedWithinThenItWillReturnANewObjectWithTheChildCloned()
    {
        // Arrange
        dynamic parent = new ExpandoObject();
        dynamic child = new ExpandoObject();

        parent.Child = child;
        child.Value = "Hello World";

        // Act
        dynamic clone = ((ExpandoObject)parent).Clone();

        // Assert
        _ = ((ExpandoObject)clone).Should().NotBeSameAs(parent);
        _ = ((ExpandoObject)clone.Child).Should().NotBeSameAs(parent.Child);
        _ = ((ExpandoObject)clone.Child).Should().BeEquivalentTo(parent.Child);
    }

    [Fact]
    public void GivenANullObjectWithDefaultIfNullSetToFalseThenAnArgumentNullExceptionIsThrown()
    {
        // Arrange
        ExpandoObject? source = default;

        // Act
        Action act = () => source.Clone(defaultIfNull: false);

        // Assert
        _ = act.Should().Throw<ArgumentNullException>();
    }

    [Fact]
    public void GivenANullObjectWithDefaultIfNullSetToTrueThenAnEmptyObjectIsReturned()
    {
        // Arrange
        ExpandoObject? source = default;

        // Act
        ExpandoObject value = source.Clone(defaultIfNull: true);

        // Assert
        _ = value.Should().NotBeNull();
        _ = value.Should().BeEmpty();
    }

    [Fact]
    public void GivenAnInitializedObjectWithNonExpandoChildThenTheChildIsNotCloned()
    {
        // Arrange
        dynamic parent = new ExpandoObject();
        parent.Child = new object();

        // Act
        dynamic clone = ((ExpandoObject)parent).Clone();

        // Assert
        _ = ((ExpandoObject)clone).Should().NotBeSameAs(parent);
        _ = ((object)clone.Child).Should().BeSameAs(parent.Child);
    }
}