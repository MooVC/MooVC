namespace MooVC.Syntax.CSharp.Generics.ParameterTests;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.CSharp.Generics.Constraints;
using MooVC.Syntax.CSharp.Members;
using Parameter = MooVC.Syntax.CSharp.Generics.Parameter;

public sealed class WhenValidateIsCalled
{
    private const string Name = "TValue";
    private const string InterfaceName = "IExample";
    private const string InvalidInterfaceName = "Example";

    [Test]
    public async Task GivenUnnamedParameterThenValidationErrorsReturned()
    {
        // Arrange
        var subject = new Parameter { Constraints = [new() { New = New.Required }] };
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        _ = await Assert.That(valid).IsFalse();
        _ = await Assert.That(results).HasSingleItem();
        _ = await Assert.That(results[0].MemberNames).Contains(nameof(Parameter.Name));
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

        var subject = new Parameter
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
        var subject = new Parameter
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
    public async Task GivenValidParameterThenNoValidationErrorsReturned()
    {
        // Arrange
        var constraint = new Constraint
        {
            Base = new Symbol { Name = "Base" },
            Interfaces = [new Interface(new Declaration { Name = InterfaceName })],
            New = New.Required,
        };

        var subject = new Parameter
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
    public async Task GivenUndefinedParameterThenValidationIsSkipped()
    {
        // Arrange
        Parameter subject = Parameter.Undefined;
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        _ = await Assert.That(valid).IsTrue();
        _ = await Assert.That(results).IsEmpty();
    }
}