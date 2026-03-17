namespace MooVC.Syntax.CSharp.Elements.ParameterTests.ModeTests;

public sealed class WhenPropertiesAreCalled
{
    [Test]
    [Arguments("in", true, false, false, false, false, false, false, false)]
    [Arguments("out", false, true, false, false, false, false, false, false)]
    [Arguments("", false, false, true, false, false, false, false, false)]
    [Arguments("params", false, false, false, true, false, false, false, false)]
    [Arguments("ref", false, false, false, false, true, false, false, false)]
    [Arguments("ref readonly", false, false, false, false, false, true, false, false)]
    [Arguments("scoped", false, false, false, false, false, false, true, false)]
    [Arguments("this", false, false, false, false, false, false, false, true)]
    public void GivenModeThenFlagsMatch(
        string value,
        bool expectedIn,
        bool expectedOut,
        bool expectedNone,
        bool expectedParams,
        bool expectedRef,
        bool expectedRefReadonly,
        bool expectedScoped,
        bool expectedThis)
    {
        // Arrange
        Parameter.Mode subject = value;

        // Act & Assert
        subject.IsIn.ShouldBe(expectedIn);
        subject.IsOut.ShouldBe(expectedOut);
        subject.IsNone.ShouldBe(expectedNone);
        subject.IsParams.ShouldBe(expectedParams);
        subject.IsRef.ShouldBe(expectedRef);
        subject.IsRefReadonly.ShouldBe(expectedRefReadonly);
        subject.IsScoped.ShouldBe(expectedScoped);
        subject.IsThis.ShouldBe(expectedThis);
    }
}