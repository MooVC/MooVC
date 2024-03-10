namespace MooVC;

/// <summary>
/// A function that facilitates customization of the value prior to assignment.
/// </summary>
/// <typeparam name="T">The type of the value to be customized.</typeparam>
/// <param name="value">The value instance to be customized.</param>
/// <returns>The customized <paramref name="value"/>, which may be a new instance.</returns>
public delegate T Mutator<T>(T value);