namespace MooVC.Syntax.CSharp.ConstraintTests;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

public sealed class WhenValidateIsCalled
{
    private const string BaseName = "Result";
    private const string InterfaceName = "IValid";
    private const string InvalidInterfaceName = "Invalid Interface";
    private const string InvalidName = "Invalid Name";

    [Test]
    public async Task GivenInvalidBaseThenValidationErrorsReturned()
    {
        // Arrange
        var constraint = new Constraint
        {
            Base = new Symbol() { Name = InvalidName },
        };

        var context = new ValidationContext(constraint);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(constraint, context, results, validateAllProperties: true);

        // Assert
        _ = await Assert.That(valid).IsFalse();
        _ = await Assert.That(results).HasSingleItem();
        _ = await Assert.That(results[0].MemberNames).Contains(nameof(Symbol.Moniker));
        _ = await Assert.That(results[0].ErrorMessage).IsNotNull().And.IsNotEmpty();
    }

    [Test]
    public async Task GivenInvalidInterfaceThenValidationErrorsReturned()
    {
        // Arrange
        var constraint = new Constraint
        {
            Interfaces = [new(new() { Name = InvalidInterfaceName })],
        };

        var context = new ValidationContext(constraint);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(constraint, context, results, validateAllProperties: true);

        // Assert
        _ = await Assert.That(valid).IsFalse();
        _ = await Assert.That(results).HasSingleItem();
        _ = await Assert.That(results[0].MemberNames).Contains(nameof(Implementation));
        _ = await Assert.That(results[0].ErrorMessage).IsNotNull().And.IsNotEmpty();
    }

    [Test]
    public async Task GivenMultipleInvalidValuesThenAllValidationErrorsReturned()
    {
        // Arrange
        var constraint = new Constraint
        {
            Base = new Symbol() { Name = InvalidName },
            Interfaces = [new(new() { Name = InvalidInterfaceName })],
        };

        var context = new ValidationContext(constraint);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(constraint, context, results, validateAllProperties: true);

        // Assert
        _ = await Assert.That(valid).IsFalse();
        _ = await Assert.That(results).IsNotEmpty();
        _ = await Assert.That(results).Contains(result => result.MemberNames.Contains(nameof(Symbol.Moniker)));
        _ = await Assert.That(results).Contains(result => result.MemberNames.Contains(nameof(Implementation)));
    }

    [Test]
    public async Task GivenUnspecifiedConstraintThenNoValidationErrorsReturned()
    {
        // Arrange
        Constraint constraint = Constraint.Unspecified;
        var context = new ValidationContext(constraint);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(constraint, context, results, validateAllProperties: true);

        // Assert
        _ = await Assert.That(valid).IsTrue();
        _ = await Assert.That(results).IsEmpty();
    }

    [Test]
    public async Task GivenValidConstraintThenNoValidationErrorsReturned()
    {
        // Arrange
        var constraint = new Constraint
        {
            Nature = Nature.Struct,
            Base = new Symbol() { Name = BaseName },
            Interfaces = [new(new() { Name = InterfaceName })],
            New = New.Required,
        };

        var context = new ValidationContext(constraint);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(constraint, context, results, validateAllProperties: true);

        // Assert
        _ = await Assert.That(valid).IsTrue();
        _ = await Assert.That(results).IsEmpty();
    }
}