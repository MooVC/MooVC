namespace MooVC.Composition.CollectionFactoryTests;

using Microsoft.Extensions.Configuration;
using MooVC.Configuration;
using Compression = MooVC.Compression.Configuration.Type;

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
    public async Task GivenMatchingConfigurationThenTheSelectedOptionsAndTypeArePassedToTheStrategy()
    {
        // Arrange
        IConfiguration configuration = CreateConfiguration();
        ICollectionStrategy<object, TestOptions, int> strategy = Substitute.For<ICollectionStrategy<object, TestOptions, int>>();
        IEnumerable<object> expected = [new object(), new object()];
        var factory = new CollectionFactory<object, TestOptions, int>([strategy]);

        _ = strategy.TryCreate(Arg.Is<TestOptions>(options => options.Name == SelectedName), SelectedType, out Arg.Any<IEnumerable<object>?>()).Returns(call =>
        {
            call[OutArgumentIndex] = expected;
            return true;
        });

        // Act
        IEnumerable<object> actual = factory.Create(configuration);

        // Assert
        _ = await Assert.That(actual).IsSameReferenceAs(expected);
        _ = strategy.Received(ExpectedCalls).TryCreate(Arg.Is<TestOptions>(options => options.Name == SelectedName), SelectedType, out Arg.Any<IEnumerable<object>?>());
    }

    [Test]
    public async Task GivenARejectingStrategyBeforeASuccessfulStrategyThenTheSuccessfulResultIsReturned()
    {
        // Arrange
        IConfiguration configuration = CreateConfiguration();
        ICollectionStrategy<object, TestOptions, int> first = Substitute.For<ICollectionStrategy<object, TestOptions, int>>();
        ICollectionStrategy<object, TestOptions, int> second = Substitute.For<ICollectionStrategy<object, TestOptions, int>>();
        ICollectionStrategy<object, TestOptions, int> third = Substitute.For<ICollectionStrategy<object, TestOptions, int>>();
        IEnumerable<object> expected = [new object()];
        var factory = new CollectionFactory<object, TestOptions, int>([first, second, third]);

        _ = second.TryCreate(Arg.Is<TestOptions>(options => options.Name == SelectedName), SelectedType, out Arg.Any<IEnumerable<object>?>()).Returns(call =>
        {
            call[OutArgumentIndex] = expected;
            return true;
        });

        // Act
        IEnumerable<object> actual = factory.Create(configuration);

        // Assert
        _ = await Assert.That(actual).IsSameReferenceAs(expected);

        Received.InOrder(() =>
        {
            _ = first.TryCreate(Arg.Is<TestOptions>(options => options.Name == SelectedName), SelectedType, out Arg.Any<IEnumerable<object>?>());
            _ = second.TryCreate(Arg.Is<TestOptions>(options => options.Name == SelectedName), SelectedType, out Arg.Any<IEnumerable<object>?>());
        });

        _ = third.DidNotReceiveWithAnyArgs().TryCreate(default!, default, out _);
    }

    [Test]
    public async Task GivenNoStrategiesThenAnInvalidOperationExceptionIsThrown()
    {
        // Arrange
        IConfiguration configuration = CreateConfiguration();
        var factory = new CollectionFactory<object, TestOptions, int>([]);

        // Act
        Func<IEnumerable<object>> act = () => factory.Create(configuration);

        // Assert
        InvalidOperationException exception = await Assert.That(act).Throws<InvalidOperationException>().And.IsNotNull();
        _ = await Assert.That(exception.Message).Contains(typeof(object).ToString());
    }

    [Test]
    public async Task GivenOnlyRejectingStrategiesThenAnInvalidOperationExceptionIsThrown()
    {
        // Arrange
        IConfiguration configuration = CreateConfiguration();
        ICollectionStrategy<object, TestOptions, int> first = Substitute.For<ICollectionStrategy<object, TestOptions, int>>();
        ICollectionStrategy<object, TestOptions, int> second = Substitute.For<ICollectionStrategy<object, TestOptions, int>>();
        var factory = new CollectionFactory<object, TestOptions, int>([first, second]);

        // Act
        Func<IEnumerable<object>> act = () => factory.Create(configuration);

        // Assert
        InvalidOperationException exception = await Assert.That(act).Throws<InvalidOperationException>().And.IsNotNull();
        _ = await Assert.That(exception.Message).Contains(typeof(object).ToString());
        _ = first.Received(ExpectedCalls).TryCreate(Arg.Is<TestOptions>(options => options.Name == SelectedName), SelectedType, out Arg.Any<IEnumerable<object>?>());
        _ = second.Received(ExpectedCalls).TryCreate(Arg.Is<TestOptions>(options => options.Name == SelectedName), SelectedType, out Arg.Any<IEnumerable<object>?>());
    }

    [Test]
    public async Task GivenAStrategyThatThrowsThenTheExceptionIsPropagated()
    {
        // Arrange
        const string Message = "Strategy failed.";
        IConfiguration configuration = CreateConfiguration();
        ICollectionStrategy<object, TestOptions, int> strategy = Substitute.For<ICollectionStrategy<object, TestOptions, int>>();
        var expected = new InvalidOperationException(Message);
        var factory = new CollectionFactory<object, TestOptions, int>([strategy]);

        _ = strategy.TryCreate(Arg.Is<TestOptions>(options => options.Name == SelectedName), SelectedType, out Arg.Any<IEnumerable<object>?>()).Returns(_ => throw expected);

        // Act
        Func<IEnumerable<object>> act = () => factory.Create(configuration);

        // Assert
        InvalidOperationException actual = await Assert.That(act).Throws<InvalidOperationException>().And.IsNotNull();
        _ = await Assert.That(actual).IsSameReferenceAs(expected);
    }

    [Test]
    public async Task GivenNullConfigurationThenAnArgumentNullExceptionIsThrown()
    {
        // Arrange
        IConfiguration configuration = null!;
        var factory = new CollectionFactory<object, TestOptions, int>([]);

        // Act
        Func<IEnumerable<object>> act = () => factory.Create(configuration);

        // Assert
        ArgumentNullException exception = await Assert.That(act).Throws<ArgumentNullException>().And.IsNotNull();
        _ = await Assert.That(exception.ParamName).IsEqualTo(nameof(configuration));
    }

    [Test]
    public async Task GivenASuccessfulStrategyWithAnEmptyCollectionThenTheEmptyCollectionIsReturned()
    {
        // Arrange
        IConfiguration configuration = CreateConfiguration();
        ICollectionStrategy<object, TestOptions, int> strategy = Substitute.For<ICollectionStrategy<object, TestOptions, int>>();
        IEnumerable<object> expected = [];
        var factory = new CollectionFactory<object, TestOptions, int>([strategy]);

        _ = strategy.TryCreate(Arg.Is<TestOptions>(options => options.Name == SelectedName), SelectedType, out Arg.Any<IEnumerable<object>?>()).Returns(call =>
        {
            call[OutArgumentIndex] = expected;
            return true;
        });

        // Act
        IEnumerable<object> actual = factory.Create(configuration);

        // Assert
        _ = await Assert.That(actual).IsSameReferenceAs(expected);
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
        ICollectionStrategy<object, TestOptions, int> strategy = Substitute.For<ICollectionStrategy<object, TestOptions, int>>();
        IEnumerable<object> expected = [new object()];
        var factory = new CollectionFactory<object, TestOptions, int>([strategy]);

        _ = strategy.TryCreate(Arg.Is<TestOptions>(options => options.Name == SelectedName), DefaultType, out Arg.Any<IEnumerable<object>?>()).Returns(call =>
        {
            call[OutArgumentIndex] = expected;
            return true;
        });

        // Act
        IEnumerable<object> actual = factory.Create(configuration);

        // Assert
        _ = await Assert.That(actual).IsSameReferenceAs(expected);
    }

    [Test]
    public async Task GivenNoSelectedSectionThenAnArgumentNullExceptionIsThrown()
    {
        // Arrange
        IConfiguration configuration = new ConfigurationBuilder().AddInMemoryCollection(new Dictionary<string, string?>
        {
            [nameof(Options<int>.Type)] = SelectedTypeText,
        }).Build();
        ICollectionStrategy<object, TestOptions, int> strategy = Substitute.For<ICollectionStrategy<object, TestOptions, int>>();
        var factory = new CollectionFactory<object, TestOptions, int>([strategy]);

        // Act
        Func<IEnumerable<object>> act = () => factory.Create(configuration);

        // Assert
        ArgumentNullException exception = await Assert.That(act).Throws<ArgumentNullException>().And.IsNotNull();
        _ = await Assert.That(exception.ParamName).IsEqualTo("options");
        _ = strategy.DidNotReceiveWithAnyArgs().TryCreate(default!, default, out _);
    }

    [Test]
    [Arguments("invalid")]
    [Arguments("2147483648")]
    public async Task GivenAMalformedSelectorThenAnInvalidOperationExceptionIsThrownBeforeStrategiesAreCalled(string value)
    {
        // Arrange
        IConfiguration configuration = new ConfigurationBuilder().AddInMemoryCollection(new Dictionary<string, string?>
        {
            [nameof(Options<int>.Type)] = value,
        }).Build();
        ICollectionStrategy<object, TestOptions, int> strategy = Substitute.For<ICollectionStrategy<object, TestOptions, int>>();
        var factory = new CollectionFactory<object, TestOptions, int>([strategy]);

        // Act
        Func<IEnumerable<object>> act = () => factory.Create(configuration);

        // Assert
        _ = await Assert.That(act).Throws<InvalidOperationException>();
        _ = strategy.DidNotReceiveWithAnyArgs().TryCreate(default!, default, out _);
    }

    [Test]
    public async Task GivenANestedConfigurationThenSelectorAndSettingsAreReadFromThatSection()
    {
        // Arrange
        const string ParentSection = "Parent";
        const string RootType = "0";
        IConfigurationSection configuration = new ConfigurationBuilder().AddInMemoryCollection(new Dictionary<string, string?>
        {
            [nameof(Options<int>.Type)] = RootType,
            [$"{SelectedTypeText}:{NameKey}"] = OtherName,
            [$"{ParentSection}:{nameof(Options<int>.Type)}"] = SelectedTypeText,
            [$"{ParentSection}:{SelectedTypeText}:{NameKey}"] = SelectedName,
        }).Build().GetSection(ParentSection);
        ICollectionStrategy<object, TestOptions, int> strategy = Substitute.For<ICollectionStrategy<object, TestOptions, int>>();
        IEnumerable<object> expected = [new object()];
        var factory = new CollectionFactory<object, TestOptions, int>([strategy]);

        _ = strategy.TryCreate(Arg.Is<TestOptions>(options => options.Name == SelectedName), SelectedType, out Arg.Any<IEnumerable<object>?>()).Returns(call =>
        {
            call[OutArgumentIndex] = expected;
            return true;
        });

        // Act
        IEnumerable<object> actual = factory.Create(configuration);

        // Assert
        _ = await Assert.That(actual).IsSameReferenceAs(expected);
        _ = strategy.Received(ExpectedCalls).TryCreate(Arg.Is<TestOptions>(options => options.Name == SelectedName), SelectedType, out Arg.Any<IEnumerable<object>?>());
    }

    [Test]
    public async Task GivenADifferentSelectorInSelectedOptionsThenTheOuterSelectorChoosesTheStrategy()
    {
        // Arrange
        const int InnerType = 42;
        const string InnerTypeText = "42";
        IConfiguration configuration = new ConfigurationBuilder().AddInMemoryCollection(new Dictionary<string, string?>
        {
            [nameof(Options<int>.Type)] = SelectedTypeText,
            [$"{SelectedTypeText}:{nameof(Options<int>.Type)}"] = InnerTypeText,
            [$"{SelectedTypeText}:{NameKey}"] = SelectedName,
            [$"{InnerTypeText}:{NameKey}"] = OtherName,
        }).Build();
        ICollectionStrategy<object, TestOptions, int> strategy = Substitute.For<ICollectionStrategy<object, TestOptions, int>>();
        IEnumerable<object> expected = [new object()];
        var factory = new CollectionFactory<object, TestOptions, int>([strategy]);

        _ = strategy.TryCreate(Arg.Is<TestOptions>(options => (options.Name == SelectedName) && (options.Type == InnerType)), SelectedType, out Arg.Any<IEnumerable<object>?>()).Returns(call =>
        {
            call[OutArgumentIndex] = expected;
            return true;
        });

        // Act
        IEnumerable<object> actual = factory.Create(configuration);

        // Assert
        _ = await Assert.That(actual).IsSameReferenceAs(expected);
        _ = strategy.Received(ExpectedCalls).TryCreate(Arg.Is<TestOptions>(options => (options.Name == SelectedName) && (options.Type == InnerType)), SelectedType, out Arg.Any<IEnumerable<object>?>());
    }

    [Test]
    public async Task GivenACustomCompressionSelectorThenItsNamedOptionsArePassedToTheStrategy()
    {
        // Arrange
        const string CustomType = "Custom.Compression";
        Compression selected = CustomType;
        IConfiguration configuration = new ConfigurationBuilder().AddInMemoryCollection(new Dictionary<string, string?>
        {
            [nameof(Options<Compression>.Type)] = CustomType,
            [$"{CustomType}:{NameKey}"] = SelectedName,
            [$"Other:{NameKey}"] = OtherName,
        }).Build();
        ICollectionStrategy<object, TestCompressionOptions, Compression> strategy = Substitute.For<ICollectionStrategy<object, TestCompressionOptions, Compression>>();
        IEnumerable<object> expected = [new object()];
        var factory = new CollectionFactory<object, TestCompressionOptions, Compression>([strategy]);

        _ = strategy.TryCreate(Arg.Is<TestCompressionOptions>(options => options.Name == SelectedName), selected, out Arg.Any<IEnumerable<object>?>()).Returns(call =>
        {
            call[OutArgumentIndex] = expected;
            return true;
        });

        // Act
        IEnumerable<object> actual = factory.Create(configuration);

        // Assert
        _ = await Assert.That(actual).IsSameReferenceAs(expected);
        _ = strategy.Received(ExpectedCalls).TryCreate(Arg.Is<TestCompressionOptions>(options => options.Name == SelectedName), selected, out Arg.Any<IEnumerable<object>?>());
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

    public sealed class TestCompressionOptions
        : Options<Compression>
    {
        public string Name { get; set; } = string.Empty;
    }

    public sealed class TestOptions
        : Options<int>
    {
        public string Name { get; set; } = string.Empty;
    }
}