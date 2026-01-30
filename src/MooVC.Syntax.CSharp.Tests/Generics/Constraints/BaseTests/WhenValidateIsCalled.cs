namespace MooVC.Syntax.CSharp.Generics.Constraints.BaseTests;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MooVC.Syntax.CSharp.Elements;

public sealed class WhenValidateIsCalled
{
    private const string BaseName = "Result";

    [Fact]
    public void GivenUnspecifiedBaseThenNoValidationErrorsReturned()
    {
        // Arrange
        Base subject = Base.Unspecified;
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeTrue();
        results.ShouldBeEmpty();
    }

    [Fact]
    public void GivenInvalidBaseThenValidationErrorsReturned()
    {
        // Arrange
        var subject = new Base(new Symbol { Name = "Invalid Symbol Name" });
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeFalse();
        _ = results.ShouldHaveSingleItem();
        results[0].MemberNames.ShouldContain(nameof(Variable));
        results[0].ErrorMessage.ShouldNotBeNullOrWhiteSpace();
    }

    [Fact]
    public void GivenValidBaseThenNoValidationErrorsReturned()
    {
        // Arrange
        Base subject = new Symbol { Name = new Variable(BaseName) };
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeTrue();
        results.ShouldBeEmpty();
    }
}