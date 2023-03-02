using System.Collections.Generic;
using UnityEngine;

public class ObjectPooller : MonoBehaviour
{
    public List<Pool> pools;
    Dictionary<string, Queue<GameObject>> poolDictionary;

    #region Lazy Singelton
    public static ObjectPooller objectPooller;
    private void Awake()
    {
        objectPooller = this;
    }
    #endregion

    void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();
        foreach(Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();
            for (int i = 0; i < pool.size; i++)
            {
                GameObject fruit = Instantiate(pool.prefab);
                fruit.SetActive(false);
                objectPool.Enqueue(fruit);
            }
            poolDictionary.Add(pool.tag, objectPool);
        }
    }

    public GameObject SpawnFromPool(string tag, Vector3 positon)
    {
        if (!poolDictionary.ContainsKey(tag)) return null;

        GameObject objectToSpawn = poolDictionary[tag].Dequeue();

        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = positon;
        poolDictionary[tag].Enqueue(objectToSpawn);
        return objectToSpawn;
    }
}

