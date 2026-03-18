namespace MooVC.Syntax.CSharp.GenericTests;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public sealed class WhenValidateIsCalled
{
    private const string Name = "TValue";
    private const string InterfaceName = "IExample";
    private const string InvalidInterfaceName = "Example";

    [Test]
    public async Task GivenUnnamedArgumentThenValidationErrorsReturned()
    {
        // Arrange
        var subject = new Generic { Constraints = [new() { New = New.Required }] };
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        _ = await Assert.That(valid).IsFalse();
        _ = await Assert.That(results).HasSingleItem();
        _ = await Assert.That(results[0].MemberNames).Contains(nameof(Generic.Name));
        _ = await Assert.That(results[0].ErrorMessage).IsNotNull().And.IsNotEmpty();
    }

    [Test]
    public async Task GivenConstraintsWithValidationErrorsThenValidationErrorsReturned()
    {
        // Arrange
        var constraint = new Constraint
        {
            Interfaces = [new Implementation(new Declaration { Name = InvalidInterfaceName })],
        };

        var subject = new Generic
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
        _ = await Assert.That(results[0].MemberNames).Contains(nameof(Implementation));
        _ = await Assert.That(results[0].ErrorMessage).IsNotNull().And.IsNotEmpty();
    }

    [Test]
    public async Task GivenNameWithNoConstraintsThenNoValidationErrorsReturned()
    {
        // Arrange
        var subject = new Generic
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
            Interfaces = [new Implementation(new Declaration { Name = InterfaceName })],
            New = New.Required,
        };

        var subject = new Generic
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
        Generic subject = Generic.Undefined;
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        _ = await Assert.That(valid).IsTrue();
        _ = await Assert.That(results).IsEmpty();
    }
}