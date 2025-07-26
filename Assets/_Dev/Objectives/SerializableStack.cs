using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SerializableStack<T>
{
    [SerializeField] private List<T> _list = new List<T>();

    public void Push(T item) => _list.Add(item);
    public T Pop()
    {
        if (_list.Count == 0)
            throw new InvalidOperationException("Stack is empty");
        var item = _list[^1];
        _list.RemoveAt(_list.Count - 1);
        return item;
    }
    public T Peek() => _list[^1];
    public int Count => _list.Count;
}
