namespace MooVC.Syntax.CSharp.Attributes.Project.TargetTaskOptionsTests;

using System.Linq;

public sealed class WhenToStringIsCalled
{
    [Theory]
    [InlineData("WarnAndContinue", nameof(TargetTask.Options.WarnAndContinue))]
    [InlineData("ErrorAndContinue", nameof(TargetTask.Options.ErrorAndContinue))]
    [InlineData("ErrorAndStop ", nameof(TargetTask.Options.ErrorAndStop))]
    public void GivenOptionThenReturnsValue(string expected, string field)
    {
        // Arrange
        TargetTask.Options subject = typeof(TargetTask.Options)
            .GetField(field)!
            .GetValue(null) as TargetTask.Options ?? TargetTask.Options.ErrorAndStop;

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldBe(expected);
    }
}

public sealed class WhenImplicitOperatorFromStringIsCalled
{
    [Fact]
    public void GivenValueThenCreatesOption()
    {
        // Arrange
        const string Value = "WarnAndContinue";

        // Act
        TargetTask.Options subject = Value;

        // Assert
        (subject == Value).ShouldBeTrue();
        subject.Equals(Value).ShouldBeTrue();
    }

    [Fact]
    public void GivenValueWhenRoundTrippedThenReturnsOriginal()
    {
        // Arrange
        const string Value = "ErrorAndContinue";

        // Act
        TargetTask.Options subject = Value;
        string result = subject;

        // Assert
        result.ShouldBe(Value);
    }
}

public sealed class WhenEqualsOptionsIsCalled
{
    [Fact]
    public void GivenNullThenReturnsFalse()
    {
        // Arrange
        TargetTask.Options subject = TargetTask.Options.WarnAndContinue;
        TargetTask.Options? other = default;

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        TargetTask.Options subject = TargetTask.Options.WarnAndContinue;
        TargetTask.Options other = TargetTask.Options.WarnAndContinue;

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        TargetTask.Options subject = TargetTask.Options.WarnAndContinue;
        TargetTask.Options other = TargetTask.Options.ErrorAndContinue;

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeFalse();
    }
}

public sealed class WhenEqualsStringIsCalled
{
    [Fact]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        TargetTask.Options subject = TargetTask.Options.WarnAndContinue;

        // Act
        bool result = subject.Equals("WarnAndContinue");

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        TargetTask.Options subject = TargetTask.Options.ErrorAndContinue;

        // Act
        bool result = subject.Equals("WarnAndContinue");

        // Assert
        result.ShouldBeFalse();
    }
}

public sealed class WhenEqualsObjectIsCalled
{
    [Fact]
    public void GivenOtherTypeThenReturnsFalse()
    {
        // Arrange
        TargetTask.Options subject = TargetTask.Options.WarnAndContinue;

        // Act
        bool result = subject.Equals(new object());

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        TargetTask.Options subject = TargetTask.Options.WarnAndContinue;
        object other = TargetTask.Options.WarnAndContinue;

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeTrue();
    }
}

public sealed class WhenEqualityOperatorOptionsOptionsIsCalled
{
    [Fact]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        TargetTask.Options left = TargetTask.Options.WarnAndContinue;
        TargetTask.Options right = TargetTask.Options.WarnAndContinue;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        TargetTask.Options left = TargetTask.Options.WarnAndContinue;
        TargetTask.Options right = TargetTask.Options.ErrorAndContinue;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }
}

public sealed class WhenEqualityOperatorOptionsStringIsCalled
{
    [Fact]
    public void GivenMatchingValueThenReturnsTrue()
    {
        // Arrange
        TargetTask.Options left = TargetTask.Options.WarnAndContinue;
        const string Right = "WarnAndContinue";

        // Act
        bool result = left == Right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentValueThenReturnsFalse()
    {
        // Arrange
        TargetTask.Options left = TargetTask.Options.ErrorAndContinue;
        const string Right = "WarnAndContinue";

        // Act
        bool result = left == Right;

        // Assert
        result.ShouldBeFalse();
    }
}

public sealed class WhenInequalityOperatorOptionsOptionsIsCalled
{
    [Fact]
    public void GivenDifferentValuesThenReturnsTrue()
    {
        // Arrange
        TargetTask.Options left = TargetTask.Options.WarnAndContinue;
        TargetTask.Options right = TargetTask.Options.ErrorAndContinue;

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeTrue();
    }
}

public sealed class WhenInequalityOperatorOptionsStringIsCalled
{
    [Fact]
    public void GivenDifferentValuesThenReturnsTrue()
    {
        // Arrange
        TargetTask.Options left = TargetTask.Options.ErrorAndContinue;
        const string Right = "WarnAndContinue";

        // Act
        bool result = left != Right;

        // Assert
        result.ShouldBeTrue();
    }
}

public sealed class WhenGetHashCodeIsCalled
{
    [Fact]
    public void GivenEqualValuesThenHashCodesMatch()
    {
        // Arrange
        TargetTask.Options left = TargetTask.Options.WarnAndContinue;
        TargetTask.Options right = TargetTask.Options.WarnAndContinue;

        // Act
        int leftHash = left.GetHashCode();
        int rightHash = right.GetHashCode();

        // Assert
        leftHash.ShouldBe(rightHash);
    }

    [Fact]
    public void GivenDifferentValuesThenHashCodesDiffer()
    {
        // Arrange
        TargetTask.Options left = TargetTask.Options.WarnAndContinue;
        TargetTask.Options right = TargetTask.Options.ErrorAndContinue;

        // Act
        int leftHash = left.GetHashCode();
        int rightHash = right.GetHashCode();

        // Assert
        leftHash.ShouldNotBe(rightHash);
    }
}

public sealed class WhenToXmlAttributeIsCalled
{
    [Fact]
    public void GivenErrorAndStopThenReturnsEmptySequence()
    {
        // Arrange
        TargetTask.Options subject = TargetTask.Options.ErrorAndStop;

        // Act
        var attributes = subject.ToXmlAttribute().ToArray();

        // Assert
        attributes.ShouldBeEmpty();
    }

    [Fact]
    public void GivenValueThenReturnsContinueOnErrorAttribute()
    {
        // Arrange
        TargetTask.Options subject = TargetTask.Options.WarnAndContinue;

        // Act
        var attributes = subject.ToXmlAttribute().ToArray();

        // Assert
        _ = attributes.ShouldHaveSingleItem();
        attributes[0].Name.ToString().ShouldBe("ContinueOnError");
        attributes[0].Value.ShouldBe(subject.ToString());
    }
}