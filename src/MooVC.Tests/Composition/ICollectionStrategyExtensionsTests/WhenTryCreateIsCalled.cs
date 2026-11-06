namespace MooVC.Composition.ICollectionStrategyExtensionsTests;

public sealed class WhenTryCreateIsCalled
{
    private const int ExpectedCalls = 1;
    private const int OutArgumentIndex = 2;
    private const int SelectedType = 13;

    [Test]
    public async Task GivenNullStrategiesThenAnArgumentNullExceptionIsThrown()
    {
        // Arrange
        IEnumerable<ICollectionStrategy<object, object, int>> strategies = null!;
        object options = new object();

        // Act
        Func<bool> act = () => strategies.TryCreate(options, SelectedType, out _);

        // Assert
        ArgumentNullException exception = await Assert.That(act).Throws<ArgumentNullException>().And.IsNotNull();
        _ = await Assert.That(exception.ParamName).IsEqualTo(nameof(strategies));
    }

    [Test]
    public async Task GivenNullOptionsThenAnArgumentNullExceptionIsThrown()
    {
        // Arrange
        ICollectionStrategy<object, object, int> strategy = Substitute.For<ICollectionStrategy<object, object, int>>();
        IEnumerable<ICollectionStrategy<object, object, int>> strategies = [strategy];
        object options = null!;

        // Act
        Func<bool> act = () => strategies.TryCreate(options, SelectedType, out _);

        // Assert
        ArgumentNullException exception = await Assert.That(act).Throws<ArgumentNullException>().And.IsNotNull();
        _ = await Assert.That(exception.ParamName).IsEqualTo(nameof(options));
        _ = strategy.DidNotReceiveWithAnyArgs().TryCreate(default!, default, out _);
    }

    [Test]
    public async Task GivenNoStrategiesThenFalseAndNullAreReturned()
    {
        // Arrange
        IEnumerable<ICollectionStrategy<object, object, int>> strategies = [];
        object options = new object();

        // Act
        bool actual = strategies.TryCreate(options, SelectedType, out IEnumerable<object>? instance);

        // Assert
        _ = await Assert.That(actual).IsFalse();
        _ = await Assert.That(instance).IsNull();
    }

    [Test]
    public async Task GivenOnlyRejectingStrategiesThenFalseAndNullAreReturned()
    {
        // Arrange
        object options = new object();
        ICollectionStrategy<object, object, int> first = Substitute.For<ICollectionStrategy<object, object, int>>();
        ICollectionStrategy<object, object, int> second = Substitute.For<ICollectionStrategy<object, object, int>>();
        IEnumerable<object> rejected = [new object(), new object()];
        IEnumerable<ICollectionStrategy<object, object, int>> strategies = [first, second];

        _ = first.TryCreate(options, SelectedType, out Arg.Any<IEnumerable<object>?>()).Returns(call =>
        {
            call[OutArgumentIndex] = rejected;
            return false;
        });

        _ = second.TryCreate(options, SelectedType, out Arg.Any<IEnumerable<object>?>()).Returns(call =>
        {
            call[OutArgumentIndex] = rejected;
            return false;
        });

        // Act
        bool actual = strategies.TryCreate(options, SelectedType, out IEnumerable<object>? instance);

        // Assert
        _ = await Assert.That(actual).IsFalse();
        _ = await Assert.That(instance).IsNull();

        Received.InOrder(() =>
        {
            _ = first.TryCreate(options, SelectedType, out Arg.Any<IEnumerable<object>?>());
            _ = second.TryCreate(options, SelectedType, out Arg.Any<IEnumerable<object>?>());
        });
    }

    [Test]
    [Arguments(0)]
    [Arguments(SelectedType)]
    public async Task GivenASuccessfulFirstStrategyThenItsResultIsReturnedWithoutTryingLaterStrategies(int type)
    {
        // Arrange
        object options = new object();
        ICollectionStrategy<object, object, int> first = Substitute.For<ICollectionStrategy<object, object, int>>();
        ICollectionStrategy<object, object, int> second = Substitute.For<ICollectionStrategy<object, object, int>>();
        IEnumerable<object> expected = [new object(), new object()];
        IEnumerable<ICollectionStrategy<object, object, int>> strategies = [first, second];

        _ = first.TryCreate(options, type, out Arg.Any<IEnumerable<object>?>()).Returns(call =>
        {
            call[OutArgumentIndex] = expected;
            return true;
        });

        // Act
        bool actual = strategies.TryCreate(options, type, out IEnumerable<object>? instance);

        // Assert
        _ = await Assert.That(actual).IsTrue();
        _ = await Assert.That(instance).IsSameReferenceAs(expected);
        _ = first.Received(ExpectedCalls).TryCreate(options, type, out Arg.Any<IEnumerable<object>?>());
        _ = second.DidNotReceiveWithAnyArgs().TryCreate(default!, default, out _);
    }

    [Test]
    public async Task GivenARejectingStrategyBeforeASuccessfulStrategyThenStrategiesAreTriedInOrder()
    {
        // Arrange
        object options = new object();
        ICollectionStrategy<object, object, int> first = Substitute.For<ICollectionStrategy<object, object, int>>();
        ICollectionStrategy<object, object, int> second = Substitute.For<ICollectionStrategy<object, object, int>>();
        ICollectionStrategy<object, object, int> third = Substitute.For<ICollectionStrategy<object, object, int>>();
        IEnumerable<object> expected = [new object(), new object()];
        IEnumerable<ICollectionStrategy<object, object, int>> strategies = [first, second, third];

        _ = second.TryCreate(options, SelectedType, out Arg.Any<IEnumerable<object>?>()).Returns(call =>
        {
            call[OutArgumentIndex] = expected;
            return true;
        });

        // Act
        bool actual = strategies.TryCreate(options, SelectedType, out IEnumerable<object>? instance);

        // Assert
        _ = await Assert.That(actual).IsTrue();
        _ = await Assert.That(instance).IsSameReferenceAs(expected);

        Received.InOrder(() =>
        {
            _ = first.TryCreate(options, SelectedType, out Arg.Any<IEnumerable<object>?>());
            _ = second.TryCreate(options, SelectedType, out Arg.Any<IEnumerable<object>?>());
        });

        _ = third.DidNotReceiveWithAnyArgs().TryCreate(default!, default, out _);
    }

    [Test]
    public async Task GivenAStrategyThatThrowsThenTheExceptionIsPropagatedWithoutTryingLaterStrategies()
    {
        // Arrange
        const string Message = "Strategy failed.";
        object options = new object();
        ICollectionStrategy<object, object, int> first = Substitute.For<ICollectionStrategy<object, object, int>>();
        ICollectionStrategy<object, object, int> second = Substitute.For<ICollectionStrategy<object, object, int>>();
        var expected = new InvalidOperationException(Message);
        IEnumerable<ICollectionStrategy<object, object, int>> strategies = [first, second];

        _ = first.TryCreate(options, SelectedType, out Arg.Any<IEnumerable<object>?>()).Returns(_ => throw expected);

        // Act
        Func<bool> act = () => strategies.TryCreate(options, SelectedType, out _);

        // Assert
        InvalidOperationException actual = await Assert.That(act).Throws<InvalidOperationException>().And.IsNotNull();
        _ = await Assert.That(actual).IsSameReferenceAs(expected);
        _ = second.DidNotReceiveWithAnyArgs().TryCreate(default!, default, out _);
    }

    [Test]
    public async Task GivenASuccessfulStrategyWithAnEmptyCollectionThenTrueAndTheEmptyCollectionAreReturned()
    {
        // Arrange
        object options = new();
        ICollectionStrategy<object, object, int> strategy = Substitute.For<ICollectionStrategy<object, object, int>>();
        IEnumerable<object> expected = [];
        IEnumerable<ICollectionStrategy<object, object, int>> strategies = [strategy];

        _ = strategy.TryCreate(options, SelectedType, out Arg.Any<IEnumerable<object>?>()).Returns(call =>
        {
            call[OutArgumentIndex] = expected;
            return true;
        });

        // Act
        bool actual = strategies.TryCreate(options, SelectedType, out IEnumerable<object>? instance);

        // Assert
        _ = await Assert.That(actual).IsTrue();
        _ = await Assert.That(instance).IsSameReferenceAs(expected);
    }
}