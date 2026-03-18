namespace MooVC.Syntax.CSharp.Elements.ResultTests;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public sealed class WhenValidateIsCalled
{
    [Test]
    public async Task GivenUndefinedTypeWithModifierThenValidationFails()
    {
        // Arrange
        var subject = new Result
        {
            Modifier = Result.Kind.Ref,
        };

        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        _ = await Assert.That(valid).IsFalse();
        _ = await Assert.That(results).Contains(result => result.MemberNames.Contains(nameof(Result.Type)));
    }

    [Test]
    public async Task GivenDefaultResultThenValidationSucceeds()
    {
        // Arrange
        var subject = new Result();
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        _ = await Assert.That(valid).IsTrue();
        _ = await Assert.That(results).IsEmpty();
    }
}