namespace MooVC.Syntax.CSharp.Attributes.Project.TaskParameterTests;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using MooVC.Syntax.CSharp.Elements;

public sealed class WhenConstructorIsCalled
{
    [Fact]
    public void GivenDefaultsThenTaskParameterIsUndefined()
    {
        // Act
        var subject = new TaskParameter();

        // Assert
        subject.Name.ShouldBe(Identifier.Unnamed);
        subject.Value.ShouldBe(Snippet.Empty);
        subject.IsUndefined.ShouldBeTrue();
    }

    [Fact]
    public void GivenValuesThenPropertiesAreAssigned()
    {
        // Act
        var subject = new TaskParameter
        {
            Name = new Identifier(TaskParameterTestsData.DefaultName),
            Value = Snippet.From(TaskParameterTestsData.DefaultValue),
        };

        // Assert
        subject.Name.ShouldBe(new Identifier(TaskParameterTestsData.DefaultName));
        subject.Value.ShouldBe(Snippet.From(TaskParameterTestsData.DefaultValue));
        subject.IsUndefined.ShouldBeFalse();
    }
}

public sealed class WhenValidateIsCalled
{
    [Fact]
    public void GivenUndefinedThenValidationIsSkipped()
    {
        // Arrange
        TaskParameter subject = TaskParameter.Undefined;
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeTrue();
        results.ShouldBeEmpty();
    }

    [Fact]
    public void GivenUnnamedNameThenValidationErrorReturned()
    {
        // Arrange
        TaskParameter subject = TaskParameterTestsData.Create(name: Identifier.Unnamed);
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeFalse();
        _ = results.ShouldHaveSingleItem();
        results[0].MemberNames.ShouldContain(nameof(TaskParameter.Name));
    }

    [Fact]
    public void GivenMultiLineValueThenValidationErrorReturned()
    {
        // Arrange
        TaskParameter subject = TaskParameterTestsData.Create(value: Snippet.From($"alpha{Environment.NewLine}beta"));
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeFalse();
        _ = results.ShouldHaveSingleItem();
        results[0].MemberNames.ShouldContain(nameof(TaskParameter.Value));
    }
}

public sealed class WhenToStringIsCalled
{
    [Fact]
    public void GivenUndefinedThenReturnsEmpty()
    {
        // Arrange
        TaskParameter subject = TaskParameter.Undefined;

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldBe(string.Empty);
    }

    [Fact]
    public void GivenValuesThenReturnsFragment()
    {
        // Arrange
        TaskParameter subject = TaskParameterTestsData.Create();
        var element = new XElement(
            "Parameter",
            new XAttribute(nameof(TaskParameter.Name), TaskParameterTestsData.DefaultName),
            TaskParameterTestsData.DefaultValue);

        string expected = element + Environment.NewLine;

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldBe(expected);
    }
}

public sealed class WhenWithNameIsCalled
{
    [Fact]
    public void GivenValueThenReturnsUpdatedInstance()
    {
        // Arrange
        TaskParameter original = TaskParameterTestsData.Create();
        Identifier updated = new Identifier("Other");

        // Act
        TaskParameter result = original.WithName(updated);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Name.ShouldBe(updated);
        result.Value.ShouldBe(original.Value);
    }
}

public sealed class WhenEqualsTaskParameterIsCalled
{
    [Fact]
    public void GivenNullThenReturnsFalse()
    {
        // Arrange
        TaskParameter subject = TaskParameterTestsData.Create();
        TaskParameter? other = default;

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        TaskParameter subject = TaskParameterTestsData.Create();
        TaskParameter other = TaskParameterTestsData.Create();

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        TaskParameter subject = TaskParameterTestsData.Create();
        TaskParameter other = TaskParameterTestsData.Create(name: new Identifier("Other"));

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
        TaskParameter subject = TaskParameterTestsData.Create();

        // Act
        bool result = subject.Equals(new object());

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        TaskParameter subject = TaskParameterTestsData.Create();
        object other = TaskParameterTestsData.Create();

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeTrue();
    }
}

public sealed class WhenEqualityOperatorTaskParameterTaskParameterIsCalled
{
    [Fact]
    public void GivenBothNullThenReturnsTrue()
    {
        // Arrange
        TaskParameter? left = default;
        TaskParameter? right = default;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        TaskParameter left = TaskParameterTestsData.Create();
        TaskParameter right = TaskParameterTestsData.Create();

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        TaskParameter left = TaskParameterTestsData.Create();
        TaskParameter right = TaskParameterTestsData.Create(name: new Identifier("Other"));

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }
}

public sealed class WhenInequalityOperatorTaskParameterTaskParameterIsCalled
{
    [Fact]
    public void GivenDifferentValuesThenReturnsTrue()
    {
        // Arrange
        TaskParameter left = TaskParameterTestsData.Create();
        TaskParameter right = TaskParameterTestsData.Create(name: new Identifier("Other"));

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
        TaskParameter left = TaskParameterTestsData.Create();
        TaskParameter right = TaskParameterTestsData.Create();

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
        TaskParameter left = TaskParameterTestsData.Create();
        TaskParameter right = TaskParameterTestsData.Create(name: new Identifier("Other"));

        // Act
        int leftHash = left.GetHashCode();
        int rightHash = right.GetHashCode();

        // Assert
        leftHash.ShouldNotBe(rightHash);
    }
}

internal static class TaskParameterTestsData
{
    public const string DefaultName = "Parameter";
    public const string DefaultValue = "Value";

    public static TaskParameter Create(
        Identifier? name = default,
        Snippet? value = default)
    {
        return new TaskParameter
        {
            Name = name ?? new Identifier(DefaultName),
            Value = value ?? Snippet.From(DefaultValue),
        };
    }
}