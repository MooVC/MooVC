namespace MooVC.Syntax.CSharp.ArgumentTests;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public sealed class WhenValidateIsCalled
{
    private const string Name = "Value";
    private const string Value = "42";

    [Test]
    public async Task GivenEmptyValueThenValidationErrorReturned()
    {
        // Arrange
        var subject = new Argument
        {
            Name = Name,
        };

        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        _ = await Assert.That(valid).IsFalse();
        _ = await Assert.That(results).HasSingleItem();
        _ = await Assert.That(results[0].MemberNames).Contains(nameof(Argument.Value));
        _ = await Assert.That(results[0].ErrorMessage).IsNotNull().And.IsNotEmpty();
    }

    [Test]
    public async Task GivenMultilineValueThenValidationErrorReturned()
    {
        // Arrange
        var subject = new Argument
        {
            Name = new(Name),
            Value = Snippet.From($"line1{Environment.NewLine}line2"),
        };

        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        _ = await Assert.That(valid).IsFalse();
        _ = await Assert.That(results).HasSingleItem();
        _ = await Assert.That(results[0].MemberNames).Contains(nameof(Argument.Value));
        _ = await Assert.That(results[0].ErrorMessage).IsNotNull().And.IsNotEmpty();
    }

    [Test]
    public async Task GivenUndefinedThenNoValidationErrorsReturned()
    {
        // Arrange
        Argument subject = Argument.Undefined;
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        _ = await Assert.That(valid).IsTrue();
        _ = await Assert.That(results).IsEmpty();
    }

    [Test]
    public async Task GivenValidArgumentThenNoValidationErrorsReturned()
    {
        // Arrange
        var subject = new Argument
        {
            Name = new(Name),
            Value = Snippet.From(Value),
        };

        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        _ = await Assert.That(valid).IsTrue();
        _ = await Assert.That(results).IsEmpty();
    }
}