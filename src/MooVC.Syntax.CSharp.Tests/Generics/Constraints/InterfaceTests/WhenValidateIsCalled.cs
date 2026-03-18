namespace MooVC.Syntax.CSharp.Generics.Constraints.InterfaceTests;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MooVC.Syntax.CSharp.Members;
using Parameter = MooVC.Syntax.CSharp.Generics.Parameter;

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
        Interface subject = new Members.Declaration
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
        Interface subject = new Members.Declaration
        {
            Parameters = [new Parameter()],
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