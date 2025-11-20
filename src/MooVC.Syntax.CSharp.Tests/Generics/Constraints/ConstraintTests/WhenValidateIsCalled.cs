namespace MooVC.Syntax.CSharp.Generics.Constraints.ConstraintTests;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using MooVC.Syntax.CSharp.Generics;
using MemberIdentifier = MooVC.Syntax.CSharp.Members.Identifier;

public sealed class WhenValidateIsCalled
{
    private const string BaseName = "Result";
    private const string InterfaceName = "IValid";
    private const string InvalidInterfaceName = "Invalid";

    [Fact]
    public void GivenUnspecifiedConstraintThenNoValidationErrorsReturned()
    {
        // Arrange
        Constraint constraint = Constraint.Unspecified;
        var context = new ValidationContext(constraint);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(constraint, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeTrue();
        results.ShouldBeEmpty();
    }

    [Fact]
    public void GivenInvalidInterfaceThenValidationErrorsReturned()
    {
        // Arrange
        var constraint = new Constraint
        {
            Interfaces = [new MemberIdentifier(InvalidInterfaceName)],
        };

        var context = new ValidationContext(constraint);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(constraint, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeFalse();
        _ = results.ShouldHaveSingleItem();
        results[0].MemberNames.ShouldContain(nameof(Constraint.Interfaces));
        results[0].ErrorMessage.ShouldNotBeNullOrWhiteSpace();
    }

    [Fact]
    public void GivenInvalidBaseThenValidationErrorsReturned()
    {
        // Arrange
        var constraint = new Constraint
        {
            Base = new Symbol(),
        };

        var context = new ValidationContext(constraint);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(constraint, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeFalse();
        _ = results.ShouldHaveSingleItem();
        results[0].MemberNames.ShouldContain(nameof(Constraint.Base));
        results[0].ErrorMessage.ShouldNotBeNullOrWhiteSpace();
    }

    [Fact]
    public void GivenValidConstraintThenNoValidationErrorsReturned()
    {
        // Arrange
        var constraint = new Constraint
        {
            Nature = Nature.Struct,
            Base = new Symbol { Name = new MemberIdentifier(BaseName) },
            Interfaces = [new MemberIdentifier(InterfaceName)],
            New = New.Required,
        };

        var context = new ValidationContext(constraint);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(constraint, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeTrue();
        results.ShouldBeEmpty();
    }

    [Fact]
    public void GivenMultipleInvalidValuesThenAllValidationErrorsReturned()
    {
        // Arrange
        var constraint = new Constraint
        {
            Base = new Symbol(),
            Interfaces = [new MemberIdentifier(InvalidInterfaceName)],
        };

        var context = new ValidationContext(constraint);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(constraint, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeFalse();
        results.ShouldNotBeEmpty();
        results.ShouldContain(result => result.MemberNames.Contains(nameof(Constraint.Base)));
        results.ShouldContain(result => result.MemberNames.Contains(nameof(Constraint.Interfaces)));
    }
}
