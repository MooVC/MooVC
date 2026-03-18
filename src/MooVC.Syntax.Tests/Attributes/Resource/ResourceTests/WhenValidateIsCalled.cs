namespace MooVC.Syntax.Attributes.Resource.ResourceTests;

using System.ComponentModel.DataAnnotations;
using MooVC.Syntax.Elements;

public sealed class WhenValidateIsCalled
{
    [Test]
    public async Task GivenUndefinedThenNoValidationErrorReturned()
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
    public async Task GivenMultiLineCustomToolNamespaceThenValidationErrorReturned()
    {
        // Arrange
        var subject = new Resource
        {
            CustomToolNamespace = Snippet.From($"Line1{Environment.NewLine}Line2"),
            Location = new Path(ResourceTestsData.DefaultLocationPath),
        };

        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        _ = await Assert.That(valid).IsFalse();
        _ = await Assert.That(results).HasSingleItem();
        _ = await Assert.That(results[0].MemberNames).Contains(nameof(Resource.CustomToolNamespace));
    }

    [Test]
    public async Task GivenEmptyLocationThenValidationErrorReturned()
    {
        // Arrange
        var subject = new Resource
        {
            CustomToolNamespace = Snippet.From(ResourceTestsData.DefaultCustomToolNamespace),
        };

        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        _ = await Assert.That(valid).IsFalse();
        _ = await Assert.That(results).HasSingleItem();
        _ = await Assert.That(results[0].MemberNames).Contains(nameof(Resource.Location));
    }

    [Test]
    public async Task GivenValidValuesThenNoValidationErrorReturned()
    {
        // Arrange
        Resource subject = ResourceTestsData.Create();
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        _ = await Assert.That(valid).IsTrue();
        _ = await Assert.That(results).IsEmpty();
    }
}