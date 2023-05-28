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

    public static void IncrementActiveProjectiles() => NumberOfActiveProjectiles++;
    public static void DecrementActiveProjectiles() => NumberOfActiveProjectiles--;

    [SerializeField] private float moveSpeed;

    public int Damage => damage;

    [SerializeField] private int damage;

    private void Move() => transform.Translate(moveSpeed * Time.deltaTime * -Vector3.up);

    private void Start()
    {
        
    }

    void Update()
    {
        Move();
    }
}