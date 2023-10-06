namespace MooVC.Collections.Generic.DictionaryExtensionsTests;

using System.Collections.Generic;
using FluentAssertions;
using Xunit;

public sealed class WhenToNewOrCopyIsCalled
{
    [Fact]
    public void GivenANullDictionaryThenAnEmptyDictionaryIsReturned()
    {
        // Arrange
        IDictionary<string, object>? original = default;

        // Act
        IDictionary<string, object>? snapshot = original.ToNewOrCopy();

        // Assert
        _ = snapshot.Should().NotBeNull();
        _ = snapshot.Should().BeEmpty();
    }

    [Fact]
    public void GivenADictionaryThenACloneIsReturned()
    {
        // Arrange
        IDictionary<string, int>? original = new Dictionary<string, int>
        {
            { "First", 1 },
            { "Second", 2 },
        };

        // Act
        IDictionary<string, int>? snapshot = original.ToNewOrCopy();

        // Assert
        _ = snapshot.Should().NotBeSameAs(original);
        _ = snapshot.Should().Equal(original);
    }

    [Fact]
    public void GivenAnEmptyDictionaryThenAnEmptyCloneIsReturned()
    {
        // Arrange
        IDictionary<string, int>? original = new Dictionary<string, int>();

        // Act
        IDictionary<string, int>? snapshot = original.ToNewOrCopy();

        // Assert
        _ = snapshot.Should().NotBeSameAs(original);
        _ = snapshot.Should().Equal(original);
    }
}