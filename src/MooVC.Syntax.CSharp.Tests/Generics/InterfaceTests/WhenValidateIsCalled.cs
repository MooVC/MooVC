namespace MooVC.Syntax.CSharp.Generics.InterfaceTests;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Argument = MooVC.Syntax.CSharp.Generics.Argument;

public sealed class WhenValidateIsCalled
{
    private const string ValidInterfaceName = "IValid";
    private const string InvalidInterfaceName = "Invalid Name";

    [Test]
    public async Task GivenValidInterfaceThenNoValidationErrorsReturned()
    {
        // Arrange
        Interface subject = new Declaration
        {
            Name = ValidInterfaceName,
        };

        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        _ = await Assert.That(valid).IsTrue();
        _ = await Assert.That(results).IsEmpty();
    }

    [Test]
    public async Task GivenInvalidNameThenValidationErrorsReturned()
    {
        // Arrange
        Interface subject = new Declaration
        {
            Name = InvalidInterfaceName,
        };

        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        _ = await Assert.That(valid).IsFalse();
        _ = await Assert.That(results).HasSingleItem();
        _ = await Assert.That(results[0].MemberNames).Contains(nameof(Interface));
        _ = await Assert.That(results[0].ErrorMessage).IsNotNull().And.IsNotEmpty();
    }

    [Test]
    public async Task GivenTooShortNameThenValidationErrorsReturned()
    {
        // Arrange
        Interface subject = new Declaration
        {
            Name = "I",
        };

        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        _ = await Assert.That(valid).IsFalse();
        _ = await Assert.That(results).HasSingleItem();
        _ = await Assert.That(results[0].MemberNames).Contains(nameof(Interface));
        _ = await Assert.That(results[0].ErrorMessage).IsNotNull().And.IsNotEmpty();
    }

    [Test]
    public async Task GivenInvalidDeclarationThenValidationErrorsReturned()
    {
        // Arrange
        Interface subject = new Declaration
        {
            Arguments = [new Argument()],
        };

        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        _ = await Assert.That(valid).IsFalse();
        _ = await Assert.That(results).HasSingleItem();
        _ = await Assert.That(results[0].MemberNames).Contains(nameof(Interface));
        _ = await Assert.That(results[0].ErrorMessage).IsNotNull().And.IsNotEmpty();
    }
}