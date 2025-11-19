namespace MooVC.Syntax.CSharp.ValidationResultExtensionsTests;

using System.ComponentModel.DataAnnotations;

public sealed class WhenAndIsCalled
{
    private const string FirstMessage = "First";
    private const string SecondMessage = "Second";

    [Fact]
    public void GivenValidatableThenItsResultsAreAppended()
    {
        // Arrange
        var initial = new ValidationResult(FirstMessage);
        var precedingValidatable = new StubValidatable(initial);
        var additionalValidatable = new StubValidatable(new ValidationResult(SecondMessage));
        var context = new ValidationContext(precedingValidatable);
        (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) preceding = context.Include(precedingValidatable);

        // Act
        (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) actual = preceding.And(additionalValidatable);

        // Assert
        actual.ValidationContext.ShouldBeSameAs(context);

        ValidationResult[] results = actual.Results.ToArray();
        results.ShouldBe(new[] { initial, additionalValidatable.Results.Single() });
    }

    [Fact]
    public void GivenValidatablesThenAllResultsAreAppended()
    {
        // Arrange
        var initial = new ValidationResult(FirstMessage);
        var precedingValidatable = new StubValidatable(initial);
        var firstAdditional = new StubValidatable(new ValidationResult(SecondMessage));
        var secondAdditional = new StubValidatable(new ValidationResult("Third"));
        var context = new ValidationContext(precedingValidatable);
        (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) preceding = context.Include(precedingValidatable);

        // Act
        (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) actual = preceding.And(new[] { firstAdditional, secondAdditional });

        // Assert
        actual.ValidationContext.ShouldBeSameAs(context);

        ValidationResult[] results = actual.Results.ToArray();
        results.ShouldBe(new[] { initial, firstAdditional.Results.Single(), secondAdditional.Results.Single() });
    }

    private sealed class StubValidatable : IValidatableObject
    {
        public StubValidatable(params ValidationResult[] results)
        {
            Results = results;
        }

        public IReadOnlyCollection<ValidationResult> Results { get; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            return Results;
        }
    }
}