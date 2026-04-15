namespace MooVC.Syntax.CSharp.IndexerTests.OptionsTests;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public sealed class WhenValidateIsCalled
{
    [Test]
    public async Task GivenImpliedIsNullThenValidationErrorReturned()
    {
        // Arrange
        Scopes implied = default;
        Indexer.Options subject = Indexer.Options.Default.WithImplied(implied!);

        // Act
        List<ValidationResult> results = Validate(subject, out bool valid);

        // Assert
        _ = await Assert.That(valid).IsFalse();
        _ = await Assert.That(results).HasSingleItem();
        _ = await Assert.That(results[0].MemberNames).Contains(nameof(Indexer.Options.Implied));
    }

    [Test]
    public async Task GivenSnippetsIsNullThenValidationErrorReturned()
    {
        // Arrange
        Snippet.Options snippets = default;
        Indexer.Options subject = Indexer.Options.Default.WithSnippets(snippets!);

        // Act
        List<ValidationResult> results = Validate(subject, out bool valid);

        // Assert
        _ = await Assert.That(valid).IsFalse();
        _ = await Assert.That(results).HasSingleItem();
        _ = await Assert.That(results[0].MemberNames).Contains(nameof(Indexer.Options.Snippets));
    }

    private static List<ValidationResult> Validate(object subject, out bool valid)
    {
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        return results;
    }
}