namespace MooVC.Syntax.CSharp.Attributes.Project.PropertyGroupTests;

using System;
using System.Xml.Linq;

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