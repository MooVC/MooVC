namespace Mu.Modelling;

using System;
using Mu.Modelling.State;

public sealed record Model
{
    private static readonly Type basis = typeof(Aggregate);

    private Model(Type type)
    {
        if (!basis.IsAssignableFrom(type))
        {
            throw new ArgumentException($"Type `{type}` must derive from `{basis}`.", nameof(type));
        }

        if (type.IsAbstract || !type.IsSealed)
        {
            throw new ArgumentException($"Type `{type}` must be a sealed, concrete derivation of `{basis}`.", nameof(type));
        }

        Name = type.Name;
        Namespace = type.Namespace!;
        Assembly = type.Assembly.GetName().Name!;
    }

    public string Assembly { get; }

    public string Name { get; }

    public string Namespace { get; }

    public static implicit operator Model(Type type)
    {
        ArgumentNullException.ThrowIfNull(type);

        return new Model(type);
    }

    public static implicit operator Type(Model model)
    {
        ArgumentNullException.ThrowIfNull(model);

        Type type = Type.GetType($"{model.Namespace}.{model.Name}, {model.Assembly}", throwOnError: false)
            ?? throw new ArgumentException($"The type associated with `{model}` is not available to load by this process.");

        return type;
    }
}