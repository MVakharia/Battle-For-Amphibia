using System.Collections;
using UnityEngine;

public class ProjectileWeapon : MonoBehaviour
{
    [SerializeField] private ObjectPooler objPooler;
    [SerializeField] private bool isFiring;
    [SerializeField] private float projectilesPerSecond;
    [SerializeField] private bool readyToFire;
    [SerializeField] private float projectileRotation;
    [SerializeField] private bool isCoolingDown;    
    [SerializeField] private float cooldownTimeCurrent;

    [SerializeField] GameObject character;

    private float CooldownTimeMax => 1 / projectilesPerSecond;

    private void FireProjectile() => objPooler.RemoveAndSpawnFromPool(transform.position, Quaternion.Euler(0, 0, projectileRotation));

    private void StartFiring() => isFiring = true;
    private void StopFiring() => isFiring = false;

    private void StartCoolingDown() => isCoolingDown = true;
    private void StopCoolingDown() => isCoolingDown = false;

    private void CountCooldown () => cooldownTimeCurrent -= Time.deltaTime;
    private void ResetCooldownTimer() => cooldownTimeCurrent = CooldownTimeMax;

    private void Awake()
    {
        objPooler = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<ObjectPooler>();

        character = GameObject.FindGameObjectWithTag("Character");
    }

    private void Start()
    {
        //readyToFire = true;

        cooldownTimeCurrent = CooldownTimeMax;
    }

    private void Update()
    {
        if (GameManager.Singleton.GameState != GameState.InProgress) return;

        if(readyToFire)
        {
            StartFiring();
        }

        if(isCoolingDown)
        {
            CountCooldown();
        }

        if(cooldownTimeCurrent <= 0)
        {
            StopCoolingDown();

            ResetCooldownTimer();
        }

        if (isFiring && !isCoolingDown)
        {
            StartCoolingDown();

            FireProjectile();
        }

        Vector3 direction = character.transform.position - transform.position;

        float angle = Vector3.Angle(direction, -transform.up);

        if(character.transform.position.x < transform.position.x)
        {
            angle = -angle;
        }

        projectileRotation = angle;
    }
}