namespace MooVC.Syntax.CSharp.Concepts.DefinitionTests;

using System.ComponentModel.DataAnnotations;
using System.Linq;
using MooVC.Syntax.CSharp.Concepts;
using MooVC.Syntax.CSharp.Members;

public sealed class WhenValidateIsCalled
{
    [Fact]
    public void GivenEmptyDefinitionThenReturnsEmptyResults()
    {
        // Arrange
        var subject = Definition<Class>.Empty;
        var validationContext = new ValidationContext(subject);

        // Act
        var results = subject.Validate(validationContext);

        // Assert
        results.ShouldBeEmpty();
    }

    [Fact]
    public void GivenMissingConstructAndNamespaceThenReturnsValidationResults()
    {
        // Arrange
        var subject = new Definition<Class>
        {
            Construct = Class.Undefined,
            Namespace = Qualifier.Unqualified,
        };
        var validationContext = new ValidationContext(subject);

        // Act
        var results = subject.Validate(validationContext).ToArray();

        // Assert
        results.ShouldContain(result => result.MemberNames.Contains(nameof(Definition<Class>.Construct)));
        results.ShouldContain(result => result.MemberNames.Contains(nameof(Definition<Class>.Namespace)));
    }
}