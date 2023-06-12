using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MovementProfile
{
    None, Constant, P3_2_1, P3_3_1
}

public class Projectile : MonoBehaviour
{
    /// <summary>
    /// The number of projectiles currently in play and moving within the scene.
    /// </summary>
    public static int NumberOfActiveProjectiles { get; private set; }

    public static void IncrementActiveProjectiles() => NumberOfActiveProjectiles++;
    public static void DecrementActiveProjectiles() => NumberOfActiveProjectiles--;

    [SerializeField] private float moveSpeed;

    public int Damage => damage;

    [SerializeField] private int damage;
    [SerializeField] private bool isMoving;
    [SerializeField] private MovementProfile moveProfile;

    private void Move() => transform.Translate(moveSpeed * Time.deltaTime * -Vector3.up);

    public void SetMovementProfile (MovementProfile profile)
    {
        moveProfile = profile;
    }

    public void StartMoving ()
    {
        isMoving = true;
    }

    public void StopMoving ()
    {
        isMoving = false;
    }

    void Update()
    {
        if(moveProfile == MovementProfile.Constant)
        {
            //move according to the 'Constant' profile. 

            moveSpeed = 2;
        }
        else if (moveProfile == MovementProfile.P3_2_1)
        {
            //move according to this profile, which starts the projectile at a speed of 3,
            //then ramps it down by 1 per second for 2 seconds, to a movement speed of 1. 
        }
        else if (moveProfile == MovementProfile.P3_3_1)
        {
            //move according to this profile. 
        }

        if(isMoving)
        {
            Move();
        }
    }
}