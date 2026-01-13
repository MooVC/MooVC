namespace MooVC.Syntax.Attributes.Solution.ConfigurationsTests.BuildTypeTests;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MooVC.Syntax.Attributes.Solution;

public sealed class WhenValidateIsCalled
{
    [Fact]
    public void GivenUnnamedThenValidationIsSkipped()
    {
        // Arrange
        Configurations.BuildType subject = Configurations.BuildType.Unnamed;
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeTrue();
        results.ShouldBeEmpty();
    }

    [Fact]
    public void GivenInvalidValueThenValidationErrorReturned()
    {
        // Arrange
        var subject = new Configurations.BuildType(" Invalid");
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeFalse();
        _ = results.ShouldHaveSingleItem();
        results[0].MemberNames.ShouldContain(nameof(Configurations.BuildType));
    }
}