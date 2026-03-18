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
        await Assert.That(ReferenceEquals(clone, original)).IsFalse();
        await Assert.That(clone).IsEqualTo(original);
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
        await Assert.That(ReferenceEquals(((ExpandoObject)clone), (ExpandoObject)parent)).IsFalse();
        await Assert.That(ReferenceEquals(((ExpandoObject)clone.Child), (ExpandoObject)parent.Child)).IsFalse();
        await Assert.That(((ExpandoObject)clone.Child)).IsEqualTo((ExpandoObject)parent.Child);
    }

    [Test]
    public async Task GivenANullObjectWithDefaultIfNullSetToFalseThenAnArgumentNullExceptionIsThrown()
    {
        // Arrange
        ExpandoObject? source = default;

        // Act
        Action act = () => source.Clone(defaultIfNull: false);

        // Assert
        await Assert.That(act).Throws<ArgumentNullException>();
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
        await Assert.That(value).IsEmpty();
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
        await Assert.That(ReferenceEquals(((ExpandoObject)clone), (ExpandoObject)parent)).IsFalse();
        await Assert.That(ReferenceEquals(((object)clone.Child), (object)parent.Child)).IsTrue();
    }
}