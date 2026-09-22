namespace MooVC.Syntax.CSharp.OptionsTests;

public sealed class WhenImplicitOperatorToAttributeStylesIsCalled
{
    [Test]
    public async Task GivenNullOptionsThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        Options? subject = default;

        // Act
        Func<Attribute.Options.Styles> act = () => subject!;

        // Assert
        _ = await Assert.That(act).Throws<ArgumentNullException>();
    }

    [Test]
    [Arguments(false)]
    [Arguments(true)]
    public async Task GivenDifferentNestedStylesThenTypeAttributeStyleIsReturned(bool useInlineStyle)
    {
        // Arrange
        Attribute.Options.Styles expected = useInlineStyle ? Attribute.Options.Styles.Inline : Attribute.Options.Styles.Separate;
        Attribute.Options.Styles nested = useInlineStyle ? Attribute.Options.Styles.Separate : Attribute.Options.Styles.Inline;
        Options subject = Options.Default.WithTypes(types => types
            .WithAttributes(attributes => attributes.WithFormat(expected))
            .WithMethods(methods => methods.WithAttributes(attributes => attributes.WithFormat(nested)))
            .WithProperties(properties => properties.WithAttributes(attributes => attributes.WithFormat(nested))));

        // Act
        Attribute.Options.Styles result = subject;

        // Assert
        _ = await Assert.That(result).IsSameReferenceAs(expected);
    }
}