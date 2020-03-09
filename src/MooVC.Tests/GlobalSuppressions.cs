using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage(
    "Style",
    "IDE0058:Expression value is never used",
    Justification = "False positive due to use of dynamic type.",
    Scope = "member",
    Target = "~M:MooVC.Dynamic.ExpandoObjectExtensionsTests.WhenCloneIsCalled.GivenAnInitializedObjectWithAnExpandoObjectContainedWithinThenItWillReturnANewObjectWithTheChildCloned")]
