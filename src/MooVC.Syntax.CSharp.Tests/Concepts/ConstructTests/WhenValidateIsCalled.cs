namespace MooVC.Syntax.CSharp.Concepts.ConstructTests;

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
        var subject = new TestConstruct { IsUndefinedValue = true };
        var validationContext = new ValidationContext(subject);

        // Act
        var results = subject.Validate(validationContext);

        // Assert
        results.ShouldBeEmpty();
    }

    [Fact]
    public void GivenUnspecifiedNameThenReturnsValidationResults()
    {
        // Arrange
        var subject = new TestConstruct
        {
            IsUndefinedValue = false,
            Name = Declaration.Unspecified,
        };
        var validationContext = new ValidationContext(subject);

        // Act
        var results = subject.Validate(validationContext).ToArray();

        // Assert
        results.ShouldContain(result => result.MemberNames.Contains(nameof(Construct.Name)));
    }
}