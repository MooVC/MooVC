namespace MooVC.Syntax.CSharp.Elements.ParameterTests.ModeTests;

public sealed class WhenPropertiesAreCalled
{
    [Theory]
    [InlineData("in", true, false, false, false, false, false, false, false)]
    [InlineData("out", false, true, false, false, false, false, false, false)]
    [InlineData("", false, false, true, false, false, false, false, false)]
    [InlineData("params", false, false, false, true, false, false, false, false)]
    [InlineData("ref", false, false, false, false, true, false, false, false)]
    [InlineData("ref readonly", false, false, false, false, false, true, false, false)]
    [InlineData("scoped", false, false, false, false, false, false, true, false)]
    [InlineData("this", false, false, false, false, false, false, false, true)]
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