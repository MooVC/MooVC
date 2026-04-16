namespace MooVC.Syntax.CSharp.SymbolTests;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public sealed class WhenValidateIsCalled
{
    private const string Name = "Result";
    private const string ArgumentName = "Inner";

    [Test]
    public async Task GivenArgumentWithValidationErrorsThenValidationErrorsReturned()
    {
        // Arrange
        var symbol = new Symbol
        {
            Arguments = [new() { Name = "Invalid Name" }],
            Name = Name,
        };

        var context = new ValidationContext(symbol);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(symbol, context, results, validateAllProperties: true);

        // Assert
        _ = await Assert.That(valid).IsFalse();
        _ = await Assert.That(results).HasSingleItem();
        _ = await Assert.That(results[0].MemberNames).Contains(nameof(Moniker));
        _ = await Assert.That(results[0].ErrorMessage).IsNotNull().And.IsNotEmpty();
    }

    [Test]
    public async Task GivenUnnamedSymbolThenValidationErrorReturned()
    {
        // Arrange
        var symbol = new Symbol
        {
            Arguments = [new() { Name = "Test" }],
        };

        var context = new ValidationContext(symbol);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(symbol, context, results, validateAllProperties: true);

        // Assert
        _ = await Assert.That(valid).IsFalse();
        _ = await Assert.That(results).HasSingleItem();
        _ = await Assert.That(results[0].MemberNames).Contains(nameof(Symbol.Name));
        _ = await Assert.That(results[0].ErrorMessage).IsNotNull().And.IsNotEmpty();
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
        _ = await Assert.That(valid).IsFalse();
        _ = await Assert.That(results).HasSingleItem();
        _ = await Assert.That(results[0].MemberNames).Contains(nameof(Symbol.Arguments));
        _ = await Assert.That(results[0].ErrorMessage).IsNotNull().And.IsNotEmpty();
    }

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
        _ = await Assert.That(valid).IsTrue();
        _ = await Assert.That(results).IsEmpty();
    }

    [Test]
    public async Task GivenValidSymbolThenNoValidationErrorsReturned()
    {
        // Arrange
        var symbol = new Symbol
        {
            Name = Name,
            Arguments = [new() { Name = ArgumentName }],
        };

        var context = new ValidationContext(symbol);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(symbol, context, results, validateAllProperties: true);

        // Assert
        _ = await Assert.That(valid).IsTrue();
        _ = await Assert.That(results).IsEmpty();
    }
}