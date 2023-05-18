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
    private int healthBar;

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
    private CharacterState currentState;

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

    private void TakeDamage (int damage)
    {
        healthBar -= damage;
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

    public void SetInitialPosition ()
    {
        print("setting initial position");

        transform.position = StartingPosition;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {        
        if(other.gameObject.tag == "Projectile")
        {
            Projectile p = other.GetComponent<Projectile>();

            _objectSpawner.ReAddToPool(other.gameObject);

            TakeDamage(p.Damage);
        }
    }

    private void Start()
    {
        StartCoroutine(RollD20(1));
    }

    private void Update()
    {
        if(healthBar <= 0 && currentState == CharacterState.Alive)
        {
            currentState = CharacterState.Dead;

            Die();
        }
    }
}