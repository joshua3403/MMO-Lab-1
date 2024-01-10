using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

internal class Pool
{
    private GameObject _prefab;
    private IObjectPool<GameObject> _pool;

    private Transform _root;
    private Transform Root
    {
        get
        {
            if (_root == null)
            {
                var go = new GameObject() { name = $"@{_prefab.name}Pool" };
                _root = go.transform;
            }

            return _root;
        }
    }

    public Pool(GameObject prefab)
    {
        _prefab = prefab;
        _pool = new ObjectPool<GameObject>(OnCreate, OnGet, OnRelease, OnDestroy);
    }

    public void Push(GameObject gameObject)
    {
        if (gameObject.activeSelf)
        {
            _pool.Release(gameObject);
        }
    }

    public GameObject Pop()
    {
        return _pool.Get();
    }

    #region Functions
    private GameObject OnCreate()
    {
        var go = GameObject.Instantiate(_prefab);
        go.transform.SetParent(Root);
        go.name = _prefab.name;
        return go;
    }

    private void OnGet(GameObject gameObject)
    {
        gameObject.SetActive(true);
    }

    private void OnRelease(GameObject gameObject)
    {
        gameObject.SetActive(false);
    }

    private void OnDestroy(GameObject gameObject)
    {
        GameObject.Destroy(gameObject);
    }
    #endregion
}

public class PoolManager
{
    private Dictionary<string, Pool> _pools = new();

    public GameObject Pop(GameObject gameObject)
    {
        if (_pools.ContainsKey(gameObject.name) == false)
        {
            CreatePool(gameObject);
        }

        return _pools[gameObject.name].Pop();
    }

    public bool Push(GameObject gameObject)
    {
        if (_pools.ContainsKey(gameObject.name) == false)
        {
            return false;
        }

        _pools[gameObject.name].Push(gameObject);
        return true;
    }

    public void Clear()
    {
        _pools.Clear();
    }

    private void CreatePool(GameObject gameObject)
    {
        var pool = new Pool(gameObject);
        _pools.Add(gameObject.name, pool);
    }
}
