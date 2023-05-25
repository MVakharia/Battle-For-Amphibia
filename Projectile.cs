using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction
{
    None, Left, Right
}

public class Projectile : MonoBehaviour
{
    /// <summary>
    /// The number of projectiles currently in play and moving within the scene. 
    /// </summary>
    public static int NumberOfActiveProjectiles { get; private set; }

    public static void IncrementActiveProjectiles ()
    {
        NumberOfActiveProjectiles++;
    }

    public static void DecrementActiveProjectiles ()
    {
        NumberOfActiveProjectiles--;
    }

    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private float extraMoveSpeed;

    private Vector3 travelDirection;

    public int Damage => damage;

    [SerializeField]
    private int damage;

    public void SetMoveSpeed (float speed)
    {
        moveSpeed = speed;
    }

    public void SetTravelDirection (Vector3 dir)
    {
        travelDirection = dir;
    }

    public void SetExtraMoveSpeed (float speed)
    {
        extraMoveSpeed = speed;
    }

    private void MoveNormal()
    {
        transform.Translate(moveSpeed * Time.deltaTime * -Vector3.up);
    }

    private void ExtraMovement ()
    {
        transform.Translate(extraMoveSpeed * Time.deltaTime * travelDirection);
    }

    void Update()
    {
        MoveNormal();

        ExtraMovement();
    }
}
