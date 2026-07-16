namespace MooVC.Syntax.ImmutableArrayExtensionsTests;

using System.Collections.Immutable;
using System.Xml.Linq;

public sealed class WhenGetIsCalled
{
    private const string First = "First";
    private const string Second = "Second";
    private const string ValueElement = "Value";

    [Test]
    public async Task GivenDefaultArrayThenReturnsEmpty()
    {
        // Arrange
        ImmutableArray<TestProducer> subject = default;

        // Act
        ImmutableArray<XElement> result = subject.Get(item => item.IsDefined);

        // Assert
        _ = await Assert.That(result).IsEmpty();
    }

    [Test]
    public async Task GivenMatchingItemsThenReturnsFragments()
    {
        // Arrange
        var included = new TestProducer(isDefined: true, First, Second);
        var excluded = new TestProducer(isDefined: false, "Excluded");
        ImmutableArray<TestProducer> subject = [included, excluded];

        // Act
        ImmutableArray<XElement> result = subject.Get(item => item.IsDefined);

        // Assert
        _ = await Assert.That(result.Length).IsEqualTo(2);
        _ = await Assert.That(result[0].Value).IsEqualTo(First);
        _ = await Assert.That(result[1].Value).IsEqualTo(Second);
    }

    private sealed class TestProducer
        : IProduceXml
    {
        private readonly string[] _values;

        public TestProducer(bool isDefined, params string[] values)
        {
            IsDefined = isDefined;
            _values = values;
        }

        public bool IsDefined { get; }

        public ImmutableArray<XElement> ToFragments()
        {
            return _values
                .Select(value => new XElement(ValueElement, value))
                .ToImmutableArray();
        }
    }
}