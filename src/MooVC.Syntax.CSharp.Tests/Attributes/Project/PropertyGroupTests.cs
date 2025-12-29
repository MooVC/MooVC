namespace MooVC.Syntax.CSharp.Attributes.Project.PropertyGroupTests;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Xml.Linq;
using MooVC.Syntax.CSharp.Elements;

public sealed class WhenConstructorIsCalled
{
    [Fact]
    public void GivenDefaultsThenPropertyGroupIsUndefined()
    {
        // Act
        var subject = new PropertyGroup();

        // Assert
        subject.Condition.ShouldBe(Snippet.Empty);
        subject.Label.ShouldBe(Snippet.Empty);
        subject.Properties.ShouldBeEmpty();
        subject.IsUndefined.ShouldBeTrue();
    }

    [Fact]
    public void GivenValuesThenPropertiesAreAssigned()
    {
        // Arrange
        Property property = PropertyGroupTestsData.CreateProperty();

        // Act
        var subject = new PropertyGroup
        {
            Condition = Snippet.From(PropertyGroupTestsData.DefaultCondition),
            Label = Snippet.From(PropertyGroupTestsData.DefaultLabel),
            Properties = [property],
        };

        // Assert
        subject.Condition.ShouldBe(Snippet.From(PropertyGroupTestsData.DefaultCondition));
        subject.Label.ShouldBe(Snippet.From(PropertyGroupTestsData.DefaultLabel));
        subject.Properties.ShouldBe(new[] { property });
        subject.IsUndefined.ShouldBeFalse();
    }
}

public sealed class WhenValidateIsCalled
{
    [Fact]
    public void GivenUndefinedThenValidationIsSkipped()
    {
        // Arrange
        PropertyGroup subject = PropertyGroup.Undefined;
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
        PropertyGroup subject = PropertyGroupTestsData.Create(condition: Snippet.From($"alpha{Environment.NewLine}beta"));
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeFalse();
        _ = results.ShouldHaveSingleItem();
        results[0].MemberNames.ShouldContain(nameof(PropertyGroup.Condition));
    }

    [Fact]
    public void GivenUndefinedPropertyThenValidationErrorReturned()
    {
        // Arrange
        PropertyGroup subject = PropertyGroupTestsData.Create(property: Property.Undefined);
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeFalse();
        _ = results.ShouldHaveSingleItem();
        results[0].MemberNames.ShouldContain(nameof(PropertyGroup.Properties));
    }
}

public sealed class WhenToStringIsCalled
{
    [Fact]
    public void GivenUndefinedThenReturnsEmpty()
    {
        // Arrange
        PropertyGroup subject = PropertyGroup.Undefined;

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldBe(string.Empty);
    }

    [Fact]
    public void GivenValuesThenReturnsFragment()
    {
        // Arrange
        Property property = PropertyGroupTestsData.CreateProperty();
        PropertyGroup subject = PropertyGroupTestsData.Create(property: property);

        var propertyElement = new XElement(
            PropertyGroupTestsData.DefaultPropertyName,
            new XAttribute(nameof(Property.Condition), PropertyGroupTestsData.DefaultPropertyCondition),
            PropertyGroupTestsData.DefaultPropertyValue);

        var element = new XElement(
            nameof(PropertyGroup),
            new XAttribute(nameof(PropertyGroup.Condition), PropertyGroupTestsData.DefaultCondition),
            new XAttribute(nameof(PropertyGroup.Label), PropertyGroupTestsData.DefaultLabel),
            propertyElement);

        string expected = element + Environment.NewLine;

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldBe(expected);
    }
}

public sealed class WhenWithPropertiesIsCalled
{
    [Fact]
    public void GivenPropertiesThenReturnsUpdatedInstance()
    {
        // Arrange
        Property existing = PropertyGroupTestsData.CreateProperty();
        Property additional = new Property
        {
            Condition = Snippet.From("Extra"),
            Name = new Identifier("Other"),
            Value = Snippet.From("Value"),
        };

        PropertyGroup original = PropertyGroupTestsData.Create(property: existing);

        // Act
        PropertyGroup result = original.WithProperties(additional);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Properties.ShouldBe(original.Properties.Concat(new[] { additional }));
        result.Condition.ShouldBe(original.Condition);
        result.Label.ShouldBe(original.Label);
    }
}

public sealed class WhenEqualsPropertyGroupIsCalled
{
    [Fact]
    public void GivenNullThenReturnsFalse()
    {
        // Arrange
        PropertyGroup subject = PropertyGroupTestsData.Create();
        PropertyGroup? other = default;

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        PropertyGroup subject = PropertyGroupTestsData.Create();
        PropertyGroup other = PropertyGroupTestsData.Create();

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        PropertyGroup subject = PropertyGroupTestsData.Create();
        PropertyGroup other = PropertyGroupTestsData.Create(label: Snippet.From("Other"));

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
        PropertyGroup subject = PropertyGroupTestsData.Create();

        // Act
        bool result = subject.Equals(new object());

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        PropertyGroup subject = PropertyGroupTestsData.Create();
        object other = PropertyGroupTestsData.Create();

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeTrue();
    }
}

public sealed class WhenEqualityOperatorPropertyGroupPropertyGroupIsCalled
{
    [Fact]
    public void GivenBothNullThenReturnsTrue()
    {
        // Arrange
        PropertyGroup? left = default;
        PropertyGroup? right = default;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        PropertyGroup left = PropertyGroupTestsData.Create();
        PropertyGroup right = PropertyGroupTestsData.Create();

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        PropertyGroup left = PropertyGroupTestsData.Create();
        PropertyGroup right = PropertyGroupTestsData.Create(label: Snippet.From("Other"));

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }
}

public sealed class WhenInequalityOperatorPropertyGroupPropertyGroupIsCalled
{
    [Fact]
    public void GivenDifferentValuesThenReturnsTrue()
    {
        // Arrange
        PropertyGroup left = PropertyGroupTestsData.Create();
        PropertyGroup right = PropertyGroupTestsData.Create(label: Snippet.From("Other"));

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
        PropertyGroup left = PropertyGroupTestsData.Create();
        PropertyGroup right = PropertyGroupTestsData.Create();

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
        PropertyGroup left = PropertyGroupTestsData.Create();
        PropertyGroup right = PropertyGroupTestsData.Create(label: Snippet.From("Other"));

        // Act
        int leftHash = left.GetHashCode();
        int rightHash = right.GetHashCode();

        // Assert
        leftHash.ShouldNotBe(rightHash);
    }
}

internal static class PropertyGroupTestsData
{
    public const string DefaultCondition = "Condition";
    public const string DefaultLabel = "Label";
    public const string DefaultPropertyCondition = "PropertyCondition";
    public const string DefaultPropertyName = "Property";
    public const string DefaultPropertyValue = "Value";

    public static PropertyGroup Create(
        Snippet? condition = default,
        Snippet? label = default,
        Property? property = default)
    {
        var values = new PropertyGroup
        {
            Condition = condition ?? Snippet.From(DefaultCondition),
            Label = label ?? Snippet.From(DefaultLabel),
        };

        if (property is not null)
        {
            values = values.WithProperties(property);
        }

        return values;
    }

    public static Property CreateProperty()
    {
        return new Property
        {
            Condition = Snippet.From(DefaultPropertyCondition),
            Name = new Identifier(DefaultPropertyName),
            Value = Snippet.From(DefaultPropertyValue),
        };
    }
}