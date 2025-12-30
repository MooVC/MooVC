namespace MooVC.Syntax
{
    using MooVC.Syntax.Concepts;

    public static class Builder
    {
        public static T New<T>()
            where T : Construct, new()
        {
            return new T();
        }
    }
}