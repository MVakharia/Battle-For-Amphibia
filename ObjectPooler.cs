using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [SerializeField]
    private GameObject prefab;

    private List<GameObject> prefabPool;

    [SerializeField]
    private int poolSize;

    private void Awake()
    {
        prefabPool = new List<GameObject>(poolSize);

        for(int i = 0; i < poolSize; i++)
        {
            GameObject newObject = Instantiate(prefab, Vector3.zero, Quaternion.identity);

            newObject.SetActive(false);

            prefabPool.Add(newObject);
        }
    }

    public GameObject RemoveAndSpawnFromPool(Vector3 position, Quaternion rotation)
    {
        Projectile.IncrementActiveProjectiles();

        if (prefabPool.Count <= 0)
        {
            return Instantiate(prefab, position, Quaternion.identity);
        }

        GameObject result = prefabPool[prefabPool.Count - 1];

        prefabPool.RemoveAt(prefabPool.Count - 1);

        result.transform.position = position;

        result.transform.rotation = rotation;

        result.SetActive(true);

        return result;
    }

    public void ReAddToPool (GameObject projectile)
    {
        Projectile.DecrementActiveProjectiles();

        projectile.SetActive(false);

        prefabPool.Add(projectile);
    }
}