using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileKillbox : MonoBehaviour
{
    [SerializeField]
    private ProjectileKillboxHolder parent;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Projectile")
        {
            parent._ObjectSpawner.ReAddToPool(other.gameObject);

            GameManager.Singleton.ChangeScore(10);
        }
    }
}