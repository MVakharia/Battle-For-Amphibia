using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public enum SelectedHero { None, Sasha, Anne, Marcy }

public enum CharacterState { Alive, Dead }

public class Character : MonoBehaviour
{
    [SerializeField] private SelectedHero thisHero;

    [Range(0, 100)]
    [SerializeField] private int health;
    [SerializeField] private int maxHealth;
    [Range(0, 2)]
    [SerializeField] private float hurtInvulnTime;
    [SerializeField] private ObjectPooler _objectSpawner;
    [SerializeField] private Character_Rendering _character_Rendering;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private AnimationManager_Character aniManager_Character;
    [SerializeField] private CircleCollider2D _collider;
    [SerializeField] private CharacterState currentState;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip audio_TakeDamage;

    public SelectedHero ThisHero => thisHero;

    public int Health => health;
    public int MaxHealth => maxHealth;
    public float HealthPercentage => Health / (float)MaxHealth;
    
    public CharacterState CurrentState => currentState;
    private Vector3 StartingPosition => new(-2.79F, -3, 5);

    private IEnumerator Routine_TakeDamage (int damage)
    {
        health -= damage;

        _audioSource.PlayOneShot(audio_TakeDamage);

        _collider.enabled = false;

        if (health <= 0)
        {
            yield break;
        }

        aniManager_Character.PlayAnimation_Hurt();

        yield return new WaitForSeconds(hurtInvulnTime);

        aniManager_Character.PlayAnimation_Idle();

        _collider.enabled = true;
    }

    private void ChangeCharacterPropertiesOnDeath ()
    {
        _character_Rendering.SetPropertiesOnDeath();
        _rigidbody.gravityScale = 0.5F;
        _rigidbody.constraints = RigidbodyConstraints2D.None;
    
    }

    private void Die ()
    {
        ChangeCharacterPropertiesOnDeath();
        GameManager.Singleton.TriggerGameOver();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {        
        if(other.gameObject.CompareTag("Projectile"))
        {
            Projectile p = other.GetComponent<Projectile>();

            _objectSpawner.ReAddToPool(other.gameObject);

            StartCoroutine(Routine_TakeDamage(p.Damage));
        }
    }

    private void Update()
    {
        if(health <= 0 && currentState == CharacterState.Alive)
        {
            currentState = CharacterState.Dead;

            Die();
        }
    }
}