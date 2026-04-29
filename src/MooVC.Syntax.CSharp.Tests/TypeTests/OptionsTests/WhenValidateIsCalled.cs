namespace MooVC.Syntax.CSharp.TypeTests.OptionsTests;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public sealed class WhenValidateIsCalled
{
    [Test]
    public async Task GivenAttributesIsNullThenValidationErrorReturned()
    {
        // Arrange
        Attribute.Options? attributes = default;
        Type.Options subject = Type.Options.Default.WithAttributes(attributes!);

        // Act
        List<ValidationResult> results = Validate(subject, out bool valid);

        // Assert
        _ = await Assert.That(valid).IsFalse();
        _ = await Assert.That(results).HasSingleItem();
        _ = await Assert.That(results[0].MemberNames).Contains(nameof(Type.Options.Attributes));
    }

    [Test]
    public async Task GivenEventsIsNullThenValidationErrorReturned()
    {
        // Arrange
        Event.Options? events = default;
        Type.Options subject = Type.Options.Default.WithEvents(events!);

        // Act
        List<ValidationResult> results = Validate(subject, out bool valid);

        // Assert
        _ = await Assert.That(valid).IsFalse();
        _ = await Assert.That(results).HasSingleItem();
        _ = await Assert.That(results[0].MemberNames).Contains(nameof(Type.Options.Events));
    }

    [Test]
    public async Task GivenIndexersIsNullThenValidationErrorReturned()
    {
        // Arrange
        Indexer.Options? indexers = default;
        Type.Options subject = Type.Options.Default.WithIndexers(indexers!);

        // Act
        List<ValidationResult> results = Validate(subject, out bool valid);

        // Assert
        _ = await Assert.That(valid).IsFalse();
        _ = await Assert.That(results).HasSingleItem();
        _ = await Assert.That(results[0].MemberNames).Contains(nameof(Type.Options.Indexers));
    }

    [Test]
    public async Task GivenMethodsIsNullThenValidationErrorReturned()
    {
        // Arrange
        Method.Options? methods = default;
        Type.Options subject = Type.Options.Default.WithMethods(methods!);

        // Act
        List<ValidationResult> results = Validate(subject, out bool valid);

        // Assert
        _ = await Assert.That(valid).IsFalse();
        _ = await Assert.That(results).HasSingleItem();
        _ = await Assert.That(results[0].MemberNames).Contains(nameof(Type.Options.Methods));
    }

    [Test]
    public async Task GivenPropertiesIsNullThenValidationErrorReturned()
    {
        // Arrange
        Property.Options? properties = default;
        Type.Options subject = Type.Options.Default.WithProperties(properties!);

        // Act
        List<ValidationResult> results = Validate(subject, out bool valid);

        // Assert
        _ = await Assert.That(valid).IsFalse();
        _ = await Assert.That(results).HasSingleItem();
        _ = await Assert.That(results[0].MemberNames).Contains(nameof(Type.Options.Properties));
    }

    [Test]
    public async Task GivenQualificationsIsNullThenValidationErrorReturned()
    {
        // Arrange
        Qualification.Options? qualifications = default;
        Type.Options subject = Type.Options.Default.WithQualifications(qualifications!);

        // Act
        List<ValidationResult> results = Validate(subject, out bool valid);

        // Assert
        _ = await Assert.That(valid).IsFalse();
        _ = await Assert.That(results).HasSingleItem();
        _ = await Assert.That(results[0].MemberNames).Contains(nameof(Type.Options.Qualifications));
    }

    [Test]
    public async Task GivenSnippetsIsNullThenValidationErrorReturned()
    {
        // Arrange
        Snippet.Options? snippets = default;
        Type.Options subject = Type.Options.Default.WithSnippets(snippets!);

        // Act
        List<ValidationResult> results = Validate(subject, out bool valid);

        // Assert
        _ = await Assert.That(valid).IsFalse();
        _ = await Assert.That(results).HasSingleItem();
        _ = await Assert.That(results[0].MemberNames).Contains(nameof(Type.Options.Snippets));
    }

    private static List<ValidationResult> Validate(object subject, out bool valid)
    {
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        return results;
    }
}