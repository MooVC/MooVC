namespace MooVC.Syntax.Resource.ResourceTests;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Resource = Resource;

public sealed class WhenValidateIsCalled
{
    [Test]
    public async Task GivenUndefinedThenReturnsEmptyResults()
    {
        // Arrange
        Resource subject = Resource.Undefined;
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        _ = await Assert.That(valid).IsTrue();
        _ = await Assert.That(results).IsEmpty();
    }

    [Test]
    public async Task GivenUndefinedAssemblyThenValidationErrorReturned()
    {
        // Arrange
        Resource subject = ResourceTestsData.Create(assembly: Assembly.Undefined);
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        _ = await Assert.That(valid).IsFalse();
        _ = await Assert.That(results).HasSingleItem();
        _ = await Assert.That(results[0].MemberNames).Contains(nameof(Resource.Assemblies));
    }

    [Test]
    public async Task GivenUndefinedHeaderThenValidationErrorReturned()
    {
        // Arrange
        Resource subject = ResourceTestsData.Create(header: Header.Undefined);
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        _ = await Assert.That(valid).IsFalse();
        _ = await Assert.That(results).HasSingleItem();
        _ = await Assert.That(results[0].MemberNames).Contains(nameof(Resource.Headers));
    }
}