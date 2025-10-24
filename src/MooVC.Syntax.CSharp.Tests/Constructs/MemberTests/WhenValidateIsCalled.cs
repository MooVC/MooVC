namespace MooVC.Syntax.CSharp.Constructs.MemberTests;

using System.ComponentModel.DataAnnotations;

public sealed class WhenValidateIsCalled
{
    private const string Empty = "";
    private const string Pascal = "MyMember";
    private const string Camel = "myMember";
    private const string Snake = "my_member";
    private const string Kebab = "my-member";
    private const string Numeric = "123";
    private const string UnicodePascal = "Álpha";

    [Fact]
    public void GivenNullValueWhenValidatedThenValidationErrorReturned()
    {
        // Arrange
        var subject = new Member(default);
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeFalse();
        results.Count.ShouldBe(1);
        results[0].MemberNames.ShouldContain(nameof(Member));
        results[0].ErrorMessage.ShouldNotBeNullOrWhiteSpace();
    }

    [Fact]
    public void GivenEmptyWhenValidatedThenValidationErrorReturned()
    {
        // Arrange
        var subject = new Member(Empty);
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeFalse();
        results.Count.ShouldBe(1);
        results[0].MemberNames.ShouldContain(nameof(Member));
        results[0].ErrorMessage.ShouldNotBeNullOrWhiteSpace();
    }

    [Fact]
    public void GivenPascalCaseWhenValidatedThenNoValidationErrorReturned()
    {
        // Arrange
        var subject = new Member(Pascal);
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeTrue();
        results.Count.ShouldBe(0);
    }

    [Fact]
    public void GivenUnicodeTitleCaseWhenValidatedThenValidationErrorReturned()
    {
        // Arrange
        var subject = new Member(UnicodePascal);
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeFalse();
        results.Count.ShouldBe(1);
        results[0].MemberNames.ShouldContain(nameof(Member));
        results[0].ErrorMessage.ShouldNotBeNullOrWhiteSpace();
    }

    [Fact]
    public void GivenCamelCaseWhenValidatedThenValidationErrorsReturned()
    {
        // Arrange
        var subject = new Member(Camel);
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeFalse();
        results.Count.ShouldBe(1);
        results[0].MemberNames.ShouldContain(nameof(Member));
        results[0].ErrorMessage.ShouldNotBeNullOrWhiteSpace();
    }

    [Fact]
    public void GivenSnakeCaseWhenValidatedThenNoValidationErrorsReturned()
    {
        // Arrange
        var subject = new Member(Snake);
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeFalse();
        results.Count.ShouldBe(1);
        results[0].MemberNames.ShouldContain(nameof(Member));
        results[0].ErrorMessage.ShouldNotBeNullOrWhiteSpace();
    }

    [Fact]
    public void GivenKebabCaseWhenValidatedThenValidationErrorsReturned()
    {
        // Arrange
        var subject = new Member(Kebab);
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeFalse();
        results.Count.ShouldBe(1);
        results[0].MemberNames.ShouldContain(nameof(Member));
        results[0].ErrorMessage.ShouldNotBeNullOrWhiteSpace();
    }

    [Fact]
    public void GivenNumericOnlyWhenValidatedThenValidationErrorReturned()
    {
        // Arrange
        var subject = new Member(Numeric);
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeFalse();
        results.Count.ShouldBe(1);
        results[0].MemberNames.ShouldContain(nameof(Member));
        results[0].ErrorMessage.ShouldNotBeNullOrWhiteSpace();
    }

    [Theory]
    [InlineData(" Alpha")]
    [InlineData("Alpha ")]
    [InlineData("Alpha Beta")]
    [InlineData("Alpha\tBeta")]
    [InlineData("Alpha\nBeta")]
    public void GivenWhitespacePresentWhenValidatedThenValidationErrorReturned(string value)
    {
        // Arrange
        var subject = new Member(value);
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeFalse();
        results.Count.ShouldBe(1);
        results[0].MemberNames.ShouldContain(nameof(Member));
        results[0].ErrorMessage.ShouldNotBeNullOrWhiteSpace();
    }
}