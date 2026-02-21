namespace Mu.Modelling.AreaTests;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public sealed class WhenValidateIsCalled
{
    [Fact]
    public void GivenUndefinedThenValidationIsSkipped()
    {
        // Arrange
        Area subject = Area.Undefined;
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeTrue();
        results.ShouldBeEmpty();
    }

    [Fact]
    public void GivenUndefinedUnitThenValidationErrorReturned()
    {
        // Arrange
        Area subject = Area.Undefined.ResponsibleFor(Unit.Undefined);
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeFalse();
        results.Count.ShouldBe(2);
        results[0].MemberNames.ShouldContain(nameof(Area.Units));
        results[1].MemberNames.ShouldContain(nameof(Unit.Name));
    }
}