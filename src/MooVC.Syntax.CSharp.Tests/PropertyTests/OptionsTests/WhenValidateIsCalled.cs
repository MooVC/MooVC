namespace MooVC.Syntax.CSharp.PropertyTests.OptionsTests;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public sealed class WhenValidateIsCalled
{
    [Test]
    public async Task GivenAttributesIsNullThenValidationErrorReturned()
    {
        // Arrange
        Attribute.Options? attributes = default;
        Property.Options subject = Property.Options.Default.WithAttributes(attributes!);

        // Act
        List<ValidationResult> results = Validate(subject, out bool valid);

        // Assert
        _ = await Assert.That(valid).IsFalse();
        _ = await Assert.That(results).HasSingleItem();
        _ = await Assert.That(results[0].MemberNames).Contains(nameof(Property.Options.Attributes));
    }

    [Test]
    public async Task GivenImpliedIsNullThenValidationErrorReturned()
    {
        // Arrange
        Scopes? implied = default;
        Property.Options subject = Property.Options.Default.WithImplied(implied!);

        // Act
        List<ValidationResult> results = Validate(subject, out bool valid);

        // Assert
        _ = await Assert.That(valid).IsFalse();
        _ = await Assert.That(results).HasSingleItem();
        _ = await Assert.That(results[0].MemberNames).Contains(nameof(Property.Options.Implied));
    }

    [Test]
    public async Task GivenQualificationsIsNullThenValidationErrorReturned()
    {
        // Arrange
        Qualification.Options? qualifications = default;
        Property.Options subject = Property.Options.Default.WithQualifications(qualifications!);

        // Act
        List<ValidationResult> results = Validate(subject, out bool valid);

        // Assert
        _ = await Assert.That(valid).IsFalse();
        _ = await Assert.That(results).HasSingleItem();
        _ = await Assert.That(results[0].MemberNames).Contains(nameof(Property.Options.Qualifications));
    }

    [Test]
    public async Task GivenSnippetsIsNullThenValidationErrorReturned()
    {
        // Arrange
        Snippet.Options? snippets = default;
        Property.Options subject = Property.Options.Default.WithSnippets(snippets!);

        // Act
        List<ValidationResult> results = Validate(subject, out bool valid);

        // Assert
        _ = await Assert.That(valid).IsFalse();
        _ = await Assert.That(results).HasSingleItem();
        _ = await Assert.That(results[0].MemberNames).Contains(nameof(Property.Options.Snippets));
    }

    private static List<ValidationResult> Validate(object subject, out bool valid)
    {
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        return results;
    }
}