namespace MooVC.Syntax.CSharp.IndexerTests;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public sealed class WhenValidateIsCalled
{
    [Test]
    public async Task GivenUndefinedThenNoValidationErrorsReturned()
    {
        // Arrange
        Indexer subject = Indexer.Undefined;
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        _ = await Assert.That(valid).IsTrue();
        _ = await Assert.That(results).IsEmpty();
    }

    [Test]
    public async Task GivenDefaultBehavioursThenValidationErrorReturned()
    {
        // Arrange
        Indexer subject = IndexerTestsData.Create();
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        _ = await Assert.That(valid).IsFalse();
        _ = await Assert.That(results).HasSingleItem();
        _ = await Assert.That(results[0].MemberNames).Contains(nameof(Indexer.Behaviours));
        _ = await Assert.That(results[0].ErrorMessage).IsNotNull().And.IsNotEmpty();
    }

    [Test]
    public async Task GivenVoidResultThenValidationErrorReturned()
    {
        // Arrange
        Indexer subject = IndexerTestsData.Create(
            behaviours: new Indexer.Methods { Get = Snippet.From("value") },
            result: Result.Void);

        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        _ = await Assert.That(valid).IsFalse();
        _ = await Assert.That(results).HasSingleItem();
        _ = await Assert.That(results[0].MemberNames).Contains(nameof(Indexer.Result));
        _ = await Assert.That(results[0].ErrorMessage).IsNotNull().And.IsNotEmpty();
    }

    [Test]
    public async Task GivenInvalidParameterThenValidationErrorReturned()
    {
        // Arrange
        Indexer subject = IndexerTestsData.Create(
            behaviours: new Indexer.Methods { Get = Snippet.From("value") },
            parameter: new Parameter
            {
                Default = Snippet.From($"first{Environment.NewLine}second"),
                Name = IndexerTestsData.DefaultParameterName,
                Type = new Symbol { Name = IndexerTestsData.DefaultParameterType },
            });

        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        _ = await Assert.That(valid).IsFalse();
        _ = await Assert.That(results).HasSingleItem();
        _ = await Assert.That(results[0].MemberNames).Contains(nameof(Parameter.Default));
        _ = await Assert.That(results[0].ErrorMessage).IsNotNull().And.IsNotEmpty();
    }

    [Test]
    public async Task GivenValidIndexerThenNoValidationErrorsReturned()
    {
        // Arrange
        Indexer subject = IndexerTestsData.Create(
            behaviours: new Indexer.Methods { Get = Snippet.From("value") });

        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        _ = await Assert.That(valid).IsTrue();
        _ = await Assert.That(results).IsEmpty();
    }
}