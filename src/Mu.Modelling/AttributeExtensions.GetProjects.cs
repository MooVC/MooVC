namespace Mu.Modelling;

using System.Collections.Immutable;
using MooVC.Collections.Generic;
using MooVC.Syntax.Elements;

public static partial class AttributeExtensions
{
    internal static ImmutableArray<Qualifier> GetProjects(this IEnumerable<Attribute> attributes, Name company, params Name[] names)
    {
        IEnumerable<Qualifier> unique = attributes
            .Select(attribute => attribute.Type.Qualifier)
            .Distinct();

        var projects = new HashSet<Qualifier>();

        if (company.IsUnnamed)
        {
            GetProjects(0, projects, names, unique);
        }
        else
        {
            foreach (IGrouping<Name, Qualifier> name in unique.GroupBy(qualifier => qualifier[0]))
            {
                if (name.Key == company)
                {
                    GetProjects(1, projects, names, unique);
                }
            }
        }

        return [.. projects];
    }

    private static void GetProjects(int offset, HashSet<Qualifier> projects, Name[] names, IEnumerable<Qualifier> unique)
    {
        if (!HasName(names, offset))
        {
            return;
        }

        IGrouping<Name, Qualifier>? model = FindGroup(unique, offset, names[offset]);

        if (model is null)
        {
            return;
        }

        int areaOffset = offset + 1;

        if (!HasName(names, areaOffset))
        {
            AddProjects(projects, model, areaOffset + 0);
            return;
        }

        IGrouping<Name, Qualifier>? area = FindGroup(model, areaOffset, names[areaOffset]);

        if (area is null)
        {
            return;
        }

        int unitOffset = offset + 2;

        if (!HasName(names, unitOffset))
        {
            AddProjects(projects, area, unitOffset);

            return;
        }

        foreach (IGrouping<Name, Qualifier> unit in model.GroupBy(qualifier => qualifier[unitOffset]))
        {
            if (unit.Key == names[unitOffset])
            {
                continue;
            }

            AddProjects(projects, unit, unitOffset + 1);
        }
    }

    private static IGrouping<Name, Qualifier>? FindGroup(IEnumerable<Qualifier> qualifiers, int offset, Name name)
    {
        return qualifiers
            .GroupBy(qualifier => qualifier[offset])
            .FirstOrDefault(group => group.Key == name);
    }

    private static void AddProjects(HashSet<Qualifier> projects, IEnumerable<Qualifier> qualifiers, int length)
    {
        projects.AddRange(qualifiers.Select(qualifier => new Qualifier([.. qualifier.Take(length)])));
    }

    private static bool HasName(Name[] names, int offset)
    {
        return names.Length > offset && !names[offset].IsUnnamed;
    }
}