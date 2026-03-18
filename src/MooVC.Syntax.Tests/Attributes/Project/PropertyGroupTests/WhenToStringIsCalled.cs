namespace MooVC.Syntax.Attributes.Project.PropertyGroupTests;

using System;
using System.Xml.Linq;

public sealed class WhenToStringIsCalled
{
    [Test]
    public async Task GivenUndefinedThenReturnsEmpty()
    {
        // Arrange
        PropertyGroup subject = PropertyGroup.Undefined;

        // Act
        string result = subject.ToString();

        // Assert
        _ = await Assert.That(result).IsEqualTo(string.Empty);
    }

    [Test]
    public async Task GivenValuesThenReturnsFragment()
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
        _ = await Assert.That(result).IsEqualTo(expected);
    }
}