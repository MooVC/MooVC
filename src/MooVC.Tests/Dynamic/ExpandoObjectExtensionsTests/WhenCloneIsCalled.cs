namespace MooVC.Dynamic.ExpandoObjectExtensionsTests;

using System.Dynamic;

public sealed class WhenCloneIsCalled
{
    public static IEnumerable<Func<ExpandoObject>> GivenAnInitializedObjectThenItWillReturnANewObjectWithTheSameMembersData()
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

        return
        [
            () => first,
            () => second,
            () => third,
        ];
    }

    [Test]
    [MethodDataSource(nameof(GivenAnInitializedObjectThenItWillReturnANewObjectWithTheSameMembersData))]
    public async Task GivenAnInitializedObjectThenItWillReturnANewObjectWithTheSameMembers(ExpandoObject original)
    {
        // Act
        ExpandoObject clone = original.Clone();

        // Assert
        _ = await Assert.That(clone).IsNotStrictlyEqualTo(original);
        _ = await Assert.That(clone).IsEquivalentTo(original);
    }

    [Test]
    public async Task GivenAnInitializedObjectWithAnExpandoObjectContainedWithinThenItWillReturnANewObjectWithTheChildCloned()
    {
        // Arrange
        dynamic parent = new ExpandoObject();
        dynamic child = new ExpandoObject();

        parent.Child = child;
        child.Value = "Hello World";

        // Act
        dynamic clone = ((ExpandoObject)parent).Clone();

        // Assert
        _ = await Assert.That((ExpandoObject)clone).IsNotStrictlyEqualTo((ExpandoObject)parent);
        _ = await Assert.That((ExpandoObject)clone.Child).IsNotStrictlyEqualTo((ExpandoObject)parent.Child);
        _ = await Assert.That((ExpandoObject)clone.Child).IsEquivalentTo((ExpandoObject)parent.Child);
    }

    [Test]
    public async Task GivenAnInitializedObjectWithNonExpandoChildThenTheChildIsNotCloned()
    {
        // Arrange
        dynamic parent = new ExpandoObject();
        parent.Child = new object();

        // Act
        dynamic clone = ((ExpandoObject)parent).Clone();

        // Assert
        _ = await Assert.That((ExpandoObject)clone).IsNotStrictlyEqualTo((ExpandoObject)parent);
        _ = await Assert.That((object)clone.Child).IsSameReferenceAs((object)parent.Child);
    }

    [Test]
    public async Task GivenANullObjectWithDefaultIfNullSetToFalseThenAnArgumentNullExceptionIsThrown()
    {
        // Arrange
        ExpandoObject? source = default;

        // Act
        Action act = () => source.Clone(defaultIfNull: false);

        // Assert
        _ = await Assert.That(act).Throws<ArgumentNullException>();
    }

    [Test]
    public async Task GivenANullObjectWithDefaultIfNullSetToTrueThenAnEmptyObjectIsReturned()
    {
        // Arrange
        ExpandoObject? source = default;

        // Act
        ExpandoObject value = source.Clone(defaultIfNull: true);

        // Assert
        _ = await Assert.That(value).IsNotNull();
        _ = await Assert.That(value).IsEmpty();
    }
}