namespace MooVC.Syntax.CSharp.Concepts.ReferenceTests;

using System.ComponentModel.DataAnnotations;
using System.Linq;
using MooVC.Syntax.CSharp.Concepts;
using MooVC.Syntax.CSharp.Members;

public sealed class WhenValidateIsCalled
{
    private const string TypeName = "Widget";

    [Fact]
    public void GivenInvalidExtensibilityThenReturnsValidationResults()
    {
        // Arrange
        var subject = new TestReference
        {
            IsUndefinedValue = false,
            Extensibility = Extensibility.Static,
            Name = new Declaration { Name = new Identifier(TypeName) },
        };
        var validationContext = new ValidationContext(subject);

        // Act
        var results = subject.Validate(validationContext).ToArray();

        // Assert
        results.ShouldContain(result => result.MemberNames.Contains(nameof(Reference.Extensibility)));
    }
}