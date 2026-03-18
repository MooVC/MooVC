namespace MooVC.Syntax.CSharp.Concepts.TypeTests;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using MooVC.Syntax.CSharp.Concepts;
using MooVC.Syntax.CSharp.Members;

public sealed class WhenValidateIsCalled
{
    [Test]
    public async Task GivenUndefinedThenReturnsEmptyResults()
    {
        // Arrange
        var subject = new TestType { IsUndefinedValue = true };
        var validationContext = new ValidationContext(subject);

        // Act
        IEnumerable<ValidationResult> results = subject.Validate(validationContext);

        // Assert
        _ = await Assert.That(results).IsEmpty();
    }

    [Test]
    public async Task GivenUnspecifiedNameThenReturnsValidationResults()
    {
        // Arrange
        var subject = new TestType
        {
            IsUndefinedValue = false,
            Declaration = Declaration.Unspecified,
        };

        var validationContext = new ValidationContext(subject);

        // Act
        ValidationResult[] results = [.. subject.Validate(validationContext)];

        // Assert
        _ = await Assert.That(results).Contains(result => result.MemberNames.Contains(nameof(Type.Declaration)));
    }
}