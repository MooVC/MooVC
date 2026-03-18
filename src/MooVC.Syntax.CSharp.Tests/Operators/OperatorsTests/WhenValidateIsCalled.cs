namespace MooVC.Syntax.CSharp.Operators.OperatorsTests;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MooVC.Syntax.CSharp.Operators.BinaryTests;

public sealed class WhenValidateIsCalled
{
    [Test]
    public async Task GivenUndefinedOperatorsThenNoValidationErrorsReturned()
    {
        // Arrange
        Operators subject = Operators.Undefined;
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        _ = await Assert.That(valid).IsTrue();
        _ = await Assert.That(results).IsEmpty();
    }

    [Test]
    public async Task GivenInvalidBinaryThenValidationErrorsReturned()
    {
        // Arrange
        Operators subject = OperatorsSubjectData.Create(binaries: [new Binary()]);
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        _ = await Assert.That(valid).IsFalse();
        _ = await Assert.That(results).IsNotEmpty();
        _ = await Assert.That(results).Contains(result => result.MemberNames.Contains(nameof(Binary.Body)));
    }

    [Test]
    public async Task GivenValidOperatorsThenNoValidationErrorsReturned()
    {
        // Arrange
        Operators subject = OperatorsSubjectData.Create(binaries: [BinaryTestsData.Create()]);
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        _ = await Assert.That(valid).IsTrue();
        _ = await Assert.That(results).IsEmpty();
    }
}