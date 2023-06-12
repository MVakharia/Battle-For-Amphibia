using UnityEngine;

public enum FiringState
{
    Standby, Pattern, Cooldown
}

public class ProjectileWeapon : MonoBehaviour
{
    [SerializeField] private ObjectPooler objPooler;
    [SerializeField] GameObject target;
    [SerializeField] GameObject[] weaponObject;
    [SerializeField] private int patternNumber;
    [SerializeField] private bool canFirePattern;
    [SerializeField] private float patternDelayTimer;
    [SerializeField] private bool isCountingPatternDelay;

    private void StartPatternDelay(float time)
    {
        isCountingPatternDelay = true;

        patternDelayTimer = time;
    }

    private void StopPatternDelay() => isCountingPatternDelay = false;

    [SerializeField] private int patternPart;



    private float FiringAngle()
    {
        return 0;
    }

    private float Angle_LookAtPlayer(Vector3 position)
    {
        Vector3 direction = target.transform.position - position;

        float angle = Vector3.Angle(direction, -Vector3.up);

        if (target.transform.position.x < transform.position.x)
        {
            angle = -angle;
        }

        return angle;
    }

    /// <summary>
    /// Fires one projectile from a desired location, at the desired angle, sets its movement profile, and starts its movement.
    /// </summary>
    /// <param name="firingLocation"></param>
    /// <param name="profile"></param>
    /// <param name="firingAngle"></param>
    private void FireProjectile(Vector3 firingLocation, MovementProfile profile, float firingAngle)
    {
        Projectile p = objPooler.RemoveAndSpawnFromPool(firingLocation, Quaternion.Euler(0, 0, firingAngle)).GetComponent<Projectile>();

        p.SetMovementProfile(profile);

        p.StartMoving();
    }

    /// <summary>
    /// Fires a wave of projectiles from a desired location, launching the first one at an angle and then spacing them out by 'step'.
    /// </summary>
    private void FireProjectiles(Vector3 firingLocation, MovementProfile profile, float startingAngle, int numberOfProjectiles, float step)
    {
        for (int i = 0; i < numberOfProjectiles; i++)
        {
            Projectile p = objPooler.RemoveAndSpawnFromPool(firingLocation, Quaternion.Euler(0, 0, startingAngle + (i * step))).GetComponent<Projectile>();

            p.SetMovementProfile(profile);

            p.StartMoving();
        }
    }

    private void FirePattern()
    {
        patternNumber++;

        if (patternNumber == 1)
        {
            FireProjectiles(weaponObject[0].transform.position, MovementProfile.Constant, 0, 1, 0);

            StartPatternDelay(.75F);
        }
        if(patternNumber == 2)
        {
            FireProjectiles(weaponObject[0].transform.position, MovementProfile.Constant, -45, 2, 90);

            StartPatternDelay(.8F);
        }

        if(patternNumber == 3)
        {
            FireProjectiles(weaponObject[0].transform.position, MovementProfile.Constant, -80, 5, 40);

            StartPatternDelay(0.9F);
        }

        if(patternNumber == 4)
        {
            FireProjectiles(weaponObject[0].transform.position, MovementProfile.Constant, -75, 7, 25);

            StartPatternDelay(1);
        }

        if(patternNumber == 5)
        {
            FireProjectiles(weaponObject[0].transform.position, MovementProfile.Constant, -90, 19, 10);

            StartPatternDelay(0.5F);
        }

        if(patternNumber == 6)
        {
            FireProjectiles(weaponObject[0].transform.position + new Vector3(-4F, 0), MovementProfile.Constant, 0, 19, 10);

            StartPatternDelay(0.5F);
        }

        if(patternNumber == 7)
        {
            FireProjectiles(weaponObject[0].transform.position + new Vector3(4F, 0), MovementProfile.Constant, 180, 19, 10);

            StartPatternDelay(0.5F);
        }

        if(patternNumber >= 8)
        {
            int step = Random.Range(5, 16);

            int numberOfProjectiles = Random.Range(10, 26);

            float delay = Random.Range(0.5F, 1);

            float xPos = Random.Range(-5, 5F);

            Vector3 newPos = weaponObject[0].transform.position + new Vector3(xPos, 0);

            float startingAngle = (-((step * numberOfProjectiles) - step) / 2) + Angle_LookAtPlayer(newPos);

            FireProjectiles(newPos, MovementProfile.Constant, startingAngle, numberOfProjectiles, step);

            StartPatternDelay(delay);
        }
    }

    private void Awake()
    {
        GameObject gm = GameObject.FindGameObjectWithTag("Game Manager");

        objPooler = gm.GetComponent<ObjectPooler>();
        target = GameObject.FindGameObjectWithTag("Character");
    }

    private void Start()
    {
        StartPatternDelay(1);
    }


    private void Update()
    {
        if (GameManager.Singleton.GameState != GameState.InProgress) return;

        if (canFirePattern)
        {
            canFirePattern = false;

            FirePattern();
        }

        if (isCountingPatternDelay)
        {
            patternDelayTimer -= Time.deltaTime;
        }

        if (patternDelayTimer < 0)
        {
            StopPatternDelay();

            patternDelayTimer = 0;

            canFirePattern = true;
        }
    }
}