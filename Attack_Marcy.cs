using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_Marcy : Attack_Character
{

    [SerializeField] Character_Abilities_Marcy _character_Abilities;

    private void Ability_Arrow_Result()
    {

    }

    private void Ability_D20_Result()
    {

    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Projectile"))
        {
            Projectile p = other.GetComponent<Projectile>();

            if (_character_Abilities.Ability_Arrow.isUsing && gameObject.name == "Marcy Arrow")
            {
                objPooler.ReAddToPool(other.gameObject);

                Ability_Arrow_Result();
            }

            if (_character_Abilities.Ability_D20.isUsing && gameObject.name == "Marcy Arrow")
            {
                objPooler.ReAddToPool(other.gameObject);

                Ability_D20_Result();
            }
        }
    }
}
