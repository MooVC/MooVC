namespace MooVC.Syntax.CSharp.OptionsTests;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public sealed class WhenValidateIsCalled
{
    [Test]
    public async Task GivenNamespaceIsNullThenValidationErrorReturned()
    {
        // Arrange
        Qualifier.Options? optionsNamespace = null;
        Options subject = Options.Default.WithNamespace(optionsNamespace!);

        // Act
        List<ValidationResult> results = Validate(subject, out bool valid);

        // Assert
        _ = await Assert.That(valid).IsFalse();
        _ = await Assert.That(results).HasSingleItem();
        _ = await Assert.That(results[0].MemberNames).Contains(nameof(Options.Namespace));
    }

    [Test]
    public async Task GivenSnippetsIsNullThenValidationErrorReturned()
    {
        // Arrange
        Snippet.Options? snippets = null;
        Options subject = Options.Default.WithSnippets(snippets!);

        // Act
        List<ValidationResult> results = Validate(subject, out bool valid);

        // Assert
        _ = await Assert.That(valid).IsFalse();
        _ = await Assert.That(results).HasSingleItem();
        _ = await Assert.That(results[0].MemberNames).Contains(nameof(Options.Snippets));
    }

    [Test]
    public async Task GivenTypesIsNullThenValidationErrorReturned()
    {
        // Arrange
        Type.Options? typeOptions = null;
        Options subject = Options.Default.WithTypes(typeOptions!);

        // Act
        List<ValidationResult> results = Validate(subject, out bool valid);

        // Assert
        _ = await Assert.That(valid).IsFalse();
        _ = await Assert.That(results).HasSingleItem();
        _ = await Assert.That(results[0].MemberNames).Contains(nameof(Options.Types));
    }

    private static List<ValidationResult> Validate(object subject, out bool valid)
    {
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        return results;
    }
}