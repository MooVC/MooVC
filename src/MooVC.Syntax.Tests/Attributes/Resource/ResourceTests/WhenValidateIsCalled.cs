namespace MooVC.Syntax.Attributes.Resource.ResourceTests;

using System.ComponentModel.DataAnnotations;
using MooVC.Syntax.Elements;

public sealed class WhenValidateIsCalled
{
    [Fact]
    public void GivenUndefinedThenNoValidationErrorReturned()
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

    [Fact]
    public void GivenMultiLineCustomToolNamespaceThenValidationErrorReturned()
    {
        // Arrange
        var subject = new Resource
        {
            CustomToolNamespace = $"Line1{Environment.NewLine}Line2",
            Location = new Path(ResourceTestsData.DefaultLocationPath),
        };

        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeFalse();
        results.Count.ShouldBe(1);
        results[0].MemberNames.ShouldContain(nameof(Resource.CustomToolNamespace));
    }

    [Fact]
    public void GivenEmptyLocationThenValidationErrorReturned()
    {
        // Arrange
        var subject = new Resource
        {
            CustomToolNamespace = ResourceTestsData.DefaultCustomToolNamespace,
        };

        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeFalse();
        results.Count.ShouldBe(1);
        results[0].MemberNames.ShouldContain(nameof(Resource.Location));
    }

    [Fact]
    public void GivenValidValuesThenNoValidationErrorReturned()
    {
        // Arrange
        Resource subject = ResourceTestsData.Create();
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeTrue();
        results.ShouldBeEmpty();
    }
}