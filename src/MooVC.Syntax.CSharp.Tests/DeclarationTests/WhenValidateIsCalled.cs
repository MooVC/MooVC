namespace MooVC.Syntax.CSharp.DeclarationTests;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Argument = MooVC.Syntax.CSharp.Generics.Argument;

public sealed class WhenValidateIsCalled
{
    private const string Name = "Result";

    [Test]
    public async Task GivenUnspecifiedDeclarationThenNoValidationErrorsReturned()
    {
        // Arrange
        Declaration declaration = Declaration.Unspecified;
        var context = new ValidationContext(declaration);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(declaration, context, results, validateAllProperties: true);

        // Assert
        _ = await Assert.That(valid).IsTrue();
        _ = await Assert.That(results).IsEmpty();
    }

    [Test]
    public async Task GivenUnnamedDeclarationThenValidationErrorReturned()
    {
        // Arrange
        var declaration = new Declaration
        {
            Arguments = [new Argument { Name = "T" }],
        };

        var context = new ValidationContext(declaration);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(declaration, context, results, validateAllProperties: true);

        // Assert
        _ = await Assert.That(valid).IsFalse();
        _ = await Assert.That(results).HasSingleItem();
        _ = await Assert.That(results[0].MemberNames).Contains(nameof(Declaration.Name));
        _ = await Assert.That(results[0].ErrorMessage).IsNotNull().And.IsNotEmpty();
    }

    [Test]
    public async Task GivenInvalidParameterThenValidationErrorReturned()
    {
        // Arrange
        var declaration = new Declaration
        {
            Name = Name,
            Arguments = [new Argument { Name = "Invalid Name" }],
        };

        var context = new ValidationContext(declaration);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(declaration, context, results, validateAllProperties: true);

        // Assert
        _ = await Assert.That(valid).IsFalse();
        _ = await Assert.That(results).HasSingleItem();
        _ = await Assert.That(results[0].MemberNames).Contains(nameof(Name));
        _ = await Assert.That(results[0].ErrorMessage).IsNotNull().And.IsNotEmpty();
    }

    [Test]
    public async Task GivenValidDeclarationThenNoValidationErrorsReturned()
    {
        // Arrange
        var declaration = new Declaration
        {
            Name = Name,
            Arguments = [new Argument { Name = "T" }],
        };

        var context = new ValidationContext(declaration);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(declaration, context, results, validateAllProperties: true);

        // Assert
        _ = await Assert.That(valid).IsTrue();
        _ = await Assert.That(results).IsEmpty();
    }
}