namespace MooVC.Syntax.Validation.ValidationContextExtensionsTests;

using System.ComponentModel.DataAnnotations;

public sealed class WhenIncludeIsCalled
{
    private const string FirstMessage = "First";
    private const string SecondMessage = "Second";

    [Test]
    public async Task GivenExistingResultsThenValidationResultsAreAppended()
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
        _ = await Assert.That(actual.ValidationContext).IsSameReferenceAs(context);

        ValidationResult[] combined = [.. actual.Results];
        _ = await Assert.That(combined).IsEquivalentTo([initial, validatable.Results.Single()]);
    }

    [Test]
    public async Task GivenMultipleValidatablesThenAllValidationResultsAreReturned()
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
        _ = await Assert.That(actual.ValidationContext).IsSameReferenceAs(context);

        ValidationResult[] results = [.. actual.Results];
        _ = await Assert.That(results).IsEquivalentTo([first.Results.Single(), second.Results.Single()]);
    }

    [Test]
    public async Task GivenResultsAndMultipleValidatablesThenAllValidationResultsAreAppended()
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
        _ = await Assert.That(actual.ValidationContext).IsSameReferenceAs(context);

        ValidationResult[] combined = [.. actual.Results];
        _ = await Assert.That(combined).IsEquivalentTo([initial, first.Results.Single(), second.Results.Single()]);
    }

    [Test]
    public async Task GivenResultsAreNullThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        var validatable = new StubValidatable();
        var context = new ValidationContext(validatable);
        IEnumerable<ValidationResult>? results = default;

        // Act
        Action action = () => context.Include(nameof(validatable), results!, validatable);

        // Assert
        ArgumentNullException exception = await Assert.That(action).Throws<ArgumentNullException>().And.IsNotNull();
        _ = await Assert.That(exception.ParamName).IsEqualTo(nameof(results));
    }

    [Test]
    public async Task GivenValidatableIsNullThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        var validatable = new StubValidatable();
        var context = new ValidationContext(validatable);
        IValidatableObject? target = default;

        // Act
        Action action = () => context.Include(nameof(validatable), target!);

        // Assert
        ArgumentNullException exception = await Assert.That(action).Throws<ArgumentNullException>().And.IsNotNull();
        _ = await Assert.That(exception.ParamName).IsEqualTo(nameof(validatable));
    }

    [Test]
    public async Task GivenValidatablesAreNullThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        IValidatableObject[] validatables = [new StubValidatable()];
        var context = new ValidationContext(validatables);
        IEnumerable<IValidatableObject>? targets = default;

        // Act
        Action action = () => context.Include(nameof(validatables), targets!);

        // Assert
        ArgumentNullException exception = await Assert.That(action).Throws<ArgumentNullException>().And.IsNotNull();
        _ = await Assert.That(exception.ParamName).IsEqualTo(nameof(validatables));
    }

    [Test]
    public async Task GivenValidatableThenValidationResultsAreReturned()
    {
        // Arrange
        var validatable = new StubValidatable(new ValidationResult(FirstMessage));
        var context = new ValidationContext(validatable);

        // Act
        (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) actual = context.Include(
            nameof(validatable),
            validatable);

        // Assert
        _ = await Assert.That(actual.ValidationContext).IsSameReferenceAs(context);

        ValidationResult[] results = [.. actual.Results];
        _ = await Assert.That(results).IsEquivalentTo([validatable.Results.Single()]);
    }

    [Test]
    public async Task GivenValidationContextIsNullThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        ValidationContext? validationContext = default;
        var validatable = new StubValidatable();

        // Act
        Action action = () => validationContext!.Include(nameof(validatable), validatable);

        // Assert
        ArgumentNullException exception = await Assert.That(action).Throws<ArgumentNullException>().And.IsNotNull();
        _ = await Assert.That(exception.ParamName).IsEqualTo(nameof(validationContext));
    }

    private sealed class StubValidatable : IValidatableObject
    {
        public StubValidatable(params ValidationResult[] results)
        {
            Results = [.. results.DefaultIfEmpty(new ValidationResult(FirstMessage))];
        }

        public IReadOnlyCollection<ValidationResult> Results { get; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            return Results;
        }
    }
}