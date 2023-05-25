using System.Collections;
using UnityEngine;

public class ProjectileWeapon : MonoBehaviour
{
    [SerializeField]    private ObjectSpawner objSpawner;
    [SerializeField]    private GameObject[] spawnPointArray;
    [SerializeField]    private GameObject pivot;
    [SerializeField]    private float pivotSpeed;
    [SerializeField]    private float maximumAngle;
    [SerializeField]    private bool isFiring;
    [SerializeField]    private int setNumber;

    public int SetNumber => setNumber;

    [SerializeField]
    private float fireRate;

    [SerializeField]
    private float projectileSpeed;

    //Fire one projectile from one spawn point. 
    private IEnumerator FireProjectile (int numberOfProjectiles, GameObject spawnPoint, float projectilesPerSecond, float speed, Vector3 travelDirection, float extraSpeed)
    {
        for (int i = 0; i < numberOfProjectiles; i++)
        {
            if (GameManager.Singleton.GameState == GameState.GameOver) break;

            GameObject projectile = objSpawner.RemoveAndSpawnFromPool(spawnPoint.transform.position, spawnPoint.transform.rotation);

            Projectile projectileObject = projectile.GetComponent<Projectile>();

            projectileObject.SetTravelDirection(travelDirection);

            projectileObject.SetMoveSpeed(speed);

            projectileObject.SetExtraMoveSpeed(extraSpeed);

            yield return new WaitForSeconds(1 / projectilesPerSecond);
        }
    }

    //Fires one projectile from multiple spawn points simultaneously.
    //'numberOfWaves' is a float parameter instead of an int, so that it can be set to Mathf.Infinity. 
    private IEnumerator FireProjectileWave (float numberOfWaves, GameObject[] spawnPoints, float wavesPerSecond,  float speed, Vector3 travelDirection, float extraSpeed)
    {
        for (int i = 0; i < numberOfWaves; i++)
        {
            if (GameManager.Singleton.GameState != GameState.GameOver) break;

            foreach (GameObject spawnPoint in spawnPoints)
            {
                GameObject projectile = objSpawner.RemoveAndSpawnFromPool(spawnPoint.transform.position, spawnPoint.transform.rotation);

                Projectile projectileObject = projectile.GetComponent<Projectile>();

                projectileObject.SetTravelDirection(travelDirection);

                projectileObject.SetMoveSpeed(speed);

                projectileObject.SetExtraMoveSpeed(extraSpeed);
            }

            yield return new WaitForSeconds(1 / wavesPerSecond);
        }
    }

    private void StartFiring() => isFiring = true;
    private void StopFiring() => isFiring = false;

    private void Update()
    {
        if (GameManager.Singleton.GameState != GameState.InProgress) return;
    }
}

/*private void RotateWeapon_SineWave ()
    {
        pivot.transform.RotateAround(pivot.transform.position, Vector3.forward, 5F * Time.deltaTime);

        pivot.transform.rotation = Quaternion.Euler(0, 0, Mathf.Sin(Time.timeSinceLevelLoad * pivotSpeed) * maximumAngle);
    }*/