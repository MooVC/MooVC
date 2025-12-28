namespace MooVC.Syntax.CSharp.Concepts.DefinitionTests;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using MooVC.Syntax.CSharp.Concepts;
using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.CSharp.Members;

public sealed class WhenValidateIsCalled
{
    [Fact]
    public void GivenEmptyDefinitionThenReturnsEmptyResults()
    {
        // Arrange
        Definition<Class> subject = Definition<Class>.Empty;
        var validationContext = new ValidationContext(subject);

        // Act
        IEnumerable<ValidationResult> results = subject.Validate(validationContext);

        // Assert
        results.ShouldBeEmpty();
    }

    [Fact]
    public void GivenMissingConstructAndNamespaceThenReturnsValidationResults()
    {
        // Arrange
        var subject = new Definition<Class>
        {
            Namespace = Qualifier.Unqualified,
            Type = Class.Undefined,
        };
        var validationContext = new ValidationContext(subject);

        // Act
        ValidationResult[] results = subject.Validate(validationContext).ToArray();

        // Assert
        results.ShouldContain(result => result.MemberNames.Contains(nameof(Definition<Class>.Namespace)));
        results.ShouldContain(result => result.MemberNames.Contains(nameof(Definition<Class>.Type)));
    }

    private sealed class Class
        : Type
    {
        public static readonly Class Undefined = new Class();

        public override bool IsUndefined => ReferenceEquals(this, Undefined);

        protected override Snippet PerformToSnippet(Snippet.Options options)
        {
            return "Class";
        }
    }
}