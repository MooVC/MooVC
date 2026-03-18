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

    [Test]
    public async Task GivenNullValueThenValidationErrorReturned()
    {
        // Arrange
        var subject = new Name(default);
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        await Assert.That(valid).IsFalse();
        await Assert.That(results.Count).IsEqualTo(1);
        await Assert.That(results[0].MemberNames).Contains(nameof(Name));
        await Assert.That(results[0].ErrorMessage).IsNotNull().And.IsNotEmpty();
    }

    [Test]
    public async Task GivenEmptyThenNoValidationErrorReturned()
    {
        // Arrange
        var subject = new Name(Empty);
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        await Assert.That(valid).IsTrue();
        await Assert.That(results).IsEmpty();
    }

    [Test]
    public async Task GivenPascalCaseThenNoValidationErrorReturned()
    {
        // Arrange
        var subject = new Name(Pascal);
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        await Assert.That(valid).IsTrue();
        await Assert.That(results.Count).IsEqualTo(0);
    }

    [Test]
    public async Task GivenPascalCaseWithPrefixThenNoValidationErrorReturned()
    {
        // Arrange
        var subject = new Name(WithPrefix);
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        await Assert.That(valid).IsTrue();
        await Assert.That(results.Count).IsEqualTo(0);
    }

    [Test]
    public async Task GivenPascalCaseWithUnderscoreThenNoValidationErrorReturned()
    {
        // Arrange
        var subject = new Name(UpperWithUnderscore);
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        await Assert.That(valid).IsTrue();
        await Assert.That(results.Count).IsEqualTo(0);
    }

    [Test]
    public async Task GivenPascalCaseWithDigitsThenNoValidationErrorReturned()
    {
        // Arrange
        var subject = new Name(UpperWithDigits);
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        await Assert.That(valid).IsTrue();
        await Assert.That(results.Count).IsEqualTo(0);
    }

    [Test]
    public async Task GivenUnicodeTitleCaseThenValidationErrorReturned()
    {
        // Arrange
        var subject = new Name(UnicodePascal);
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        await Assert.That(valid).IsFalse();
        await Assert.That(results.Count).IsEqualTo(1);
        await Assert.That(results[0].MemberNames).Contains(nameof(Name));
        await Assert.That(results[0].ErrorMessage).IsNotNull().And.IsNotEmpty();
    }

    [Test]
    public async Task GivenLowercaseThenValidationErrorsReturned()
    {
        // Arrange
        var subject = new Name(Lowercase);
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        await Assert.That(valid).IsFalse();
        await Assert.That(results.Count).IsEqualTo(1);
        await Assert.That(results[0].MemberNames).Contains(nameof(Name));
        await Assert.That(results[0].ErrorMessage).IsNotNull().And.IsNotEmpty();
    }

    [Test]
    public async Task GivenPascalCaseWithHyphenThenValidationErrorsReturned()
    {
        // Arrange
        var subject = new Name(WithHyphen);
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        await Assert.That(valid).IsFalse();
        await Assert.That(results.Count).IsEqualTo(1);
        await Assert.That(results[0].MemberNames).Contains(nameof(Name));
        await Assert.That(results[0].ErrorMessage).IsNotNull().And.IsNotEmpty();
    }

    [Test]
    public async Task GivenNumericOnlyThenValidationErrorReturned()
    {
        // Arrange
        var subject = new Name(Numeric);
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        await Assert.That(valid).IsFalse();
        await Assert.That(results.Count).IsEqualTo(1);
        await Assert.That(results[0].MemberNames).Contains(nameof(Name));
        await Assert.That(results[0].ErrorMessage).IsNotNull().And.IsNotEmpty();
    }

    [Test]
    [Arguments(" MySegment")]
    [Arguments("MySegment ")]
    [Arguments("My Segment")]
    [Arguments("My\tSegment")]
    [Arguments("My\nSegment")]
    public async Task GivenWhitespacePresentThenValidationErrorReturned(string value)
    {
        // Arrange
        var subject = new Name(value);
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        await Assert.That(valid).IsFalse();
        await Assert.That(results.Count).IsEqualTo(1);
        await Assert.That(results[0].MemberNames).Contains(nameof(Name));
        await Assert.That(results[0].ErrorMessage).IsNotNull().And.IsNotEmpty();
    }
}