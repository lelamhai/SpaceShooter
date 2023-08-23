using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public class SerializableDictionary: IDictionary, ISerializationCallbackReceiver
{
    public bool IsFixedSize => throw new NotImplementedException();

    public bool IsReadOnly => throw new NotImplementedException();

    public ICollection Keys => throw new NotImplementedException();

    public ICollection Values => throw new NotImplementedException();

    public int Count => throw new NotImplementedException();

    public bool IsSynchronized => throw new NotImplementedException();

    public object SyncRoot => throw new NotImplementedException();

    public object this[object key] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    // save the dictionary to lists
    public void OnBeforeSerialize()
    {}

    // load the dictionary from lists
    public void OnAfterDeserialize()
    {}

    public void Add(object key, object value)
    {
        throw new NotImplementedException();
    }

    public void Clear()
    {
        throw new NotImplementedException();
    }

    public bool Contains(object key)
    {
        throw new NotImplementedException();
    }

    public IDictionaryEnumerator GetEnumerator()
    {
        throw new NotImplementedException();
    }

    public void Remove(object key)
    {
        throw new NotImplementedException();
    }

    public void CopyTo(Array array, int index)
    {
        throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        throw new NotImplementedException();
    }
}