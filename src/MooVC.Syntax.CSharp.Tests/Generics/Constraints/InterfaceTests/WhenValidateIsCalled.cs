namespace MooVC.Syntax.CSharp.Generics.Constraints.InterfaceTests;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MooVC.Syntax.CSharp.Members;
using Parameter = MooVC.Syntax.CSharp.Generics.Parameter;

public sealed class WhenValidateIsCalled
{
    private const string ValidInterfaceName = "IValid";
    private const string InvalidInterfaceName = "Invalid Name";

    [Fact]
    public void GivenValidInterfaceThenNoValidationErrorsReturned()
    {
        // Arrange
        Interface subject = new Declaration
        {
            Name = ValidInterfaceName,
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
    public void GivenInvalidNameThenValidationErrorsReturned()
    {
        // Arrange
        Interface subject = new Declaration
        {
            Name = InvalidInterfaceName,
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
    public void GivenTooShortNameThenValidationErrorsReturned()
    {
        // Arrange
        Interface subject = new Members.Declaration
        {
            Name = "I",
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
    public void GivenInvalidDeclarationThenValidationErrorsReturned()
    {
        // Arrange
        Interface subject = new Members.Declaration
        {
            Parameters = [new Parameter()],
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
}