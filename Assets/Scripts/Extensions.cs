using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extensions
{
    static public T GetOrAddComponent<T>(this GameObject gameObject) where T : Component
    {
        return gameObject.GetComponent<T>() ?? gameObject.AddComponent<T>();
    }
}
