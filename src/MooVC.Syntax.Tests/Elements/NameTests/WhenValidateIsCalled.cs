namespace MooVC.Syntax.Elements.NameTests;

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
        var subject = default;
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeFalse();
        results.Count.ShouldBe(1);
        results[0].MemberNames.ShouldContain(nameof(Name));
        results[0].ErrorMessage.ShouldNotBeNullOrWhiteSpace();
    }

    [Fact]
    public void GivenEmptyThenNoValidationErrorReturned()
    {
        // Arrange
        var subject = Empty;
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeTrue();
        results.ShouldBeEmpty();
    }

    [Fact]
    public void GivenPascalCaseThenNoValidationErrorReturned()
    {
        // Arrange
        var subject = Pascal;
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
        var subject = WithPrefix;
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
        var subject = UpperWithUnderscore;
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
        var subject = UpperWithDigits;
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
        var subject = UnicodePascal;
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeFalse();
        results.Count.ShouldBe(1);
        results[0].MemberNames.ShouldContain(nameof(Name));
        results[0].ErrorMessage.ShouldNotBeNullOrWhiteSpace();
    }

    [Fact]
    public void GivenLowercaseThenValidationErrorsReturned()
    {
        // Arrange
        var subject = Lowercase;
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeFalse();
        results.Count.ShouldBe(1);
        results[0].MemberNames.ShouldContain(nameof(Name));
        results[0].ErrorMessage.ShouldNotBeNullOrWhiteSpace();
    }

    [Fact]
    public void GivenPascalCaseWithHyphenThenValidationErrorsReturned()
    {
        // Arrange
        var subject = WithHyphen;
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeFalse();
        results.Count.ShouldBe(1);
        results[0].MemberNames.ShouldContain(nameof(Name));
        results[0].ErrorMessage.ShouldNotBeNullOrWhiteSpace();
    }

    [Fact]
    public void GivenNumericOnlyThenValidationErrorReturned()
    {
        // Arrange
        var subject = Numeric;
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeFalse();
        results.Count.ShouldBe(1);
        results[0].MemberNames.ShouldContain(nameof(Name));
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
        var subject = value;
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeFalse();
        results.Count.ShouldBe(1);
        results[0].MemberNames.ShouldContain(nameof(Name));
        results[0].ErrorMessage.ShouldNotBeNullOrWhiteSpace();
    }
}