namespace Mu.Modelling.ViewTests;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MooVC.Syntax.Elements;

public sealed class WhenValidateIsCalled
{
    private const string ViewNameValue = "View";

    [Fact]
    public void GivenUndefinedThenValidationIsSkipped()
    {
        // Arrange
        View subject = View.Undefined;
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeTrue();
        results.ShouldBeEmpty();
    }

    [Fact]
    public void GivenUnqualifiedFactThenValidationErrorReturned()
    {
        // Arrange
        View subject = View.Undefined
            .Named(ViewNameValue)
            .RenderedOn(Qualifier.Unqualified);

        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeFalse();
        _ = results.ShouldHaveSingleItem();
        results[0].MemberNames.ShouldContain(nameof(View.Facts));
    }
}