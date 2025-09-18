using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> : MonoBehaviour where T : Component
{
    [SerializeField] private T _prefab;
    [SerializeField] private int _poolSize;

    private List<T> _objectPool = new List<T>();

    protected void Awake()
    {
        Initialize();
    }

    protected void Initialize()
    {
        T obj;

        for (int i = 0; i < _poolSize; i++)
        {
            obj = Instantiate(_prefab, gameObject.transform, false);
            _objectPool.Add(obj);

            obj.gameObject.SetActive(false);
        }
    }

    public T GetItemFromPool()
    {
        for (int i = 0; i < _objectPool.Count; i++)
        {
            if (!_objectPool[i].gameObject.activeInHierarchy)
            {
                _objectPool[i].gameObject.SetActive(true);
                return _objectPool[i];
            }
        }

        T newObj = Instantiate(_prefab, transform, false);
        _objectPool.Add(newObj);
        return newObj;
    }

    public void ReturnItemToPool(T item)
    {
        item.gameObject.SetActive(false);
    }
}
