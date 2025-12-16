namespace MooVC.Syntax.CSharp.Concepts.StructTests.KindTests;

using System;
using System.Reflection;

public sealed class WhenConstructorIsCalled
{
    [Fact]
    public void GivenValueThenKindIsCreated()
    {
        // Act
        var subject = (Struct.Kind)Activator.CreateInstance(
            typeof(Struct.Kind),
            BindingFlags.Instance | BindingFlags.NonPublic,
            binder: null,
            args: ["readonly"],
            culture: null)!;

        // Assert
        subject.ShouldBe(Struct.Kind.ReadOnly);
    }
}