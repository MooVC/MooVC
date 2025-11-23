namespace MooVC.Syntax.CSharp.ValidationContextExtensionsTests;

using System.ComponentModel.DataAnnotations;

public sealed class WhenIncludeIsCalled
{
    private const string FirstMessage = "First";
    private const string SecondMessage = "Second";

    [Fact]
    public void GivenValidationContextIsNullThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        ValidationContext? validationContext = default;
        var validatable = new StubValidatable();

        // Act
        Action action = () => validationContext!.Include(nameof(validatable), validatable);

        // Assert
        ArgumentNullException exception = Should.Throw<ArgumentNullException>(action);
        exception.ParamName.ShouldBe(nameof(validationContext));
    }

    [Fact]
    public void GivenResultsAreNullThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        var validatable = new StubValidatable();
        var context = new ValidationContext(validatable);
        IEnumerable<ValidationResult>? results = default;

        // Act
        Action action = () => context.Include(nameof(validatable), results!, validatable);

        // Assert
        ArgumentNullException exception = Should.Throw<ArgumentNullException>(action);
        exception.ParamName.ShouldBe(nameof(results));
    }

    [Fact]
    public void GivenValidatableIsNullThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        var validatable = new StubValidatable();
        var context = new ValidationContext(validatable);
        IValidatableObject? target = default;

        // Act
        Action action = () => context.Include(nameof(validatable), target!);

        // Assert
        ArgumentNullException exception = Should.Throw<ArgumentNullException>(action);
        exception.ParamName.ShouldBe(nameof(validatable));
    }

    [Fact]
    public void GivenValidatablesAreNullThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        IValidatableObject[] validatables = [new StubValidatable()];
        var context = new ValidationContext(validatables);
        IEnumerable<IValidatableObject>? targets = default;

        // Act
        Action action = () => context.Include(nameof(validatables), targets!);

        // Assert
        ArgumentNullException exception = Should.Throw<ArgumentNullException>(action);
        exception.ParamName.ShouldBe(nameof(validatables));
    }

    [Fact]
    public void GivenValidatableThenValidationResultsAreReturned()
    {
        // Arrange
        var validatable = new StubValidatable(new ValidationResult(FirstMessage));
        var context = new ValidationContext(validatable);

        // Act
        (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) actual = context.Include(
            nameof(validatable),
            validatable);

        // Assert
        actual.ValidationContext.ShouldBeSameAs(context);

        ValidationResult[] results = actual.Results.ToArray();
        results.ShouldBe([validatable.Results.Single()]);
    }

    [Fact]
    public void GivenExistingResultsThenValidationResultsAreAppended()
    {
        // Arrange
        var initial = new ValidationResult(FirstMessage);
        var validatable = new StubValidatable(new ValidationResult(SecondMessage));
        var context = new ValidationContext(validatable);
        IEnumerable<ValidationResult> results = [initial];

        // Act
        (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) actual = context.Include(
            nameof(validatable),
            results,
            validatable);

        // Assert
        actual.ValidationContext.ShouldBeSameAs(context);

        ValidationResult[] combined = actual.Results.ToArray();
        combined.ShouldBe([initial, validatable.Results.Single()]);
    }

    [Fact]
    public void GivenMultipleValidatablesThenAllValidationResultsAreReturned()
    {
        // Arrange
        var first = new StubValidatable(new ValidationResult(FirstMessage));
        var second = new StubValidatable(new ValidationResult(SecondMessage));
        var context = new ValidationContext(first);

        // Act
        (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) actual = context.Include(
            nameof(first),
            [first, second]);

        // Assert
        actual.ValidationContext.ShouldBeSameAs(context);

        ValidationResult[] results = actual.Results.ToArray();
        results.ShouldBe([first.Results.Single(), second.Results.Single()]);
    }

    [Fact]
    public void GivenResultsAndMultipleValidatablesThenAllValidationResultsAreAppended()
    {
        // Arrange
        var initial = new ValidationResult(FirstMessage);
        var first = new StubValidatable(new ValidationResult(SecondMessage));
        var second = new StubValidatable(new ValidationResult("Third"));
        var context = new ValidationContext(first);
        IEnumerable<ValidationResult> results = [initial];

        // Act
        (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) actual = context.Include(
            nameof(first),
            results,
            [first, second]);

        // Assert
        actual.ValidationContext.ShouldBeSameAs(context);

        ValidationResult[] combined = actual.Results.ToArray();
        combined.ShouldBe([initial, first.Results.Single(), second.Results.Single()]);
    }

    private sealed class StubValidatable : IValidatableObject
    {
        public StubValidatable(params ValidationResult[] results)
        {
            Results = results.DefaultIfEmpty(new ValidationResult(FirstMessage)).ToArray();
        }

        public IReadOnlyCollection<ValidationResult> Results { get; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            return Results;
        }
    }
}