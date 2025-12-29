namespace MooVC.Syntax.CSharp.Attributes.Project.TaskOutputTests;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using MooVC.Syntax.CSharp.Elements;

public sealed class WhenConstructorIsCalled
{
    [Fact]
    public void GivenDefaultsThenTaskOutputIsUndefined()
    {
        // Act
        var subject = new TaskOutput();

        // Assert
        subject.Condition.ShouldBe(Snippet.Empty);
        subject.ItemName.ShouldBe(Identifier.Unnamed);
        subject.PropertyName.ShouldBe(Identifier.Unnamed);
        subject.TaskParameter.ShouldBe(Identifier.Unnamed);
        subject.IsUndefined.ShouldBeTrue();
    }

    [Fact]
    public void GivenValuesThenPropertiesAreAssigned()
    {
        // Act
        var subject = new TaskOutput
        {
            Condition = Snippet.From(TaskOutputTestsData.DefaultCondition),
            ItemName = new Identifier(TaskOutputTestsData.DefaultItemName),
            PropertyName = new Identifier(TaskOutputTestsData.DefaultPropertyName),
            TaskParameter = new Identifier(TaskOutputTestsData.DefaultTaskParameter),
        };

        // Assert
        subject.Condition.ShouldBe(Snippet.From(TaskOutputTestsData.DefaultCondition));
        subject.ItemName.ShouldBe(new Identifier(TaskOutputTestsData.DefaultItemName));
        subject.PropertyName.ShouldBe(new Identifier(TaskOutputTestsData.DefaultPropertyName));
        subject.TaskParameter.ShouldBe(new Identifier(TaskOutputTestsData.DefaultTaskParameter));
        subject.IsUndefined.ShouldBeFalse();
    }
}

public sealed class WhenValidateIsCalled
{
    [Fact]
    public void GivenUndefinedThenValidationIsSkipped()
    {
        // Arrange
        TaskOutput subject = TaskOutput.Undefined;
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeTrue();
        results.ShouldBeEmpty();
    }

    [Fact]
    public void GivenMultiLineConditionThenValidationErrorReturned()
    {
        // Arrange
        TaskOutput subject = TaskOutputTestsData.Create(condition: Snippet.From($"alpha{Environment.NewLine}beta"));
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeFalse();
        _ = results.ShouldHaveSingleItem();
        results[0].MemberNames.ShouldContain(nameof(TaskOutput.Condition));
    }

    [Fact]
    public void GivenItemWithoutPropertyThenValidationErrorReturned()
    {
        // Arrange
        TaskOutput subject = TaskOutputTestsData.Create(propertyName: Identifier.Unnamed);
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeFalse();
        _ = results.ShouldHaveSingleItem();
        results[0].MemberNames.ShouldContain(nameof(TaskOutput.PropertyName));
    }

    [Fact]
    public void GivenPropertyWithoutItemThenValidationErrorReturned()
    {
        // Arrange
        TaskOutput subject = TaskOutputTestsData.Create(itemName: Identifier.Unnamed, propertyName: new Identifier("Property"));
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeFalse();
        _ = results.ShouldHaveSingleItem();
        results[0].MemberNames.ShouldContain(nameof(TaskOutput.ItemName));
    }
}

public sealed class WhenToStringIsCalled
{
    [Fact]
    public void GivenUndefinedThenReturnsEmpty()
    {
        // Arrange
        TaskOutput subject = TaskOutput.Undefined;

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldBe(string.Empty);
    }

    [Fact]
    public void GivenValuesThenReturnsFragment()
    {
        // Arrange
        TaskOutput subject = TaskOutputTestsData.Create();
        var element = new XElement(
            "Output",
            new XAttribute(nameof(TaskOutput.Condition), TaskOutputTestsData.DefaultCondition),
            new XAttribute(nameof(TaskOutput.ItemName), TaskOutputTestsData.DefaultItemName),
            new XAttribute(nameof(TaskOutput.PropertyName), TaskOutputTestsData.DefaultPropertyName),
            new XAttribute(nameof(TaskOutput.TaskParameter), TaskOutputTestsData.DefaultTaskParameter));

        string expected = element + Environment.NewLine;

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldBe(expected);
    }
}

public sealed class WhenWithItemNameIsCalled
{
    [Fact]
    public void GivenValueThenReturnsUpdatedInstance()
    {
        // Arrange
        TaskOutput original = TaskOutputTestsData.Create();
        Identifier updated = new Identifier("Other");

        // Act
        TaskOutput result = original.WithItemName(updated);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.ItemName.ShouldBe(updated);
        result.PropertyName.ShouldBe(original.PropertyName);
        result.TaskParameter.ShouldBe(original.TaskParameter);
        result.Condition.ShouldBe(original.Condition);
    }
}

public sealed class WhenEqualsTaskOutputIsCalled
{
    [Fact]
    public void GivenNullThenReturnsFalse()
    {
        // Arrange
        TaskOutput subject = TaskOutputTestsData.Create();
        TaskOutput? other = default;

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        TaskOutput subject = TaskOutputTestsData.Create();
        TaskOutput other = TaskOutputTestsData.Create();

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        TaskOutput subject = TaskOutputTestsData.Create();
        TaskOutput other = TaskOutputTestsData.Create(itemName: new Identifier("Other"));

        // Act
        bool result = subject.Equals(other);

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
        TaskOutput subject = TaskOutputTestsData.Create();

        // Act
        bool result = subject.Equals(new object());

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        TaskOutput subject = TaskOutputTestsData.Create();
        object other = TaskOutputTestsData.Create();

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeTrue();
    }
}

public sealed class WhenEqualityOperatorTaskOutputTaskOutputIsCalled
{
    [Fact]
    public void GivenBothNullThenReturnsTrue()
    {
        // Arrange
        TaskOutput? left = default;
        TaskOutput? right = default;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        TaskOutput left = TaskOutputTestsData.Create();
        TaskOutput right = TaskOutputTestsData.Create();

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        TaskOutput left = TaskOutputTestsData.Create();
        TaskOutput right = TaskOutputTestsData.Create(itemName: new Identifier("Other"));

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }
}

public sealed class WhenInequalityOperatorTaskOutputTaskOutputIsCalled
{
    [Fact]
    public void GivenDifferentValuesThenReturnsTrue()
    {
        // Arrange
        TaskOutput left = TaskOutputTestsData.Create();
        TaskOutput right = TaskOutputTestsData.Create(itemName: new Identifier("Other"));

        // Act
        bool result = left != right;

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
        TaskOutput left = TaskOutputTestsData.Create();
        TaskOutput right = TaskOutputTestsData.Create();

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
        TaskOutput left = TaskOutputTestsData.Create();
        TaskOutput right = TaskOutputTestsData.Create(itemName: new Identifier("Other"));

        // Act
        int leftHash = left.GetHashCode();
        int rightHash = right.GetHashCode();

        // Assert
        leftHash.ShouldNotBe(rightHash);
    }
}

internal static class TaskOutputTestsData
{
    public const string DefaultCondition = "Condition";
    public const string DefaultItemName = "Item";
    public const string DefaultPropertyName = "Property";
    public const string DefaultTaskParameter = "Parameter";

    public static TaskOutput Create(
        Snippet? condition = default,
        Identifier? itemName = default,
        Identifier? propertyName = default,
        Identifier? taskParameter = default)
    {
        return new TaskOutput
        {
            Condition = condition ?? Snippet.From(DefaultCondition),
            ItemName = itemName ?? new Identifier(DefaultItemName),
            PropertyName = propertyName ?? new Identifier(DefaultPropertyName),
            TaskParameter = taskParameter ?? new Identifier(DefaultTaskParameter),
        };
    }
}