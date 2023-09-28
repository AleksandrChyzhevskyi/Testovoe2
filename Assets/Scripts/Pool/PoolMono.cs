using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class PoolMono<T> where T : MonoBehaviour
{
    private List<T> _pool;
    public T Prifab { get; }
    public bool AutoExpand { get; set; }
    public Transform Container { get; }

    public PoolMono(T prifab, int count, Transform conteiner)
    {
        Prifab = prifab;
        Container = conteiner;
        CreatePool(count);
    }

    private void CreatePool(int count)
    {
        _pool = new List<T>();

        for (int i = 0; i < count; i++)
            CreateObject();
    }

    private T CreateObject(bool isActiveByDefault = false)
    {
        var createdObject = Object.Instantiate(Prifab, Container);
        createdObject.gameObject.SetActive(isActiveByDefault);
        _pool.Add(createdObject);
        return createdObject;
    }

    public bool HasFreeElement(out T element)
    {
        foreach (var mono in _pool)
        {
            if (mono.gameObject.activeInHierarchy == false)
            {
                element = mono;
                mono.gameObject.SetActive(true);
                return true;
            }
        }

        element = null;
        return false;
    }

    public T GetFreeElement()
    {
        if (HasFreeElement(out var element))
            return element;

        if (AutoExpand)
            return CreateObject(true);

        throw new Exception($"There is no free elements in pool of type {typeof(T)}");
    }
}