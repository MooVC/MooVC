namespace MooVC.Syntax.CSharp.OptionsTests;

public sealed class WhenImplicitOperatorToQualificationFormatsIsCalled
{
    [Test]
    public async Task GivenNullOptionsThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        Options? subject = default;

        // Act
        Func<Qualification.Options.Formats> act = () => subject!;

        // Assert
        _ = await Assert.That(act).Throws<ArgumentNullException>();
    }

    [Test]
    [Arguments(false)]
    [Arguments(true)]
    public async Task GivenDifferentNestedFormatsThenTypeQualificationFormatIsReturned(bool useGlobalFormat)
    {
        // Arrange
        Qualification.Options.Formats expected = useGlobalFormat
            ? Qualification.Options.Formats.Global
            : Qualification.Options.Formats.Minimum;
        Qualification.Options nested = Qualification.Options.Default.WithFormat(Qualification.Options.Formats.Full);
        Options subject = Options.Default.WithTypes(types => types
            .WithQualifications(qualifications => qualifications.WithFormat(expected))
            .WithAttributes(attributes => attributes.WithQualifications(nested))
            .WithMethods(methods => methods.WithQualifications(nested))
            .WithProperties(properties => properties.WithQualifications(nested)));

        // Act
        Qualification.Options.Formats result = subject;

        // Assert
        _ = await Assert.That(result).IsSameReferenceAs(expected);
    }
}