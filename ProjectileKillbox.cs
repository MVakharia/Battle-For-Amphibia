using UnityEngine;

public class ProjectileKillbox : MonoBehaviour
{
    [SerializeField]
    private ProjectileKillboxHolder parent;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Projectile"))
        {
            parent._ObjectSpawner.ReAddToPool(other.gameObject);

            if(GameManager.Singleton.GameState == GameState.GameOver) return;

            GameManager.Singleton.ChangeScore(10);
        }
    }
}