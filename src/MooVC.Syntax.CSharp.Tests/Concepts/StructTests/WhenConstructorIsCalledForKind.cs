namespace MooVC.Syntax.CSharp.Concepts.StructTests;

using System;
using System.Reflection;

public sealed class WhenConstructorIsCalledForKind
{
    [Fact]
    public void GivenValueThenKindIsCreated()
    {
        // Act
        var subject = (Struct.Kind)Activator.CreateInstance(
            typeof(Struct.Kind),
            BindingFlags.Instance | BindingFlags.NonPublic,
            binder: null,
            args: new object[] { "readonly" },
            culture: null)!;

        // Assert
        subject.ShouldBe(Struct.Kind.ReadOnly);
    }
}
