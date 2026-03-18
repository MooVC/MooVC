namespace MooVC.Syntax.CSharp.Members.DirectiveTests;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MooVC.Syntax.Elements;

public sealed class WhenValidateIsCalled
{
    private const string Alias = "Alias";
    private const string InvalidAlias = "alias";

    [Test]
    public async Task GivenUndefinedDirectiveThenValidationIsSkipped()
    {
        // Arrange
        Directive subject = Directive.Undefined;
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        _ = await Assert.That(valid).IsTrue();
        _ = await Assert.That(results).IsEmpty();
    }

    [Test]
    public async Task GivenStaticAliasThenValidationErrorReturned()
    {
        // Arrange
        var subject = new Directive
        {
            Alias = new Name(Alias),
            IsStatic = true,
            Qualifier = new Qualifier(["System", "Console"]),
        };

        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        _ = await Assert.That(valid).IsFalse();
        _ = await results.Single();
        _ = await Assert.That(results[0].MemberNames).Contains(nameof(Directive.Alias));
        _ = await Assert.That(results[0].ErrorMessage).IsNotNull().And.IsNotEmpty();
    }

    [Test]
    public async Task GivenInvalidAliasThenValidationErrorReturned()
    {
        // Arrange
        var subject = new Directive
        {
            Alias = new Name(InvalidAlias),
            Qualifier = new Qualifier(["MooVC", "Syntax"]),
        };

        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        _ = await Assert.That(valid).IsFalse();
        _ = await results.Single();
        _ = await Assert.That(results[0].MemberNames).Contains(nameof(Name));
        _ = await Assert.That(results[0].ErrorMessage).IsNotNull().And.IsNotEmpty();
    }

    [Test]
    public async Task GivenInvalidQualifierThenValidationErrorReturned()
    {
        // Arrange
        var subject = new Directive
        {
            Qualifier = new Qualifier([Name.Unnamed, "Syntax"]),
        };

        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        _ = await Assert.That(valid).IsFalse();
        _ = await results.Single();
        _ = await Assert.That(results[0].MemberNames).Contains("Qualifier[0]");
        _ = await Assert.That(results[0].ErrorMessage).IsNotNull().And.IsNotEmpty();
    }

    [Test]
    public async Task GivenValidDirectiveThenNoValidationErrorsReturned()
    {
        // Arrange
        var subject = new Directive
        {
            Qualifier = new Qualifier(["MooVC", "Syntax"]),
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