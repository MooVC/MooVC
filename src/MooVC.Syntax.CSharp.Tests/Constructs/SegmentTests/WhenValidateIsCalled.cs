namespace MooVC.Syntax.CSharp.Constructs.SegmentTests;

using System.ComponentModel.DataAnnotations;

public sealed class WhenValidateIsCalled
{
    private const string Empty = "";
    private const string Pascal = "MySegment";
    private const string UpperWithUnderscore = "My_Segment";
    private const string UpperWithDigits = "MySegment1";
    private const string WithPrefix = "@MySegment";
    private const string Lowercase = "mySegment";
    private const string Numeric = "123";
    private const string UnicodePascal = "Álpha";
    private const string WithHyphen = "My-Segment";

    [Fact]
    public void GivenNullValueThenValidationErrorReturned()
    {
        // Arrange
        var subject = new Segment(default);
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeFalse();
        results.Count.ShouldBe(1);
        results[0].MemberNames.ShouldContain(nameof(Segment));
        results[0].ErrorMessage.ShouldNotBeNullOrWhiteSpace();
    }

    [Fact]
    public void GivenEmptyThenValidationErrorReturned()
    {
        // Arrange
        var subject = new Segment(Empty);
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeFalse();
        results.Count.ShouldBe(1);
        results[0].MemberNames.ShouldContain(nameof(Segment));
        results[0].ErrorMessage.ShouldNotBeNullOrWhiteSpace();
    }

    [Fact]
    public void GivenPascalCaseThenNoValidationErrorReturned()
    {
        // Arrange
        var subject = new Segment(Pascal);
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeTrue();
        results.Count.ShouldBe(0);
    }

    [Fact]
    public void GivenPascalCaseWithPrefixThenNoValidationErrorReturned()
    {
        // Arrange
        var subject = new Segment(WithPrefix);
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeTrue();
        results.Count.ShouldBe(0);
    }

    [Fact]
    public void GivenPascalCaseWithUnderscoreThenNoValidationErrorReturned()
    {
        // Arrange
        var subject = new Segment(UpperWithUnderscore);
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeTrue();
        results.Count.ShouldBe(0);
    }

    [Fact]
    public void GivenPascalCaseWithDigitsThenNoValidationErrorReturned()
    {
        // Arrange
        var subject = new Segment(UpperWithDigits);
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeTrue();
        results.Count.ShouldBe(0);
    }

    [Fact]
    public void GivenUnicodeTitleCaseThenValidationErrorReturned()
    {
        // Arrange
        var subject = new Segment(UnicodePascal);
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeFalse();
        results.Count.ShouldBe(1);
        results[0].MemberNames.ShouldContain(nameof(Segment));
        results[0].ErrorMessage.ShouldNotBeNullOrWhiteSpace();
    }

    [Fact]
    public void GivenLowercaseThenValidationErrorsReturned()
    {
        // Arrange
        var subject = new Segment(Lowercase);
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeFalse();
        results.Count.ShouldBe(1);
        results[0].MemberNames.ShouldContain(nameof(Segment));
        results[0].ErrorMessage.ShouldNotBeNullOrWhiteSpace();
    }

    [Fact]
    public void GivenPascalCaseWithHyphenThenValidationErrorsReturned()
    {
        // Arrange
        var subject = new Segment(WithHyphen);
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeFalse();
        results.Count.ShouldBe(1);
        results[0].MemberNames.ShouldContain(nameof(Segment));
        results[0].ErrorMessage.ShouldNotBeNullOrWhiteSpace();
    }

    [Fact]
    public void GivenNumericOnlyThenValidationErrorReturned()
    {
        // Arrange
        var subject = new Segment(Numeric);
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeFalse();
        results.Count.ShouldBe(1);
        results[0].MemberNames.ShouldContain(nameof(Segment));
        results[0].ErrorMessage.ShouldNotBeNullOrWhiteSpace();
    }

    [Theory]
    [InlineData(" MySegment")]
    [InlineData("MySegment ")]
    [InlineData("My Segment")]
    [InlineData("My\tSegment")]
    [InlineData("My\nSegment")]
    public void GivenWhitespacePresentThenValidationErrorReturned(string value)
    {
        // Arrange
        var subject = new Segment(value);
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeFalse();
        results.Count.ShouldBe(1);
        results[0].MemberNames.ShouldContain(nameof(Segment));
        results[0].ErrorMessage.ShouldNotBeNullOrWhiteSpace();
    }
}
