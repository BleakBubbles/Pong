using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Reflection;
using System.Linq;

public static class ToolBox
{
    public static T GetOrAddComponent<T>(this GameObject gameObject) where T : Component
    {
        return gameObject.GetComponent<T>() ?? gameObject.AddComponent<T>();
    }
    public static IEnumerable<Type> FindDerivedTypes(Assembly assembly, Type baseType)
    {
        return assembly.GetTypes().Where(t => t != baseType && baseType.IsAssignableFrom(t));
    }
}
