namespace MooVC.Syntax.CSharp.Generics.ParameterTests;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MooVC.Syntax.CSharp.Generics.Constraints;
using MooVC.Syntax.CSharp.Members;

public sealed class WhenValidateIsCalled
{
    private const string Name = "TValue";
    private const string InterfaceName = "IExample";
    private const string InvalidInterfaceName = "Example";

    [Fact]
    public void GivenUnnamedParameterThenValidationErrorsReturned()
    {
        // Arrange
        var subject = new Parameter();
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeFalse();
        _ = results.ShouldHaveSingleItem();
        results[0].MemberNames.ShouldContain(nameof(Parameter.Name));
        results[0].ErrorMessage.ShouldNotBeNullOrWhiteSpace();
    }

    [Fact]
    public void GivenConstraintsWithValidationErrorsThenValidationErrorsReturned()
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
        valid.ShouldBeFalse();
        _ = results.ShouldHaveSingleItem();
        results[0].MemberNames.ShouldContain(nameof(Interface));
        results[0].ErrorMessage.ShouldNotBeNullOrWhiteSpace();
    }

    [Fact]
    public void GivenNameWithNoConstraintsThenNoValidationErrorsReturned()
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
        valid.ShouldBeTrue();
        results.ShouldBeEmpty();
    }

    [Fact]
    public void GivenValidParameterThenNoValidationErrorsReturned()
    {
        // Arrange
        var constraint = new Constraint
        {
            Base = new Symbol { Name = new Identifier("Base") },
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
        valid.ShouldBeTrue();
        results.ShouldBeEmpty();
    }
}