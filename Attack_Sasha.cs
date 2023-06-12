using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_Sasha : Attack_Character
{
    [SerializeField] Character_Abilities_Sasha _character_Abilities;

    private void Ability_PomPom_Result ()
    {
        _character_Abilities.Ability_PowerPom.Charge_Modify(0.1F);

        gameManager.AwardPoints(20);
    }

    private void Ability_PowerPom_Result ()
    {
        gameManager.AwardPoints(50);
    }

    private void OnTriggerStay2D(Collider2D other)
    {            
        if(other.gameObject.CompareTag("Projectile"))
        {
            Projectile p = other.GetComponent<Projectile>();

            if (_character_Abilities.Ability_PomPom.isUsing && gameObject.name == "Sasha Aura")
            {
                objPooler.ReAddToPool(other.gameObject);

                Ability_PomPom_Result();
            }

            if (_character_Abilities.Ability_PowerPom.isUsing && (gameObject.name == "Sasha Power Pom" || gameObject.name == "Sasha Aura"))
            {
                objPooler.ReAddToPool(other.gameObject);

                Ability_PowerPom_Result();
            }
        }
    }
}