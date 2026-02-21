namespace MooVC.Syntax.CSharp.Concepts
{
    using System;
    using Fluentify.Internal;

    public static partial class DefinitionExtensions
    {
        public static Definition For<T>(this Definition definition, Func<T, T> builder)
            where T : Type, new()
        {
            builder.ThrowIfNull(nameof(builder));

            var type = new T();

            type = builder(type);

            return definition.WithType(type);
        }
    }
}