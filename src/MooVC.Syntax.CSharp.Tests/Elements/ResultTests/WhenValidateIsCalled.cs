namespace MooVC.Syntax.CSharp.Elements.ResultTests;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public sealed class WhenValidateIsCalled
{
    [Fact]
    public void GivenUndefinedTypeWithModifierThenValidationFails()
    {
        // Arrange
        var subject = new Result
        {
            Modifier = Result.Kind.Ref,
        };

        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeFalse();
        results.ShouldContain(result => result.MemberNames.Contains(nameof(Result.Type)));
    }

    [Fact]
    public void GivenDefaultResultThenValidationSucceeds()
    {
        // Arrange
        var subject = new Result();
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeTrue();
        results.ShouldBeEmpty();
    }
}