using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public enum SelectedHero
{
    None, Sasha, Anne, Marcy
}

public enum CharacterState
{
    Alive, Dead
}

public class Character : MonoBehaviour
{
    [SerializeField]
    private int health;

    [SerializeField]
    private int maxHealth;

    public int Health => health;

    public int MaxHealth => maxHealth;

    public float HealthPercentage => Health / (float)MaxHealth;

    [SerializeField]
    private GameObject Sasha, Anne, Marcy;

    [SerializeField]
    private float anneCharge, anneBonusCharge, sashaPomPomCharge, sashaMegaPomCharge, marcyCharge;

    [SerializeField]
    private int d20Number;

    public int D20Number => d20Number;

    [SerializeField]
    private ObjectSpawner _objectSpawner;

    [SerializeField]
    private Character_Rendering characterRendering;

    [SerializeField]
    private Character_Switch characterSwitch;

    [SerializeField]
    private Rigidbody2D _rigidbody;

    [SerializeField]
    private AnimationManager_Character aniManager_Character;

    [SerializeField]
    private CircleCollider2D thisCollider;

    [SerializeField]
    private CharacterState currentState;

    public CharacterState CurrentState => currentState;

    private Vector3 StartingPosition => new(-2.79F, -3, 5);

    [SerializeField]
    private AudioSource _audioSource;

    [SerializeField]
    private AudioClip takeDamage;

    [SerializeField]
    private float hurtInvulnTime;

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

        _audioSource.PlayOneShot(takeDamage);

        thisCollider.enabled = false;

        if (health <= 0)
        {
            yield break;
        }

        aniManager_Character.PlayAnimation_Hurt();

        yield return new WaitForSeconds(hurtInvulnTime);

        aniManager_Character.PlayAnimation_Idle();

        thisCollider.enabled = true;
    }

    private void ChangeCharacterPropertiesOnDeath ()
    {
        characterRendering.SetPropertiesOnDeath();

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
        if(other.gameObject.tag == "Projectile")
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