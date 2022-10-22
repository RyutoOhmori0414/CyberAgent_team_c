using System.Collections.Generic;

public class MoveObjectHolder
{
    private ICollection<IMoveable> _moveObjects;

    public ICollection<IMoveable> GetCollection() => _moveObjects;

    public void AddObject(IMoveable moveable)
    {
        _moveObjects.Add(moveable);
    }

    public void RemoveObject(IMoveable moveable)
    {
        _moveObjects.Remove(moveable);
    }

    public void Clear()
    {
        _moveObjects.Clear();
    }
}
