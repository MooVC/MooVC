namespace MooVC.Syntax.CSharp
{
    using MooVC.Syntax.CSharp.Concepts;

    public static class Builder
    {
        public static T New<T>()
            where T : Construct, new()
        {
            return new T();
        }
    }
}