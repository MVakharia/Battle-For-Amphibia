using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject prefab;

    private List<GameObject> prefabPool;

    [SerializeField]
    private int projectilePoolSize;

    private void Awake()
    {
        prefabPool = new List<GameObject>(projectilePoolSize);

        for(int i = 0; i < projectilePoolSize; i++)
        {
            GameObject newProjectile = Instantiate(prefab, Vector3.zero, Quaternion.identity);

            newProjectile.SetActive(false);

            prefabPool.Add(newProjectile);
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