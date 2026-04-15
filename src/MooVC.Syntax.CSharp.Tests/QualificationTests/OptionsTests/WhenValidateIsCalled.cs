namespace MooVC.Syntax.CSharp.QualificationTests.OptionsTests;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public sealed class WhenValidateIsCalled
{
    [Test]
    public async Task GivenFormatIsNullThenValidationErrorReturned()
    {
        // Arrange
        Qualification.Options.Formats? format = null;
        Qualification.Options subject = Qualification.Options.Default.WithFormat(format!);

        // Act
        List<ValidationResult> results = Validate(subject, out bool valid);

        // Assert
        _ = await Assert.That(valid).IsFalse();
        _ = await Assert.That(results).HasSingleItem();
        _ = await Assert.That(results[0].MemberNames).Contains(nameof(Qualification.Options.Format));
    }

    private static List<ValidationResult> Validate(object subject, out bool valid)
    {
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        return results;
    }
}