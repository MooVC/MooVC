namespace MooVC.Syntax.CSharp.Constructs.NamespaceTests;

using System.ComponentModel.DataAnnotations;

public sealed class WhenValidateIsCalled
{
    [Fact]
    public void GivenNullValueThenValidationErrorReturned()
    {
        // Arrange
        var subject = new Namespace(default);
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeFalse();
        results.Count.ShouldBe(1);
        results[0].MemberNames.ShouldContain(nameof(Namespace));
        results[0].ErrorMessage.ShouldNotBeNullOrWhiteSpace();
    }

    [Fact]
    public void GivenEmptyThenValidationErrorReturned()
    {
        // Arrange
        var subject = new Namespace(Array.Empty<Segment>());
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeFalse();
        results.Count.ShouldBe(1);
        results[0].MemberNames.ShouldContain(nameof(Namespace));
        results[0].ErrorMessage.ShouldNotBeNullOrWhiteSpace();
    }

    [Fact]
    public void GivenValidSegmentsThenNoValidationErrorReturned()
    {
        // Arrange
        var subject = new Namespace(new[] { new Segment("Alpha"), new Segment("Beta") });
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeTrue();
        results.Count.ShouldBe(0);
    }

    [Fact]
    public void GivenNullSegmentThenValidationErrorReturned()
    {
        // Arrange
        var subject = new Namespace(new[] { new Segment("Alpha"), null! });
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeFalse();
        results.Count.ShouldBe(1);
        results[0].MemberNames.ShouldContain(nameof(Namespace));
        results[0].ErrorMessage.ShouldNotBeNullOrWhiteSpace();
    }

    [Fact]
    public void GivenInvalidSegmentThenValidationErrorReturned()
    {
        // Arrange
        var subject = new Namespace(new[] { new Segment("Alpha"), new Segment("beta") });
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeFalse();
        results.Count.ShouldBe(1);
        results[0].MemberNames.ShouldContain(nameof(Namespace));
        results[0].ErrorMessage.ShouldNotBeNullOrWhiteSpace();
    }

    [Theory]
    [InlineData(" Alpha")]
    [InlineData("Alpha ")]
    [InlineData("Alpha Beta")]
    [InlineData("Alpha\tBeta")]
    [InlineData("Alpha\nBeta")]
    public void GivenWhitespaceInSegmentThenValidationErrorReturned(string value)
    {
        // Arrange
        var subject = new Namespace(new[] { new Segment("Alpha"), new Segment(value) });
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeFalse();
        results.Count.ShouldBe(1);
        results[0].MemberNames.ShouldContain(nameof(Namespace));
        results[0].ErrorMessage.ShouldNotBeNullOrWhiteSpace();
    }
}
