namespace MooVC.Syntax.CSharp.Attributes.Project.TargetTaskTests;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Xml.Linq;
using MooVC.Syntax.CSharp.Elements;

public sealed class WhenConstructorIsCalled
{
    [Fact]
    public void GivenDefaultsThenTargetTaskIsUndefined()
    {
        // Act
        var subject = new TargetTask();

        // Assert
        subject.Condition.ShouldBe(Snippet.Empty);
        subject.ContinueOnError.ShouldBe(TargetTask.Options.ErrorAndStop);
        subject.Name.ShouldBe(Identifier.Unnamed);
        subject.Outputs.ShouldBeEmpty();
        subject.Parameters.ShouldBeEmpty();
        subject.IsUndefined.ShouldBeTrue();
    }

    [Fact]
    public void GivenValuesThenPropertiesAreAssigned()
    {
        // Arrange
        TaskOutput output = TargetTaskTestsData.CreateOutput();
        TaskParameter parameter = TargetTaskTestsData.CreateParameter();

        // Act
        var subject = new TargetTask
        {
            Condition = Snippet.From(TargetTaskTestsData.DefaultCondition),
            ContinueOnError = TargetTask.Options.WarnAndContinue,
            Name = new Identifier(TargetTaskTestsData.DefaultName),
            Outputs = [output],
            Parameters = [parameter],
        };

        // Assert
        subject.Condition.ShouldBe(Snippet.From(TargetTaskTestsData.DefaultCondition));
        subject.ContinueOnError.ShouldBe(TargetTask.Options.WarnAndContinue);
        subject.Name.ShouldBe(new Identifier(TargetTaskTestsData.DefaultName));
        subject.Outputs.ShouldBe(new[] { output });
        subject.Parameters.ShouldBe(new[] { parameter });
        subject.IsUndefined.ShouldBeFalse();
    }
}

public sealed class WhenValidateIsCalled
{
    [Fact]
    public void GivenUndefinedThenValidationIsSkipped()
    {
        // Arrange
        TargetTask subject = TargetTask.Undefined;
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
        TargetTask subject = TargetTaskTestsData.Create(condition: Snippet.From($"alpha{Environment.NewLine}beta"));
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeFalse();
        _ = results.ShouldHaveSingleItem();
        results[0].MemberNames.ShouldContain(nameof(TargetTask.Condition));
    }

    [Fact]
    public void GivenUnnamedNameThenValidationErrorReturned()
    {
        // Arrange
        TargetTask subject = TargetTaskTestsData.Create(name: Identifier.Unnamed);
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeFalse();
        _ = results.ShouldHaveSingleItem();
        results[0].MemberNames.ShouldContain(nameof(TargetTask.Name));
    }

    [Fact]
    public void GivenUndefinedOutputThenValidationErrorReturned()
    {
        // Arrange
        TargetTask subject = TargetTaskTestsData.Create(output: TaskOutput.Undefined);
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeFalse();
        _ = results.ShouldHaveSingleItem();
        results[0].MemberNames.ShouldContain(nameof(TargetTask.Outputs));
    }
}

public sealed class WhenToStringIsCalled
{
    [Fact]
    public void GivenUndefinedThenReturnsEmpty()
    {
        // Arrange
        TargetTask subject = TargetTask.Undefined;

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldBe(string.Empty);
    }

    [Fact]
    public void GivenValuesThenReturnsFragment()
    {
        // Arrange
        TaskParameter parameter = TargetTaskTestsData.CreateParameter();
        TaskOutput output = TargetTaskTestsData.CreateOutput();
        TargetTask subject = TargetTaskTestsData.Create(
            condition: Snippet.From(TargetTaskTestsData.DefaultCondition),
            continueOnError: TargetTask.Options.WarnAndContinue,
            parameter: parameter,
            output: output);

        var outputElement = new XElement(
            "Output",
            new XAttribute(nameof(TaskOutput.Condition), TargetTaskTestsData.DefaultOutputCondition),
            new XAttribute(nameof(TaskOutput.ItemName), TargetTaskTestsData.DefaultOutputItemName),
            new XAttribute(nameof(TaskOutput.PropertyName), TargetTaskTestsData.DefaultOutputPropertyName),
            new XAttribute(nameof(TaskOutput.TaskParameter), TargetTaskTestsData.DefaultOutputTaskParameter));

        var element = new XElement(
            TargetTaskTestsData.DefaultName,
            new XAttribute(nameof(TargetTask.Condition), TargetTaskTestsData.DefaultCondition),
            new XAttribute("ContinueOnError", TargetTask.Options.WarnAndContinue.ToString()),
            new XAttribute(TargetTaskTestsData.DefaultParameterName, TargetTaskTestsData.DefaultParameterValue),
            outputElement);

        string expected = element + Environment.NewLine;

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldBe(expected);
    }
}

public sealed class WhenWithParametersIsCalled
{
    [Fact]
    public void GivenParametersThenReturnsUpdatedInstance()
    {
        // Arrange
        TaskParameter existing = TargetTaskTestsData.CreateParameter();
        TaskParameter additional = new TaskParameter
        {
            Name = new Identifier("Other"),
            Value = Snippet.From("Value"),
        };

        TargetTask original = TargetTaskTestsData.Create(parameter: existing);

        // Act
        TargetTask result = original.WithParameters(additional);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Parameters.ShouldBe(original.Parameters.Concat(new[] { additional }));
        result.Name.ShouldBe(original.Name);
        result.Condition.ShouldBe(original.Condition);
    }
}

public sealed class WhenEqualsTargetTaskIsCalled
{
    [Fact]
    public void GivenNullThenReturnsFalse()
    {
        // Arrange
        TargetTask subject = TargetTaskTestsData.Create();
        TargetTask? other = default;

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        TargetTask subject = TargetTaskTestsData.Create();
        TargetTask other = TargetTaskTestsData.Create();

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        TargetTask subject = TargetTaskTestsData.Create();
        TargetTask other = TargetTaskTestsData.Create(name: new Identifier("Other"));

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
        TargetTask subject = TargetTaskTestsData.Create();

        // Act
        bool result = subject.Equals(new object());

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        TargetTask subject = TargetTaskTestsData.Create();
        object other = TargetTaskTestsData.Create();

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeTrue();
    }
}

public sealed class WhenEqualityOperatorTargetTaskTargetTaskIsCalled
{
    [Fact]
    public void GivenBothNullThenReturnsTrue()
    {
        // Arrange
        TargetTask? left = default;
        TargetTask? right = default;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        TargetTask left = TargetTaskTestsData.Create();
        TargetTask right = TargetTaskTestsData.Create();

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        TargetTask left = TargetTaskTestsData.Create();
        TargetTask right = TargetTaskTestsData.Create(name: new Identifier("Other"));

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }
}

public sealed class WhenInequalityOperatorTargetTaskTargetTaskIsCalled
{
    [Fact]
    public void GivenDifferentValuesThenReturnsTrue()
    {
        // Arrange
        TargetTask left = TargetTaskTestsData.Create();
        TargetTask right = TargetTaskTestsData.Create(name: new Identifier("Other"));

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
        TargetTask left = TargetTaskTestsData.Create();
        TargetTask right = TargetTaskTestsData.Create();

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
        TargetTask left = TargetTaskTestsData.Create();
        TargetTask right = TargetTaskTestsData.Create(name: new Identifier("Other"));

        // Act
        int leftHash = left.GetHashCode();
        int rightHash = right.GetHashCode();

        // Assert
        leftHash.ShouldNotBe(rightHash);
    }
}

internal static class TargetTaskTestsData
{
    public const string DefaultCondition = "Condition";
    public const string DefaultName = "Build";
    public const string DefaultOutputCondition = "OutputCondition";
    public const string DefaultOutputItemName = "Item";
    public const string DefaultOutputPropertyName = "Property";
    public const string DefaultOutputTaskParameter = "TaskParameter";
    public const string DefaultParameterName = "Parameter";
    public const string DefaultParameterValue = "Value";

    public static TargetTask Create(
        Snippet? condition = default,
        TargetTask.Options? continueOnError = default,
        Identifier? name = default,
        TaskOutput? output = default,
        TaskParameter? parameter = default)
    {
        var value = new TargetTask
        {
            Condition = condition ?? Snippet.From(DefaultCondition),
            ContinueOnError = continueOnError ?? TargetTask.Options.ErrorAndStop,
            Name = name ?? new Identifier(DefaultName),
        };

        if (output is not null)
        {
            value = value.WithOutputs(output);
        }

        if (parameter is not null)
        {
            value = value.WithParameters(parameter);
        }

        return value;
    }

    public static TaskOutput CreateOutput()
    {
        return new TaskOutput
        {
            Condition = Snippet.From(DefaultOutputCondition),
            ItemName = new Identifier(DefaultOutputItemName),
            PropertyName = new Identifier(DefaultOutputPropertyName),
            TaskParameter = new Identifier(DefaultOutputTaskParameter),
        };
    }

    public static TaskParameter CreateParameter()
    {
        return new TaskParameter
        {
            Name = new Identifier(DefaultParameterName),
            Value = Snippet.From(DefaultParameterValue),
        };
    }
}