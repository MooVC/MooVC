namespace MooVC.Syntax.CSharp.GenericTests;

using MooVC.Syntax.CSharp.SymbolTests;

public sealed class WhenToStringIsCalled
{
    private const string Name = "TValue";

    [Test]
    public async Task GivenValueThenReturnsFormattedString()
    {
        // Arrange
        var constraint = new Constraint { Base = new(SymbolTestsData.CreateWithArgumentNames()) };

        var subject = new Generic
        {
            Name = new(Name),
            Constraints = [constraint],
        };

        // Act
        string result = subject.ToString();

        // Assert
        _ = await Assert.That(result).IsEqualTo(Name);
    }
}