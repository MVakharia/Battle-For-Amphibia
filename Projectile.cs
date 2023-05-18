using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction
{
    None, Left, Right
}

public class Projectile : MonoBehaviour
{
    private static int numberOfActiveProjectiles;

    public static int NumberOfActiveProjectiles => numberOfActiveProjectiles;

    public static void IncrementActiveProjectiles ()
    {
        numberOfActiveProjectiles++;
    }

    public static void DecrementActiveProjectiles ()
    {
        numberOfActiveProjectiles--;
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
