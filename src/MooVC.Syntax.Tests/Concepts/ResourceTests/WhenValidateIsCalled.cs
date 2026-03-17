namespace MooVC.Syntax.Concepts.ResourceTests;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MooVC.Syntax.Attributes.Resource;
using Resource = MooVC.Syntax.Concepts.Resource;

public sealed class WhenValidateIsCalled
{
    [Test]
    public void GivenUndefinedThenReturnsEmptyResults()
    {
        // Arrange
        Resource subject = Resource.Undefined;
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeTrue();
        results.ShouldBeEmpty();
    }

    [Test]
    public void GivenUndefinedAssemblyThenValidationErrorReturned()
    {
        // Arrange
        Resource subject = ResourceTestsData.Create(assembly: Assembly.Undefined);
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeFalse();
        _ = results.ShouldHaveSingleItem();
        results[0].MemberNames.ShouldContain(nameof(Resource.Assemblies));
    }

    [Test]
    public void GivenUndefinedHeaderThenValidationErrorReturned()
    {
        // Arrange
        Resource subject = ResourceTestsData.Create(header: Header.Undefined);
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeFalse();
        _ = results.ShouldHaveSingleItem();
        results[0].MemberNames.ShouldContain(nameof(Resource.Headers));
    }
}