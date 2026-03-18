namespace MooVC.Syntax.CSharp.Elements.SymbolTests;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MooVC.Syntax.Elements;

public sealed class WhenValidateIsCalled
{
    private const string Name = "Result";
    private const string ArgumentName = "Inner";

    [Test]
    public async Task GivenUnspecifiedSymbolThenNoValidationErrorsReturned()
    {
        // Arrange
        Symbol symbol = Symbol.Undefined;
        var context = new ValidationContext(symbol);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(symbol, context, results, validateAllProperties: true);

        // Assert
        await Assert.That(valid).IsTrue();
        await Assert.That(results).IsEmpty();
    }

    [Test]
    public async Task GivenUnnamedSymbolThenValidationErrorReturned()
    {
        // Arrange
        var symbol = new Symbol
        {
            Arguments = [new Symbol { Name = "Test" }],
        };

        var context = new ValidationContext(symbol);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(symbol, context, results, validateAllProperties: true);

        // Assert
        await Assert.That(valid).IsFalse();
        _ = await results.Single();
        await Assert.That(results[0].MemberNames).Contains(nameof(Symbol.Name));
        await Assert.That(results[0].ErrorMessage).IsNotNull().And.IsNotEmpty();
    }

    [Test]
    public async Task GivenUnspecifiedArgumentThenValidationErrorReturned()
    {
        // Arrange
        var symbol = new Symbol
        {
            Name = Name,
            Arguments = [Symbol.Undefined],
        };

        var context = new ValidationContext(symbol);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(symbol, context, results, validateAllProperties: true);

        // Assert
        await Assert.That(valid).IsFalse();
        _ = await results.Single();
        await Assert.That(results[0].MemberNames).Contains(nameof(Symbol.Arguments));
        await Assert.That(results[0].ErrorMessage).IsNotNull().And.IsNotEmpty();
    }

    [Test]
    public async Task GivenArgumentWithValidationErrorsThenValidationErrorsReturned()
    {
        // Arrange
        var symbol = new Symbol
        {
            Arguments = [new Symbol { Name = "Invalid Name" }],
            Name = Name,
        };

        var context = new ValidationContext(symbol);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(symbol, context, results, validateAllProperties: true);

        // Assert
        await Assert.That(valid).IsFalse();
        _ = await results.Single();
        await Assert.That(results[0].MemberNames).Contains(nameof(Symbol.Moniker));
        await Assert.That(results[0].ErrorMessage).IsNotNull().And.IsNotEmpty();
    }

    [Test]
    public async Task GivenQualifierWithValidationErrorsThenValidationErrorsReturned()
    {
        // Arrange
        var symbol = new Symbol
        {
            Name = Name,
            Qualifier = new Name[] { "invalid" },
        };

        var context = new ValidationContext(symbol);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(symbol, context, results, validateAllProperties: true);

        // Assert
        await Assert.That(valid).IsFalse();
        _ = await results.Single();
        await Assert.That(results[0].MemberNames).Contains(nameof(Name));
        await Assert.That(results[0].ErrorMessage).IsNotNull().And.IsNotEmpty();
    }

    [Test]
    public async Task GivenValidSymbolThenNoValidationErrorsReturned()
    {
        // Arrange
        var symbol = new Symbol
        {
            Name = Name,
            Arguments = [new Symbol { Name = ArgumentName }],
        };

        var context = new ValidationContext(symbol);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(symbol, context, results, validateAllProperties: true);

        // Assert
        await Assert.That(valid).IsTrue();
        await Assert.That(results).IsEmpty();
    }
}