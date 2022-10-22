using System.Collections.Generic;

public static class MoveObjectHolder
{
    private static ICollection<IMoveable> _moveObjects;

    public static ICollection<IMoveable> GetCollection() => _moveObjects;

    public static void AddObject(IMoveable moveable)
    {
        _moveObjects.Add(moveable);
    }

    public static void RemoveObject(IMoveable moveable)
    {
        _moveObjects.Remove(moveable);
    }

    public static void Clear()
    {
        _moveObjects.Clear();
    }
}
