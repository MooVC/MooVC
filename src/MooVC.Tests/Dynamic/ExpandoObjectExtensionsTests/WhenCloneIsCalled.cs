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
        clone.ShouldNotBeSameAs(original);
        clone.ShouldBe(original);
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
        ((ExpandoObject)clone).ShouldNotBeSameAs((ExpandoObject)parent);
        ((ExpandoObject)clone.Child).ShouldNotBeSameAs((ExpandoObject)parent.Child);
        ((ExpandoObject)clone.Child).ShouldBe((ExpandoObject)parent.Child);
    }

    [Fact]
    public void GivenANullObjectWithDefaultIfNullSetToFalseThenAnArgumentNullExceptionIsThrown()
    {
        // Arrange
        ExpandoObject? source = default;

        // Act
        Action act = () => source.Clone(defaultIfNull: false);

        // Assert
        Should.Throw<ArgumentNullException>(act);
    }

    [Fact]
    public void GivenANullObjectWithDefaultIfNullSetToTrueThenAnEmptyObjectIsReturned()
    {
        // Arrange
        ExpandoObject? source = default;

        // Act
        ExpandoObject value = source.Clone(defaultIfNull: true);

        // Assert
        value.ShouldNotBeNull();
        value.ShouldBeEmpty();
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
        ((ExpandoObject)clone).ShouldNotBeSameAs((ExpandoObject)parent);
        ((object)clone.Child).ShouldBeSameAs((object)parent.Child);
    }
}