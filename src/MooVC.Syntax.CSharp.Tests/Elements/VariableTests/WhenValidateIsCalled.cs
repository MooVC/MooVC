namespace MooVC.Syntax.CSharp.Elements.VariableTests;

using System.ComponentModel.DataAnnotations;
using MooVC.Syntax.Elements;

public sealed class WhenValidateIsCalled
{
    private const string Empty = "";
    private const string Pascal = "MyMember";
    private const string Camel = "myMember";
    private const string Snake = "my_member";
    private const string Kebab = "my-member";
    private const string Numeric = "123";
    private const string UnicodePascal = "Álpha";

    [Test]
    public async Task GivenNullValueThenNoValidationErrorReturned()
    {
        // Arrange
        var subject = new Variable(default(Identifier));
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        _ = await Assert.That(valid).IsTrue();
        _ = await Assert.That(results).IsEmpty();
    }

    [Test]
    public async Task GivenEmptyThenNoValidationErrorReturned()
    {
        // Arrange
        var subject = new Variable(Empty);
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        _ = await Assert.That(valid).IsTrue();
        _ = await Assert.That(results).IsEmpty();
    }

    [Test]
    public async Task GivenPascalCaseThenNoValidationErrorReturned()
    {
        // Arrange
        var subject = new Variable(Pascal);
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        _ = await Assert.That(valid).IsTrue();
        _ = await Assert.That(results.Count).IsEqualTo(0);
    }

    [Test]
    public async Task GivenUnicodeTitleCaseThenValidationErrorReturned()
    {
        // Arrange
        var subject = new Variable(UnicodePascal);
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        _ = await Assert.That(valid).IsFalse();
        _ = await Assert.That(results.Count).IsEqualTo(1);
        _ = await Assert.That(results[0].MemberNames).Contains(nameof(Variable));
        _ = await Assert.That(results[0].ErrorMessage).IsNotNull().And.IsNotEmpty();
    }

    [Test]
    public async Task GivenCamelCaseThenValidationErrorsReturned()
    {
        // Arrange
        var subject = new Variable(Camel);
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        _ = await Assert.That(valid).IsFalse();
        _ = await Assert.That(results.Count).IsEqualTo(1);
        _ = await Assert.That(results[0].MemberNames).Contains(nameof(Variable));
        _ = await Assert.That(results[0].ErrorMessage).IsNotNull().And.IsNotEmpty();
    }

    [Test]
    public async Task GivenSnakeCaseThenNoValidationErrorsReturned()
    {
        // Arrange
        var subject = new Variable(Snake);
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        _ = await Assert.That(valid).IsFalse();
        _ = await Assert.That(results.Count).IsEqualTo(1);
        _ = await Assert.That(results[0].MemberNames).Contains(nameof(Variable));
        _ = await Assert.That(results[0].ErrorMessage).IsNotNull().And.IsNotEmpty();
    }

    [Test]
    public async Task GivenKebabCaseThenValidationErrorsReturned()
    {
        // Arrange
        var subject = new Variable(Kebab);
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        _ = await Assert.That(valid).IsFalse();
        _ = await Assert.That(results.Count).IsEqualTo(1);
        _ = await Assert.That(results[0].MemberNames).Contains(nameof(Variable));
        _ = await Assert.That(results[0].ErrorMessage).IsNotNull().And.IsNotEmpty();
    }

    [Test]
    public async Task GivenNumericOnlyThenValidationErrorReturned()
    {
        // Arrange
        var subject = new Variable(Numeric);
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        _ = await Assert.That(valid).IsFalse();
        _ = await Assert.That(results.Count).IsEqualTo(1);
        _ = await Assert.That(results[0].MemberNames).Contains(nameof(Variable));
        _ = await Assert.That(results[0].ErrorMessage).IsNotNull().And.IsNotEmpty();
    }

    [Test]
    [Arguments(" Alpha")]
    [Arguments("Alpha ")]
    [Arguments("Alpha Beta")]
    [Arguments("Alpha\tBeta")]
    [Arguments("Alpha\nBeta")]
    public async Task GivenWhitespacePresentThenValidationErrorReturned(string value)
    {
        // Arrange
        var subject = new Variable(value);
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        _ = await Assert.That(valid).IsFalse();
        _ = await Assert.That(results.Count).IsEqualTo(1);
        _ = await Assert.That(results[0].MemberNames).Contains(nameof(Variable));
        _ = await Assert.That(results[0].ErrorMessage).IsNotNull().And.IsNotEmpty();
    }
}