namespace MooVC.Syntax.CSharp.Elements.ArgumentTests;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MooVC.Syntax.Elements;

public sealed class WhenValidateIsCalled
{
    private const string Name = "Value";
    private const string Value = "42";

    [Fact]
    public void GivenUndefinedThenNoValidationErrorsReturned()
    {
        // Arrange
        Argument subject = Argument.Undefined;
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeTrue();
        results.ShouldBeEmpty();
    }

    [Fact]
    public void GivenEmptyValueThenValidationErrorReturned()
    {
        // Arrange
        var subject = new Argument
        {
            Name = new Identifier(Name),
        };

        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeFalse();
        _ = results.ShouldHaveSingleItem();
        results[0].MemberNames.ShouldContain(nameof(Argument.Value));
        results[0].ErrorMessage.ShouldNotBeNullOrWhiteSpace();
    }

    [Fact]
    public void GivenMultilineValueThenValidationErrorReturned()
    {
        // Arrange
        var subject = new Argument
        {
            Name = new Identifier(Name),
            Value = Snippet.From($"line1{Environment.NewLine}line2"),
        };

        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeFalse();
        _ = results.ShouldHaveSingleItem();
        results[0].MemberNames.ShouldContain(nameof(Argument.Value));
        results[0].ErrorMessage.ShouldNotBeNullOrWhiteSpace();
    }

    [Fact]
    public void GivenValidArgumentThenNoValidationErrorsReturned()
    {
        // Arrange
        var subject = new Argument
        {
            Name = new Identifier(Name),
            Value = Snippet.From(Value),
        };

        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeTrue();
        results.ShouldBeEmpty();
    }
}