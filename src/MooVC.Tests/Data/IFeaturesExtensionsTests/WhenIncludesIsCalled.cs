namespace MooVC.Data.IFeaturesExtensionsTests;

using System.Diagnostics.CodeAnalysis;

public sealed class WhenIncludesIsCalled
{
    [Fact]
    public void GivenANullSubjectThenAnArgumentNullExceptionIsThrownForAttribute()
    {
        // Arrange
        IFeatures<TestAttribute>? subject = default;
        Mutator<TestAttribute> attribute = _ => new TestAttribute();

        // Act
        Func<IFeatures<TestAttribute>> act = () => subject!.Includes(attribute);

        // Assert
        _ = act.Should().Throw<ArgumentNullException>()
            .WithParameterName(nameof(subject));
    }

    [Fact]
    public void GivenANullAttributeThenAnArgumentNullExceptionIsThrownForMutator()
    {
        // Arrange
        IFeatures<TestAttribute> subject = Substitute.For<IFeatures<TestAttribute>>();
        Mutator<TestAttribute>? attribute = default;

        // Act
        Func<IFeatures<TestAttribute>> act = () => subject.Includes(attribute!);

        // Assert
        _ = act.Should().Throw<ArgumentNullException>()
            .WithParameterName(nameof(attribute));
    }

    [Fact]
    public void GivenAValidSubjectAndAttributeMutatorThenTheAttributeIsIncluded()
    {
        // Arrange
        IFeatures<TestAttribute> subject = Substitute.For<IFeatures<TestAttribute>>();
        var expected = new TestAttribute();
        Mutator<TestAttribute> attribute = _ => expected;

        _ = subject.Attributes.Returns([]);

        // Act
        IFeatures<TestAttribute> result = subject.Includes(attribute);

        // Assert
        _ = result.Attributes.Should().ContainSingle()
            .Which.Should().BeSameAs(expected);
    }

    [Fact]
    public void GivenANullAttributesArrayThenAnArgumentNullExceptionIsThrown()
    {
        // Arrange
        IFeatures<TestAttribute> subject = Substitute.For<IFeatures<TestAttribute>>();
        TestAttribute[]? attributes = default;

        // Act
        Func<IFeatures<TestAttribute>> act = () => subject.Includes(attributes!);

        // Assert
        _ = act.Should().Throw<ArgumentNullException>()
            .WithParameterName(nameof(attributes));
    }

    [Fact]
    public void GivenAValidSubjectAndAttributesArrayThenTheAttributesAreIncluded()
    {
        // Arrange
        IFeatures<TestAttribute> subject = Substitute.For<IFeatures<TestAttribute>>();
        TestAttribute[] expected = [new(), new()];
        _ = subject.Attributes.Returns([]);

        // Act
        IFeatures<TestAttribute> result = subject.Includes(expected);

        // Assert
        _ = result.Attributes.Should().HaveCount(expected.Length)
            .And.Contain(expected);
    }

    [SuppressMessage("Minor Code Smell", "S2094:Classes should not be empty", Justification = "Contents are not required for the test.")]
    [SuppressMessage("CodeQuality", "IDE0079:Remove unnecessary suppression", Justification = "False positive, S2094 violation.")]
    public sealed class TestAttribute
    {
    }
}