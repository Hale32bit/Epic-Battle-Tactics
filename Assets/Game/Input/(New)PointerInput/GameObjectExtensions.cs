using UnityEngine;

public static class GameObjectExtensions
{
    public static bool Is<T>(this GameObject obj)
    {
        return obj.TryGetComponent<T>(out T component);
    }
}
