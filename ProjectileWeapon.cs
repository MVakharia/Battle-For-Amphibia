using UnityEngine;

public class ProjectileWeapon : MonoBehaviour
{
    [SerializeField] private ObjectPooler objPooler;
    [SerializeField] private float projectilesPerSecond;
    [SerializeField] GameObject target;
    [SerializeField] GameObject[] weaponObject;


    private float CooldownTimeMax => 1 / projectilesPerSecond;

    private void StartPerformingAction() => isPerformingAction = true;
    private void StopPerformingAction() => isPerformingAction = false;

    private void StartCoolingDown() => isCoolingDown = true;
    private void StopCoolingDown() => isCoolingDown = false;

    private void CountCooldown () => cooldownTimeCurrent -= Time.deltaTime;
    private void ResetCooldownTimer() => cooldownTimeCurrent = CooldownTimeMax;

    private float FiringAngle ()
    {
        return 0;
    }

    private float Angle_LookAtPlayer ()
    {
        Vector3 direction = target.transform.position - transform.position;

        float angle = Vector3.Angle(direction, -transform.up);

        if (target.transform.position.x < transform.position.x)
        {
            angle = -angle;
        }

        return angle;
    }

    private void FireProjectile(Transform weaponTransform, MovementProfile profile)
    {
        Projectile p = objPooler.RemoveAndSpawnFromPool(weaponTransform.position, Quaternion.Euler(0, 0, FiringAngle())).GetComponent<Projectile>();

        //Once the projectile is spawned, the projectile's movement profile is set. This is done by setting an enum in the projectile class. 
        //The projectile then moves according to this profile.

        p.SetMovementProfile(profile);
    }

    /// <summary>
    /// Fires a single projectile at a constant speed. 
    /// The speed is set in the 'Projectile' class, and is the same for all projectiles fired with the 'Constant' movement profile. 
    /// </summary>
    private void FirePattern0 ()
    {
        FireProjectile(weaponObject[0].transform, MovementProfile.Constant);
    }

    private void FirePattern1 ()
    {
        FireProjectile(weaponObject[0].transform, MovementProfile.Constant);

        //After a short delay, fire a second projectile in the same direction. 
    }

    private void Awake()
    {
        GameObject gm = GameObject.FindGameObjectWithTag("Game Manager");

        objPooler = gm.GetComponent<ObjectPooler>();
        target = GameObject.FindGameObjectWithTag("Character");
    }

    private void Start()
    {
        readyToPerformAction = true;

        cooldownTimeCurrent = CooldownTimeMax;
    }

    private void Update()
    {
        if (GameManager.Singleton.GameState != GameState.InProgress) return;



        ActionOnCooldown();
    }

    [SerializeField] private bool readyToPerformAction;
    [SerializeField] private bool isCoolingDown;
    [SerializeField] private float cooldownTimeCurrent;
    [SerializeField] private bool isPerformingAction;

    private void ActionOnCooldown()
    {
        if (readyToPerformAction)
        {
            StartPerformingAction();
        }

        if (isCoolingDown)
        {
            CountCooldown();
        }

        if (cooldownTimeCurrent <= 0)
        {
            StopCoolingDown();

            ResetCooldownTimer();
        }

        if (isPerformingAction && !isCoolingDown)
        {
            PerformAction();

            StartCoolingDown();
        }
    }


    private void PerformAction() { }
}