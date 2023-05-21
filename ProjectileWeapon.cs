using System.Collections;
using UnityEngine;

public class ProjectileWeapon : MonoBehaviour
{
    [SerializeField]
    private ObjectSpawner objSpawner;

    [SerializeField]
    private GameObject[] spawnPointArray;

    [SerializeField]
    private GameObject pivot;

    [SerializeField]
    private float pivotSpeed;

    [SerializeField]
    private float maximumAngle;

    [SerializeField]
    private bool isFiring;

    [SerializeField]
    private int setNumber;

    public int SetNumber => setNumber;

    [SerializeField]
    private float fireRate;

    [SerializeField]
    private float projectileSpeed;

    //Fire one projectile from one spawn point. 
    private IEnumerator FireProjectile (int numberOfProjectiles, GameObject spawnPoint, float delay)
    {
        for(int i = 0; i < numberOfProjectiles; i++)
        {
            objSpawner.RemoveAndSpawnFromPool(spawnPoint.transform.position, spawnPoint.transform.rotation);

            yield return new WaitForSeconds(delay);
        }
    }

    //Fire a projectile from multiple spawn points. 'numberOfWaves' is a float parameter instead of an int, so that it can be set to Mathf.Infinity. 
    private IEnumerator FireWaves (float numberOfWaves, GameObject[] spawnPoints, float wavesPerSecond,  float speed, Vector3 travelDirection, float extraSpeed)
    {
        for (int i = 0; i < numberOfWaves; i++)
        {
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

    private void RotateWeapon_SineWave ()
    {
        pivot.transform.RotateAround(pivot.transform.position, Vector3.forward, 5F * Time.deltaTime);

        pivot.transform.rotation = Quaternion.Euler(0, 0, Mathf.Sin(Time.timeSinceLevelLoad * pivotSpeed) * maximumAngle);
    }

    private void FireSet ()
    {
        if (!isFiring)
        {
            StartCoroutine(FireWaves(30, spawnPointArray, fireRate, projectileSpeed, Vector3.zero, 0));

            setNumber++;

            StartFiring();
        }
    }

    private void FireFirstSet ()
    {
        if(!isFiring && setNumber == 0)
        {
            StartCoroutine(FireWaves(10, spawnPointArray, 1.5F, 2, Vector3.zero, 0));

            StartFiring();

            setNumber++;
        }
    }

    private void FireSecondSet ()
    {
        if(!isFiring && setNumber == 1)
        {
            print("fire second set");

            StartFiring();

            setNumber++;
        }
    }

    private void StartFiring() => isFiring = true;

    private void StopFiring() => isFiring = false;

    private void Update()
    {
        if (GameManager.Singleton.GameState != GameState.InProgress) return;

        if (isFiring && Projectile.NumberOfActiveProjectiles <= 0)
        {
            StopFiring();
        }

        FireSet();

        //FireFirstSet();

        //FireSecondSet();
    }
}