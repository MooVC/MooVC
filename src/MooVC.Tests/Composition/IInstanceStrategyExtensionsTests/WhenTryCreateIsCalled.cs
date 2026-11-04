namespace MooVC.Composition.IInstanceStrategyExtensionsTests;

using Microsoft.Extensions.Configuration;

public sealed class WhenTryCreateIsCalled
{
    private const int ExpectedCalls = 1;
    private const int OutArgumentIndex = 2;
    private const int SelectedType = 13;

    [Test]
    public async Task GivenNullStrategiesThenAnArgumentNullExceptionIsThrown()
    {
        // Arrange
        IEnumerable<IInstanceStrategy<object, int>> strategies = null!;
        IConfigurationSection configuration = Substitute.For<IConfigurationSection>();

        // Act
        Func<bool> act = () => strategies.TryCreate(configuration, SelectedType, out _);

        // Assert
        ArgumentNullException exception = await Assert.That(act).Throws<ArgumentNullException>().And.IsNotNull();
        _ = await Assert.That(exception.ParamName).IsEqualTo(nameof(strategies));
    }

    [Test]
    public async Task GivenNullConfigurationThenAnArgumentNullExceptionIsThrown()
    {
        // Arrange
        IInstanceStrategy<object, int> strategy = Substitute.For<IInstanceStrategy<object, int>>();
        IEnumerable<IInstanceStrategy<object, int>> strategies = [strategy];
        IConfigurationSection configuration = null!;

        // Act
        Func<bool> act = () => strategies.TryCreate(configuration, SelectedType, out _);

        // Assert
        ArgumentNullException exception = await Assert.That(act).Throws<ArgumentNullException>().And.IsNotNull();
        _ = await Assert.That(exception.ParamName).IsEqualTo(nameof(configuration));
        _ = strategy.DidNotReceiveWithAnyArgs().TryCreate(default!, default, out _);
    }

    [Test]
    public async Task GivenNoStrategiesThenFalseAndNullAreReturned()
    {
        // Arrange
        IEnumerable<IInstanceStrategy<object, int>> strategies = [];
        IConfigurationSection configuration = Substitute.For<IConfigurationSection>();

        // Act
        bool actual = strategies.TryCreate(configuration, SelectedType, out object? instance);

        // Assert
        _ = await Assert.That(actual).IsFalse();
        _ = await Assert.That(instance).IsNull();
    }

    [Test]
    public async Task GivenOnlyRejectingStrategiesThenFalseAndNullAreReturned()
    {
        // Arrange
        IConfigurationSection configuration = Substitute.For<IConfigurationSection>();
        IInstanceStrategy<object, int> first = Substitute.For<IInstanceStrategy<object, int>>();
        IInstanceStrategy<object, int> second = Substitute.For<IInstanceStrategy<object, int>>();
        object rejected = new object();
        IEnumerable<IInstanceStrategy<object, int>> strategies = [first, second];

        _ = first.TryCreate(configuration, SelectedType, out Arg.Any<object?>()).Returns(call =>
        {
            call[OutArgumentIndex] = rejected;
            return false;
        });

        _ = second.TryCreate(configuration, SelectedType, out Arg.Any<object?>()).Returns(call =>
        {
            call[OutArgumentIndex] = rejected;
            return false;
        });

        // Act
        bool actual = strategies.TryCreate(configuration, SelectedType, out object? instance);

        // Assert
        _ = await Assert.That(actual).IsFalse();
        _ = await Assert.That(instance).IsNull();

        Received.InOrder(() =>
        {
            _ = first.TryCreate(configuration, SelectedType, out Arg.Any<object?>());
            _ = second.TryCreate(configuration, SelectedType, out Arg.Any<object?>());
        });
    }

    [Test]
    [Arguments(0)]
    [Arguments(SelectedType)]
    public async Task GivenASuccessfulFirstStrategyThenItsResultIsReturnedWithoutTryingLaterStrategies(int type)
    {
        // Arrange
        IConfigurationSection configuration = Substitute.For<IConfigurationSection>();
        IInstanceStrategy<object, int> first = Substitute.For<IInstanceStrategy<object, int>>();
        IInstanceStrategy<object, int> second = Substitute.For<IInstanceStrategy<object, int>>();
        object expected = new object();
        IEnumerable<IInstanceStrategy<object, int>> strategies = [first, second];

        _ = first.TryCreate(configuration, type, out Arg.Any<object?>()).Returns(call =>
        {
            call[OutArgumentIndex] = expected;
            return true;
        });

        // Act
        bool actual = strategies.TryCreate(configuration, type, out object? instance);

        // Assert
        _ = await Assert.That(actual).IsTrue();
        _ = await Assert.That(instance).IsSameReferenceAs(expected);
        _ = first.Received(ExpectedCalls).TryCreate(configuration, type, out Arg.Any<object?>());
        _ = second.DidNotReceiveWithAnyArgs().TryCreate(default!, default, out _);
    }

    [Test]
    public async Task GivenARejectingStrategyBeforeASuccessfulStrategyThenStrategiesAreTriedInOrder()
    {
        // Arrange
        IConfigurationSection configuration = Substitute.For<IConfigurationSection>();
        IInstanceStrategy<object, int> first = Substitute.For<IInstanceStrategy<object, int>>();
        IInstanceStrategy<object, int> second = Substitute.For<IInstanceStrategy<object, int>>();
        IInstanceStrategy<object, int> third = Substitute.For<IInstanceStrategy<object, int>>();
        object expected = new object();
        IEnumerable<IInstanceStrategy<object, int>> strategies = [first, second, third];

        _ = second.TryCreate(configuration, SelectedType, out Arg.Any<object?>()).Returns(call =>
        {
            call[OutArgumentIndex] = expected;
            return true;
        });

        // Act
        bool actual = strategies.TryCreate(configuration, SelectedType, out object? instance);

        // Assert
        _ = await Assert.That(actual).IsTrue();
        _ = await Assert.That(instance).IsSameReferenceAs(expected);

        Received.InOrder(() =>
        {
            _ = first.TryCreate(configuration, SelectedType, out Arg.Any<object?>());
            _ = second.TryCreate(configuration, SelectedType, out Arg.Any<object?>());
        });

        _ = third.DidNotReceiveWithAnyArgs().TryCreate(default!, default, out _);
    }

    [Test]
    public async Task GivenAStrategyThatThrowsThenTheExceptionIsPropagatedWithoutTryingLaterStrategies()
    {
        // Arrange
        const string Message = "Strategy failed.";
        IConfigurationSection configuration = Substitute.For<IConfigurationSection>();
        IInstanceStrategy<object, int> first = Substitute.For<IInstanceStrategy<object, int>>();
        IInstanceStrategy<object, int> second = Substitute.For<IInstanceStrategy<object, int>>();
        var expected = new InvalidOperationException(Message);
        IEnumerable<IInstanceStrategy<object, int>> strategies = [first, second];

        _ = first.TryCreate(configuration, SelectedType, out Arg.Any<object?>()).Returns(_ => throw expected);

        // Act
        Func<bool> act = () => strategies.TryCreate(configuration, SelectedType, out _);

        // Assert
        InvalidOperationException actual = await Assert.That(act).Throws<InvalidOperationException>().And.IsNotNull();
        _ = await Assert.That(actual).IsSameReferenceAs(expected);
        _ = second.DidNotReceiveWithAnyArgs().TryCreate(default!, default, out _);
    }
}