namespace MooVC.Syntax.CSharp.Generics.IdentifierTests;

using System.ComponentModel.DataAnnotations;

public sealed class WhenValidateIsCalled
{
    private const string ValidSimple = "T";
    private const string ValidComplex = "TValue";
    private const string InvalidLowercase = "tValue";

    [Test]
    public async Task GivenUnnamedIdentifierThenNoValidationErrorsReturned()
    {
        // Arrange
        Identifier subject = Identifier.Unnamed;
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        await Assert.That(valid).IsTrue();
        await Assert.That(results).IsEmpty();
    }

    [Test]
    [Arguments(ValidSimple)]
    [Arguments(ValidComplex)]
    public async Task GivenValidNamesThenNoValidationErrorsReturned(string name)
    {
        // Arrange
        var subject = new Identifier(name);
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        await Assert.That(valid).IsTrue();
        await Assert.That(results).IsEmpty();
    }

    [Test]
    public async Task GivenEmptyNameThenValidationErrorsReturned()
    {
        // Arrange
        var subject = new Identifier(" ");
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        await Assert.That(valid).IsFalse();
        _ = await results.Single();
        await Assert.That(results[0].MemberNames).Contains(nameof(Identifier));
        await Assert.That(results[0].ErrorMessage).IsNotNull().And.IsNotEmpty();
    }

    [Test]
    public async Task GivenInvalidNameThenValidationErrorsReturned()
    {
        // Arrange
        var subject = new Identifier(InvalidLowercase);
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        await Assert.That(valid).IsFalse();
        _ = await results.Single();
        await Assert.That(results[0].MemberNames).Contains(nameof(Identifier));
        await Assert.That(results[0].ErrorMessage).IsNotNull().And.IsNotEmpty();
    }
}