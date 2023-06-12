using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_Anne : Attack_Character
{
    [SerializeField] Character_Abilities_Anne _character_Abilities;

    private void Ability_TennisBall_Result()
    {
        gameManager.AwardPoints(20);
    }

    private void Ability_Domino_Result()
    {

    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Projectile"))
        {
            Projectile p = other.GetComponent<Projectile>();

            if (_character_Abilities.Ability_TennisBall.isUsing && gameObject.name == "Anne Tennis Ball")
            {
                objPooler.ReAddToPool(other.gameObject);

                Ability_TennisBall_Result();
            }

            if (_character_Abilities.Ability_Domino.isUsing && gameObject.name == "Anne Cat")
            {
                objPooler.ReAddToPool(other.gameObject);

                Ability_Domino_Result();
            }
        }
    }
}
