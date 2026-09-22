namespace MooVC.Syntax.CSharp.OptionsTests;

public sealed class WhenImplicitOperatorToQualificationOptionsIsCalled
{
    [Test]
    public async Task GivenNullOptionsThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        Options? subject = default;

        // Act
        Func<Qualification.Options> act = () => subject!;

        // Assert
        _ = await Assert.That(act).Throws<ArgumentNullException>();
    }

    [Test]
    [Arguments(false)]
    [Arguments(true)]
    public async Task GivenDifferentNestedQualificationsThenTypeQualificationsAreReturned(bool useUnspecifiedQualifications)
    {
        // Arrange
        Qualification.Options expected = useUnspecifiedQualifications
            ? Qualification.Options.Unspecified
            : Qualification.Options.Default.WithFormat(Qualification.Options.Formats.Global);
        Qualification.Options nested = Qualification.Options.Default.WithFormat(Qualification.Options.Formats.Full);
        Options subject = Options.Default.WithTypes(types => types
            .WithQualifications(expected)
            .WithAttributes(attributes => attributes.WithQualifications(nested))
            .WithMethods(methods => methods.WithQualifications(nested))
            .WithProperties(properties => properties.WithQualifications(nested)));

        // Act
        Qualification.Options result = subject;

        // Assert
        _ = await Assert.That(result).IsSameReferenceAs(expected);
        _ = await Assert.That(subject.Types.Qualifications).IsSameReferenceAs(expected);
    }
}