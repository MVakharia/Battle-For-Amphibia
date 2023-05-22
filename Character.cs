using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public enum SelectedHero { None, Sasha, Anne, Marcy }

public enum CharacterState { Alive, Dead }

public class Character : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private int maxHealth;
    [SerializeField] private float anneCharge, anneBonusCharge, sashaPomPomCharge, sashaMegaPomCharge, marcyCharge;
    [SerializeField] private int d20Number;
    [SerializeField] private float hurtInvulnTime;

    [SerializeField] private GameObject sasha, anne, marcy;
    [SerializeField] private ObjectSpawner _objectSpawner;
    [SerializeField] private Character_Rendering _character_Rendering;
    [SerializeField] private Character_Switch _character_Switch;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private AnimationManager_Character aniManager_Character;
    [SerializeField] private CircleCollider2D _collider;
    [SerializeField] private CharacterState currentState;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip audio_TakeDamage;
    
    public int Health => health;
    public int MaxHealth => maxHealth;
    public float HealthPercentage => Health / (float)MaxHealth;
    public int D20Number => d20Number;
    public CharacterState CurrentState => currentState;
    private Vector3 StartingPosition => new(-2.79F, -3, 5);
    
    private IEnumerator RollD20 (float delay)
    {
        while(true)
        {
            d20Number = Random.Range(1, 21);

            yield return new WaitForSeconds(delay);
        }
    }


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

    private void Start()
    {
        StartCoroutine(RollD20(1));
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