namespace MooVC.Composition.InstanceFactoryTests;

using Microsoft.Extensions.Configuration;
using MooVC.Configuration;
using SerializationType = MooVC.Serialization.Configuration.Type;

public sealed class WhenCreateIsCalled
{
    private const string NameKey = "Name";
    private const int ExpectedCalls = 1;
    private const int OutArgumentIndex = 2;
    private const string OtherName = "Other section";
    private const string SelectedName = "Selected section";
    private const int SelectedType = 13;
    private const string SelectedTypeText = "13";

    [Test]
    public async Task GivenMatchingConfigurationThenTheSelectedSectionAndTypeArePassedToTheStrategy()
    {
        // Arrange
        IConfiguration configuration = CreateConfiguration();
        IInstanceStrategy<object, int> strategy = Substitute.For<IInstanceStrategy<object, int>>();
        object expected = new object();
        var factory = new InstanceFactory<object, int>([strategy]);

        _ = strategy.TryCreate(Arg.Is<IConfigurationSection>(section => section.Path == SelectedTypeText && section[NameKey] == SelectedName), SelectedType, out Arg.Any<object?>()).Returns(call =>
        {
            call[OutArgumentIndex] = expected;
            return true;
        });

        // Act
        object actual = factory.Create(configuration);

        // Assert
        _ = await Assert.That(actual).IsSameReferenceAs(expected);
        _ = strategy.Received(ExpectedCalls).TryCreate(Arg.Is<IConfigurationSection>(section => section.Path == SelectedTypeText && section[NameKey] == SelectedName), SelectedType, out Arg.Any<object?>());
    }

    [Test]
    public async Task GivenARejectingStrategyBeforeASuccessfulStrategyThenTheSuccessfulResultIsReturned()
    {
        // Arrange
        IConfiguration configuration = CreateConfiguration();
        IInstanceStrategy<object, int> first = Substitute.For<IInstanceStrategy<object, int>>();
        IInstanceStrategy<object, int> second = Substitute.For<IInstanceStrategy<object, int>>();
        IInstanceStrategy<object, int> third = Substitute.For<IInstanceStrategy<object, int>>();
        object expected = new object();
        var factory = new InstanceFactory<object, int>([first, second, third]);

        _ = second.TryCreate(Arg.Is<IConfigurationSection>(section => section.Path == SelectedTypeText && section[NameKey] == SelectedName), SelectedType, out Arg.Any<object?>()).Returns(call =>
        {
            call[OutArgumentIndex] = expected;
            return true;
        });

        // Act
        object actual = factory.Create(configuration);

        // Assert
        _ = await Assert.That(actual).IsSameReferenceAs(expected);

        Received.InOrder(() =>
        {
            _ = first.TryCreate(Arg.Is<IConfigurationSection>(section => section.Path == SelectedTypeText && section[NameKey] == SelectedName), SelectedType, out Arg.Any<object?>());
            _ = second.TryCreate(Arg.Is<IConfigurationSection>(section => section.Path == SelectedTypeText && section[NameKey] == SelectedName), SelectedType, out Arg.Any<object?>());
        });

        _ = third.DidNotReceiveWithAnyArgs().TryCreate(default!, default, out _);
    }

    [Test]
    public async Task GivenNoStrategiesThenAnInvalidOperationExceptionIsThrown()
    {
        // Arrange
        IConfiguration configuration = CreateConfiguration();
        var factory = new InstanceFactory<object, int>([]);

        // Act
        Func<object> act = () => factory.Create(configuration);

        // Assert
        InvalidOperationException exception = await Assert.That(act).Throws<InvalidOperationException>().And.IsNotNull();
        _ = await Assert.That(exception.Message).Contains(typeof(object).ToString());
    }

    [Test]
    public async Task GivenOnlyRejectingStrategiesThenAnInvalidOperationExceptionIsThrown()
    {
        // Arrange
        IConfiguration configuration = CreateConfiguration();
        IInstanceStrategy<object, int> first = Substitute.For<IInstanceStrategy<object, int>>();
        IInstanceStrategy<object, int> second = Substitute.For<IInstanceStrategy<object, int>>();
        var factory = new InstanceFactory<object, int>([first, second]);

        // Act
        Func<object> act = () => factory.Create(configuration);

        // Assert
        InvalidOperationException exception = await Assert.That(act).Throws<InvalidOperationException>().And.IsNotNull();
        _ = await Assert.That(exception.Message).Contains(typeof(object).ToString());
        _ = first.Received(ExpectedCalls).TryCreate(Arg.Is<IConfigurationSection>(section => section.Path == SelectedTypeText && section[NameKey] == SelectedName), SelectedType, out Arg.Any<object?>());
        _ = second.Received(ExpectedCalls).TryCreate(Arg.Is<IConfigurationSection>(section => section.Path == SelectedTypeText && section[NameKey] == SelectedName), SelectedType, out Arg.Any<object?>());
    }

    [Test]
    public async Task GivenAStrategyThatThrowsThenTheExceptionIsPropagated()
    {
        // Arrange
        const string Message = "Strategy failed.";
        IConfiguration configuration = CreateConfiguration();
        IInstanceStrategy<object, int> strategy = Substitute.For<IInstanceStrategy<object, int>>();
        var expected = new InvalidOperationException(Message);
        var factory = new InstanceFactory<object, int>([strategy]);

        _ = strategy.TryCreate(Arg.Is<IConfigurationSection>(section => section.Path == SelectedTypeText && section[NameKey] == SelectedName), SelectedType, out Arg.Any<object?>()).Returns(_ => throw expected);

        // Act
        Func<object> act = () => factory.Create(configuration);

        // Assert
        InvalidOperationException actual = await Assert.That(act).Throws<InvalidOperationException>().And.IsNotNull();
        _ = await Assert.That(actual).IsSameReferenceAs(expected);
    }

    [Test]
    public async Task GivenNullConfigurationThenAnArgumentNullExceptionIsThrown()
    {
        // Arrange
        IConfiguration configuration = null!;
        var factory = new InstanceFactory<object, int>([]);

        // Act
        Func<object> act = () => factory.Create(configuration);

        // Assert
        ArgumentNullException exception = await Assert.That(act).Throws<ArgumentNullException>().And.IsNotNull();
        _ = await Assert.That(exception.ParamName).IsEqualTo(nameof(configuration));
    }

    [Test]
    public async Task GivenNoTypeSelectorThenTheDefaultTypeSectionIsUsed()
    {
        // Arrange
        const int DefaultType = 0;
        const string DefaultTypeText = "0";
        IConfiguration configuration = new ConfigurationBuilder().AddInMemoryCollection(new Dictionary<string, string?>
        {
            [$"{DefaultTypeText}:{NameKey}"] = SelectedName,
        }).Build();
        IInstanceStrategy<object, int> strategy = Substitute.For<IInstanceStrategy<object, int>>();
        object expected = new object();
        var factory = new InstanceFactory<object, int>([strategy]);

        _ = strategy.TryCreate(Arg.Is<IConfigurationSection>(section => section.Path == DefaultTypeText && section[NameKey] == SelectedName), DefaultType, out Arg.Any<object?>()).Returns(call =>
        {
            call[OutArgumentIndex] = expected;
            return true;
        });

        // Act
        object actual = factory.Create(configuration);

        // Assert
        _ = await Assert.That(actual).IsSameReferenceAs(expected);
    }

    [Test]
    public async Task GivenNoSelectedSectionThenAnEmptySectionIsPassedToTheStrategy()
    {
        // Arrange
        IConfiguration configuration = new ConfigurationBuilder().AddInMemoryCollection(new Dictionary<string, string?>
        {
            [nameof(Options<int>.Type)] = SelectedTypeText,
        }).Build();
        IInstanceStrategy<object, int> strategy = Substitute.For<IInstanceStrategy<object, int>>();
        var expected = new object();
        var factory = new InstanceFactory<object, int>([strategy]);

        _ = strategy.TryCreate(
            Arg.Is<IConfigurationSection>(section => section.Path == SelectedTypeText && !section.Exists()),
            SelectedType,
            out Arg.Any<object?>()).Returns(call =>
        {
            call[OutArgumentIndex] = expected;
            return true;
        });

        // Act
        object actual = factory.Create(configuration);

        // Assert
        _ = await Assert.That(actual).IsSameReferenceAs(expected);
    }

    [Test]
    public async Task GivenAMalformedNumericSelectorThenBindingFailsBeforeAnyStrategyIsCalled()
    {
        // Arrange
        const string InvalidType = "Invalid";
        IConfiguration configuration = new ConfigurationBuilder().AddInMemoryCollection(new Dictionary<string, string?>
        {
            [nameof(Options<int>.Type)] = InvalidType,
        }).Build();
        IInstanceStrategy<object, int> strategy = Substitute.For<IInstanceStrategy<object, int>>();
        var factory = new InstanceFactory<object, int>([strategy]);

        // Act
        Func<object> act = () => factory.Create(configuration);

        // Assert
        InvalidOperationException exception = await Assert.That(act).Throws<InvalidOperationException>().And.IsNotNull();
        _ = await Assert.That(exception.Message).Contains(nameof(Options<int>.Type));
        _ = strategy.DidNotReceiveWithAnyArgs().TryCreate(default!, default, out _);
    }

    [Test]
    public async Task GivenANestedConfigurationSectionThenTheSelectorAndSelectedSectionAreResolvedRelativeToIt()
    {
        // Arrange
        const string ParentSection = "Application:Serializer";
        const string InvalidRootType = "Invalid";
        const string SelectedPath = ParentSection + ":" + SelectedTypeText;
        IConfigurationSection configuration = new ConfigurationBuilder().AddInMemoryCollection(new Dictionary<string, string?>
        {
            [nameof(Options<int>.Type)] = InvalidRootType,
            [$"{SelectedTypeText}:{NameKey}"] = OtherName,
            [$"{ParentSection}:{nameof(Options<int>.Type)}"] = SelectedTypeText,
            [$"{SelectedPath}:{NameKey}"] = SelectedName,
        }).Build().GetSection(ParentSection);
        IInstanceStrategy<object, int> strategy = Substitute.For<IInstanceStrategy<object, int>>();
        var expected = new object();
        var factory = new InstanceFactory<object, int>([strategy]);

        _ = strategy.TryCreate(
            Arg.Is<IConfigurationSection>(section => section.Path == SelectedPath && section[NameKey] == SelectedName),
            SelectedType,
            out Arg.Any<object?>()).Returns(call =>
        {
            call[OutArgumentIndex] = expected;
            return true;
        });

        // Act
        object actual = factory.Create(configuration);

        // Assert
        _ = await Assert.That(actual).IsSameReferenceAs(expected);
        _ = strategy.Received(ExpectedCalls).TryCreate(
            Arg.Is<IConfigurationSection>(section => section.Path == SelectedPath && section[NameKey] == SelectedName),
            SelectedType,
            out Arg.Any<object?>());
    }

    [Test]
    public async Task GivenACustomSerializationIdentifierThenTheMatchingStrategyReceivesItsTypeAndSection()
    {
        // Arrange
        const string CustomType = "Custom.Serialization";
        SerializationType selectedType = CustomType;
        IConfiguration configuration = new ConfigurationBuilder().AddInMemoryCollection(new Dictionary<string, string?>
        {
            [nameof(Options<SerializationType>.Type)] = CustomType,
            [$"{CustomType}:{NameKey}"] = SelectedName,
            [$"Other:{NameKey}"] = OtherName,
        }).Build();
        IInstanceStrategy<object, SerializationType> strategy = Substitute.For<IInstanceStrategy<object, SerializationType>>();
        var expected = new object();
        var factory = new InstanceFactory<object, SerializationType>([strategy]);

        _ = strategy.TryCreate(
            Arg.Is<IConfigurationSection>(section => section.Path == CustomType && section[NameKey] == SelectedName),
            selectedType,
            out Arg.Any<object?>()).Returns(call =>
        {
            call[OutArgumentIndex] = expected;
            return true;
        });

        // Act
        object actual = factory.Create(configuration);

        // Assert
        _ = await Assert.That(actual).IsSameReferenceAs(expected);
        _ = strategy.Received(ExpectedCalls).TryCreate(
            Arg.Is<IConfigurationSection>(section => section.Path == CustomType && section[NameKey] == SelectedName),
            selectedType,
            out Arg.Any<object?>());
    }

    private static IConfiguration CreateConfiguration()
    {
        var values = new Dictionary<string, string?>
        {
            [nameof(Options<int>.Type)] = SelectedTypeText,
            [$"{SelectedTypeText}:{NameKey}"] = SelectedName,
            [$"Other:{NameKey}"] = OtherName,
        };

        return new ConfigurationBuilder().AddInMemoryCollection(values).Build();
    }
}