namespace MooVC.Syntax.CSharp.Members.IndexerTests;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public sealed class WhenValidateIsCalled
{
    [Fact]
    public void GivenUndefinedThenNoValidationErrorsReturned()
    {
        // Arrange
        Indexer subject = Indexer.Undefined;
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeTrue();
        results.ShouldBeEmpty();
    }

    [Fact]
    public void GivenDefaultBehavioursThenValidationErrorReturned()
    {
        // Arrange
        Indexer subject = IndexerTestsData.Create();
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeFalse();
        _ = results.ShouldHaveSingleItem();
        results[0].MemberNames.ShouldContain(nameof(Indexer.Behaviours));
        results[0].ErrorMessage.ShouldNotBeNullOrWhiteSpace();
    }

    [Fact]
    public void GivenVoidResultThenValidationErrorReturned()
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
        valid.ShouldBeFalse();
        _ = results.ShouldHaveSingleItem();
        results[0].MemberNames.ShouldContain(nameof(Indexer.Result));
        results[0].ErrorMessage.ShouldNotBeNullOrWhiteSpace();
    }

    [Fact]
    public void GivenInvalidParameterThenValidationErrorReturned()
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
        valid.ShouldBeFalse();
        _ = results.ShouldHaveSingleItem();
        results[0].MemberNames.ShouldContain(nameof(Parameter.Default));
        results[0].ErrorMessage.ShouldNotBeNullOrWhiteSpace();
    }

    [Fact]
    public void GivenValidIndexerThenNoValidationErrorsReturned()
    {
        // Arrange
        Indexer subject = IndexerTestsData.Create(
            behaviours: new Indexer.Methods { Get = Snippet.From("value") });

        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeTrue();
        results.ShouldBeEmpty();
    }
}
