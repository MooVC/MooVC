namespace Muify;

using System.Diagnostics.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Testing;

internal static class Frameworks
{
    public static readonly IReadOnlyList<(ReferenceAssemblies Assembly, LanguageVersion Maximum, DateOnly SupportTo)> InScope =
    [
        (ReferenceAssemblies.Net.Net60, LanguageVersion.CSharp10, new DateOnly(2024, 11, 12)),
        (ReferenceAssemblies.Net.Net70, LanguageVersion.CSharp10, new DateOnly(2024, 5, 14)),
        (ReferenceAssemblies.Net.Net80, LanguageVersion.CSharp10, new DateOnly(2026, 11, 10)),
        (ReferenceAssemblies.Net.Net90, LanguageVersion.CSharp10, new DateOnly(2026, 11, 10)),
        (ReferenceAssemblies.NetStandard.NetStandard21, LanguageVersion.CSharp8, DateOnly.MaxValue),
    ];

    private static readonly LanguageVersion[] _languages;

    [SuppressMessage("CodeQuality", "IDE0079:Remove unnecessary suppression", Justification = "The removal suggestion is a false positive.")]
    [SuppressMessage("Minor Code Smell", "S3963:\"static\" fields should be initialized inline", Justification = "It cannot be initialized inline.")]
    static Frameworks()
    {
        _languages = Enum.GetValues<LanguageVersion>();
    }

    public static IEnumerable<object[]> All(LanguageVersion minimum, Func<ReferenceAssemblies, LanguageVersion, object[]?>? prepare = default)
    {
        return Filter(InScope, maximum => _languages.Where(language => language >= minimum && language <= maximum), prepare);
    }

    public static IEnumerable<object[]> Supported(LanguageVersion minimum, Func<ReferenceAssemblies, LanguageVersion, object[]?>? prepare = default)
    {
        var today = DateOnly.FromDateTime(DateTime.UtcNow);

        return Filter(InScope.Where(framework => framework.SupportTo >= today && framework.Maximum >= minimum), maximum => [maximum], prepare);
    }

    private static IEnumerable<object[]> Filter(
        IEnumerable<(ReferenceAssemblies Assembly, LanguageVersion Maximum, DateOnly SupportedTo)> frameworks,
        Func<LanguageVersion, IEnumerable<LanguageVersion>> languages,
        Func<ReferenceAssemblies, LanguageVersion, object[]?>? prepare)
    {
        prepare ??= (assembly, language) => [assembly, language];

        foreach ((ReferenceAssemblies assembly, LanguageVersion maximum, DateOnly _) in frameworks)
        {
            foreach (LanguageVersion language in languages(maximum))
            {
                object[]? payload = prepare(assembly, language);

                if (payload is not null)
                {
                    yield return payload;
                }
            }
        }
    }
}