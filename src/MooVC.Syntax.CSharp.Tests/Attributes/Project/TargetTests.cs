namespace MooVC.Syntax.CSharp.Attributes.Project.TargetTests;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Xml.Linq;
using MooVC.Syntax.CSharp.Elements;

public sealed class WhenConstructorIsCalled
{
    [Fact]
    public void GivenDefaultsThenTargetIsUndefined()
    {
        // Act
        var subject = new Target();

        // Assert
        subject.AfterTargets.ShouldBe(Snippet.Empty);
        subject.BeforeTargets.ShouldBe(Snippet.Empty);
        subject.Condition.ShouldBe(Snippet.Empty);
        subject.DependsOnTargets.ShouldBe(Snippet.Empty);
        subject.Inputs.ShouldBe(Snippet.Empty);
        subject.KeepDuplicateOutputs.ShouldBeFalse();
        subject.Label.ShouldBe(Snippet.Empty);
        subject.Name.ShouldBe(Identifier.Unnamed);
        subject.Outputs.ShouldBe(Snippet.Empty);
        subject.Returns.ShouldBe(Snippet.Empty);
        subject.Tasks.ShouldBeEmpty();
        subject.IsUndefined.ShouldBeTrue();
    }

    [Fact]
    public void GivenValuesThenPropertiesAreAssigned()
    {
        // Arrange
        TargetTask task = TargetTestsData.CreateTask();

        // Act
        var subject = new Target
        {
            AfterTargets = Snippet.From(TargetTestsData.DefaultAfterTargets),
            BeforeTargets = Snippet.From(TargetTestsData.DefaultBeforeTargets),
            Condition = Snippet.From(TargetTestsData.DefaultCondition),
            DependsOnTargets = Snippet.From(TargetTestsData.DefaultDependsOnTargets),
            Inputs = Snippet.From(TargetTestsData.DefaultInputs),
            KeepDuplicateOutputs = true,
            Label = Snippet.From(TargetTestsData.DefaultLabel),
            Name = new Identifier(TargetTestsData.DefaultName),
            Outputs = Snippet.From(TargetTestsData.DefaultOutputs),
            Returns = Snippet.From(TargetTestsData.DefaultReturns),
            Tasks = [task],
        };

        // Assert
        subject.AfterTargets.ShouldBe(Snippet.From(TargetTestsData.DefaultAfterTargets));
        subject.BeforeTargets.ShouldBe(Snippet.From(TargetTestsData.DefaultBeforeTargets));
        subject.Condition.ShouldBe(Snippet.From(TargetTestsData.DefaultCondition));
        subject.DependsOnTargets.ShouldBe(Snippet.From(TargetTestsData.DefaultDependsOnTargets));
        subject.Inputs.ShouldBe(Snippet.From(TargetTestsData.DefaultInputs));
        subject.KeepDuplicateOutputs.ShouldBeTrue();
        subject.Label.ShouldBe(Snippet.From(TargetTestsData.DefaultLabel));
        subject.Name.ShouldBe(new Identifier(TargetTestsData.DefaultName));
        subject.Outputs.ShouldBe(Snippet.From(TargetTestsData.DefaultOutputs));
        subject.Returns.ShouldBe(Snippet.From(TargetTestsData.DefaultReturns));
        subject.Tasks.ShouldBe(new[] { task });
        subject.IsUndefined.ShouldBeFalse();
    }
}

public sealed class WhenValidateIsCalled
{
    [Fact]
    public void GivenUndefinedThenValidationIsSkipped()
    {
        // Arrange
        Target subject = Target.Undefined;
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
        Target subject = TargetTestsData.Create(condition: Snippet.From($"alpha{Environment.NewLine}beta"));
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeFalse();
        _ = results.ShouldHaveSingleItem();
        results[0].MemberNames.ShouldContain(nameof(Target.Condition));
    }

    [Fact]
    public void GivenUnnamedNameThenValidationErrorReturned()
    {
        // Arrange
        Target subject = TargetTestsData.Create(name: Identifier.Unnamed);
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeFalse();
        _ = results.ShouldHaveSingleItem();
        results[0].MemberNames.ShouldContain(nameof(Target.Name));
    }

    [Fact]
    public void GivenUndefinedTaskThenValidationErrorReturned()
    {
        // Arrange
        Target subject = TargetTestsData.Create(task: TargetTask.Undefined);
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeFalse();
        _ = results.ShouldHaveSingleItem();
        results[0].MemberNames.ShouldContain(nameof(Target.Tasks));
    }
}

public sealed class WhenToStringIsCalled
{
    [Fact]
    public void GivenUndefinedThenReturnsEmpty()
    {
        // Arrange
        Target subject = Target.Undefined;

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldBe(string.Empty);
    }

    [Fact]
    public void GivenValuesThenReturnsFragment()
    {
        // Arrange
        TargetTask task = TargetTestsData.CreateTask();
        Target subject = TargetTestsData.Create(task: task, keepDuplicateOutputs: true);

        var taskElement = new XElement(
            TargetTestsData.DefaultTaskName,
            new XAttribute(nameof(TargetTask.Condition), TargetTestsData.DefaultTaskCondition));

        var element = new XElement(
            nameof(Target),
            new XAttribute(nameof(Target.AfterTargets), TargetTestsData.DefaultAfterTargets),
            new XAttribute(nameof(Target.BeforeTargets), TargetTestsData.DefaultBeforeTargets),
            new XAttribute(nameof(Target.Condition), TargetTestsData.DefaultCondition),
            new XAttribute(nameof(Target.DependsOnTargets), TargetTestsData.DefaultDependsOnTargets),
            new XAttribute(nameof(Target.Inputs), TargetTestsData.DefaultInputs),
            new XAttribute(nameof(Target.KeepDuplicateOutputs), true.ToString().ToLowerInvariant()),
            new XAttribute(nameof(Target.Label), TargetTestsData.DefaultLabel),
            new XAttribute(nameof(Target.Name), TargetTestsData.DefaultName),
            new XAttribute(nameof(Target.Outputs), TargetTestsData.DefaultOutputs),
            new XAttribute(nameof(Target.Returns), TargetTestsData.DefaultReturns),
            taskElement);

        string expected = element + Environment.NewLine;

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldBe(expected);
    }
}

public sealed class WhenWithTasksIsCalled
{
    [Fact]
    public void GivenTasksThenReturnsUpdatedInstance()
    {
        // Arrange
        TargetTask existing = TargetTestsData.CreateTask();
        TargetTask additional = new TargetTask { Name = new Identifier("Other") };
        Target original = TargetTestsData.Create(task: existing);

        // Act
        Target result = original.WithTasks(additional);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Tasks.ShouldBe(original.Tasks.Concat(new[] { additional }));
        result.Name.ShouldBe(original.Name);
        result.Label.ShouldBe(original.Label);
    }
}

public sealed class WhenEqualsTargetIsCalled
{
    [Fact]
    public void GivenNullThenReturnsFalse()
    {
        // Arrange
        Target subject = TargetTestsData.Create();
        Target? other = default;

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Target subject = TargetTestsData.Create();
        Target other = TargetTestsData.Create();

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Target subject = TargetTestsData.Create();
        Target other = TargetTestsData.Create(label: Snippet.From("Other"));

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
        Target subject = TargetTestsData.Create();

        // Act
        bool result = subject.Equals(new object());

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Target subject = TargetTestsData.Create();
        object other = TargetTestsData.Create();

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeTrue();
    }
}

public sealed class WhenEqualityOperatorTargetTargetIsCalled
{
    [Fact]
    public void GivenBothNullThenReturnsTrue()
    {
        // Arrange
        Target? left = default;
        Target? right = default;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Target left = TargetTestsData.Create();
        Target right = TargetTestsData.Create();

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Target left = TargetTestsData.Create();
        Target right = TargetTestsData.Create(label: Snippet.From("Other"));

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }
}

public sealed class WhenInequalityOperatorTargetTargetIsCalled
{
    [Fact]
    public void GivenDifferentValuesThenReturnsTrue()
    {
        // Arrange
        Target left = TargetTestsData.Create();
        Target right = TargetTestsData.Create(label: Snippet.From("Other"));

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
        Target left = TargetTestsData.Create();
        Target right = TargetTestsData.Create();

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
        Target left = TargetTestsData.Create();
        Target right = TargetTestsData.Create(label: Snippet.From("Other"));

        // Act
        int leftHash = left.GetHashCode();
        int rightHash = right.GetHashCode();

        // Assert
        leftHash.ShouldNotBe(rightHash);
    }
}

internal static class TargetTestsData
{
    public const string DefaultAfterTargets = "AfterTargets";
    public const string DefaultBeforeTargets = "BeforeTargets";
    public const string DefaultCondition = "Condition";
    public const string DefaultDependsOnTargets = "DependsOnTargets";
    public const string DefaultInputs = "Inputs";
    public const string DefaultLabel = "Label";
    public const string DefaultName = "Build";
    public const string DefaultOutputs = "Outputs";
    public const string DefaultReturns = "Returns";
    public const string DefaultTaskCondition = "TaskCondition";
    public const string DefaultTaskName = "Compile";

    public static Target Create(
        Snippet? afterTargets = default,
        Snippet? beforeTargets = default,
        Snippet? condition = default,
        Snippet? dependsOnTargets = default,
        Snippet? inputs = default,
        bool keepDuplicateOutputs = false,
        Snippet? label = default,
        Identifier? name = default,
        Snippet? outputs = default,
        Snippet? returns = default,
        TargetTask? task = default)
    {
        var value = new Target
        {
            AfterTargets = afterTargets ?? Snippet.From(DefaultAfterTargets),
            BeforeTargets = beforeTargets ?? Snippet.From(DefaultBeforeTargets),
            Condition = condition ?? Snippet.From(DefaultCondition),
            DependsOnTargets = dependsOnTargets ?? Snippet.From(DefaultDependsOnTargets),
            Inputs = inputs ?? Snippet.From(DefaultInputs),
            KeepDuplicateOutputs = keepDuplicateOutputs,
            Label = label ?? Snippet.From(DefaultLabel),
            Name = name ?? new Identifier(DefaultName),
            Outputs = outputs ?? Snippet.From(DefaultOutputs),
            Returns = returns ?? Snippet.From(DefaultReturns),
        };

        if (task is not null)
        {
            value = value.WithTasks(task);
        }

        return value;
    }

    public static TargetTask CreateTask()
    {
        return new TargetTask
        {
            Condition = Snippet.From(DefaultTaskCondition),
            Name = new Identifier(DefaultTaskName),
        };
    }
}