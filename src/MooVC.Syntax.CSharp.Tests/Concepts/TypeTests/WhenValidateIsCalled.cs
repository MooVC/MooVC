namespace MooVC.Syntax.CSharp.Concepts.TypeTests;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using MooVC.Syntax.CSharp.Concepts;
using MooVC.Syntax.CSharp.Members;

public sealed class WhenValidateIsCalled
{
    [Fact]
    public void GivenUndefinedThenReturnsEmptyResults()
    {
        // Arrange
        var subject = new TestType { IsUndefinedValue = true };
        var validationContext = new ValidationContext(subject);

        // Act
        IEnumerable<ValidationResult> results = subject.Validate(validationContext);

        // Assert
        results.ShouldBeEmpty();
    }

    [Fact]
    public void GivenUnspecifiedNameThenReturnsValidationResults()
    {
        // Arrange
        var subject = new TestType
        {
            IsUndefinedValue = false,
            Name = Declaration.Unspecified,
        };

        var validationContext = new ValidationContext(subject);

        // Act
        ValidationResult[] results = subject.Validate(validationContext).ToArray();

        // Assert
        results.ShouldContain(result => result.MemberNames.Contains(nameof(Type.Name)));
    }
}