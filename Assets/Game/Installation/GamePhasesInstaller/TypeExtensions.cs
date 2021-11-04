using System.Collections.Generic;
using System;
using System.Reflection;
using System.Linq;

internal static partial class TypeExtensions
{
    internal static Type[] AllTypesNeeds<RequiredT>()
    {
        List<Type> types = new List<Type>(2);

        foreach (var currentClass in GetAllClasses())
        {
            NeedsGamePhase attribute = currentClass.GetNeedsGamePhaseOrDefault<RequiredT>();

            if (attribute != null)
                types.Add(currentClass);
        }

        return types.ToArray();
    }

    private static NeedsGamePhase GetNeedsGamePhaseOrDefault<RequiredT>(this Type currentClass)
    {       
        return currentClass.GetCustomAttributes<NeedsGamePhase>()
            .FirstOrDefault(x => x.Requirement == typeof(RequiredT));
    }

    private static IEnumerable<Type> GetAllClasses()
    {
        return Assembly.GetExecutingAssembly().GetTypes()
            .Where(t => t.IsClass);
    }
}
