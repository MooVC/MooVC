namespace MooVC.Data.IFeatureExtensionsTests;

using System.Diagnostics.CodeAnalysis;

public sealed class WhenWithIsCalled
{
    [Fact]
    public void GivenANullSubjectThenAnArgumentNullExceptionIsThrown()
    {
        // Arrange
        IFeature<TestAttribute>? subject = default;
        var attribute = new TestAttribute();

        // Act
        Func<IFeature<TestAttribute>> act = () => subject!.With(attribute);

        // Assert
        _ = act.Should().Throw<ArgumentNullException>()
            .WithParameterName(nameof(subject));
    }

    [Fact]
    public void GivenANullAttributeThenAnArgumentNullExceptionIsThrown()
    {
        // Arrange
        IFeature<TestAttribute> subject = Substitute.For<IFeature<TestAttribute>>();
        TestAttribute? attribute = default;

        // Act
        Func<IFeature<TestAttribute>> act = () => subject.With(attribute!);

        // Assert
        _ = act.Should().Throw<ArgumentNullException>()
            .WithParameterName(nameof(attribute));
    }

    [Fact]
    public void GivenAValidSubjectAndAttributeThenTheAttributeIsAssigned()
    {
        // Arrange
        var expected = new TestAttribute();
        IFeature<TestAttribute> subject = Substitute.For<IFeature<TestAttribute>>();

        // Act
        IFeature<TestAttribute> result = subject.With(expected);

        // Assert
        _ = result.Should().NotBeNull();
        _ = result.Attribute.Should().BeSameAs(expected);
    }

    [Fact]
    public void GivenAValidSubjectAndAttributeMutatorThenTheAttributeIsAssigned()
    {
        // Arrange
        var expected = new TestAttribute();
        IFeature<TestAttribute> subject = Substitute.For<IFeature<TestAttribute>>();
        Mutator<TestAttribute> mutator = attribute => expected;

        // Act
        IFeature<TestAttribute> result = subject.With(mutator);

        // Assert
        _ = result.Should().NotBeNull();
        _ = result.Attribute.Should().BeSameAs(expected);
    }

    [SuppressMessage("Minor Code Smell", "S2094:Classes should not be empty", Justification = "Contents are not required for the test.")]
    [SuppressMessage("CodeQuality", "IDE0079:Remove unnecessary suppression", Justification = "False positive, S2094 violation.")]
    public sealed class TestAttribute
    {
    }
}