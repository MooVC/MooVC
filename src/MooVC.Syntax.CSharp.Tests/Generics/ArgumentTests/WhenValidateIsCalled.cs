namespace MooVC.Syntax.CSharp.Generics.ArgumentTests;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Argument = MooVC.Syntax.CSharp.Generics.Argument;

public sealed class WhenValidateIsCalled
{
    private const string Name = "TValue";
    private const string InterfaceName = "IExample";
    private const string InvalidInterfaceName = "Example";

    [Test]
    public async Task GivenUnnamedArgumentThenValidationErrorsReturned()
    {
        // Arrange
        var subject = new Argument { Constraints = [new() { New = New.Required }] };
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        _ = await Assert.That(valid).IsFalse();
        _ = await Assert.That(results).HasSingleItem();
        _ = await Assert.That(results[0].MemberNames).Contains(nameof(Argument.Name));
        _ = await Assert.That(results[0].ErrorMessage).IsNotNull().And.IsNotEmpty();
    }

    [Test]
    public async Task GivenConstraintsWithValidationErrorsThenValidationErrorsReturned()
    {
        // Arrange
        var constraint = new Constraint
        {
            Interfaces = [new Interface(new Declaration { Name = InvalidInterfaceName })],
        };

        var subject = new Argument
        {
            Name = Name,
            Constraints = [constraint],
        };

        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        _ = await Assert.That(valid).IsFalse();
        _ = await Assert.That(results).HasSingleItem();
        _ = await Assert.That(results[0].MemberNames).Contains(nameof(Interface));
        _ = await Assert.That(results[0].ErrorMessage).IsNotNull().And.IsNotEmpty();
    }

    [Test]
    public async Task GivenNameWithNoConstraintsThenNoValidationErrorsReturned()
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
        _ = await Assert.That(valid).IsTrue();
        _ = await Assert.That(results).IsEmpty();
    }

    [Test]
    public async Task GivenValidArgumentThenNoValidationErrorsReturned()
    {
        // Arrange
        var constraint = new Constraint
        {
            Base = new Symbol { Name = "Base" },
            Interfaces = [new Interface(new Declaration { Name = InterfaceName })],
            New = New.Required,
        };

        var subject = new Argument
        {
            Name = Name,
            Constraints = [constraint],
        };

        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        _ = await Assert.That(valid).IsTrue();
        _ = await Assert.That(results).IsEmpty();
    }

    [Test]
    public async Task GivenUndefinedArgumentThenValidationIsSkipped()
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
}