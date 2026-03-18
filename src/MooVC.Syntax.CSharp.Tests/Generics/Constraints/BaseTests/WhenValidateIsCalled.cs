namespace MooVC.Syntax.CSharp.Generics.Constraints.BaseTests;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MooVC.Syntax.CSharp.Elements;

public sealed class WhenValidateIsCalled
{
    private const string BaseName = "Result";

    [Test]
    public async Task GivenUnspecifiedBaseThenNoValidationErrorsReturned()
    {
        // Arrange
        Base subject = Base.Unspecified;
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        _ = await Assert.That(valid).IsTrue();
        _ = await Assert.That(results).IsEmpty();
    }

    [Test]
    public async Task GivenInvalidBaseThenValidationErrorsReturned()
    {
        // Arrange
        var subject = new Base(new Symbol { Name = "Invalid Symbol Name" });
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        _ = await Assert.That(valid).IsFalse();
        _ = await Assert.That(results).HasSingleItem();
        _ = await Assert.That(results[0].MemberNames).Contains(nameof(Symbol.Moniker));
        _ = await Assert.That(results[0].ErrorMessage).IsNotNull().And.IsNotEmpty();
    }

    [Test]
    public async Task GivenValidBaseThenNoValidationErrorsReturned()
    {
        // Arrange
        Base subject = new Symbol { Name = BaseName };
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        _ = await Assert.That(valid).IsTrue();
        _ = await Assert.That(results).IsEmpty();
    }
}