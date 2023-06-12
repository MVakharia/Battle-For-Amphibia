using System.Collections;
using UnityEngine;

public class Character_Abilities_Sasha : MonoBehaviour
{
    [SerializeField] private float maxCharge;

    [SerializeField] private Ability ability_PomPom;
    [SerializeField] private Ability ability_PowerPom;
    
    [SerializeField] private SpriteRenderer spRenderer_PowerPom;
    public Ability Ability_PomPom => ability_PomPom;
    public Ability Ability_PowerPom => ability_PowerPom;

    private float ability_PomPom_chargeTimeMultiplier = 1;

    private void Update()
    {
        ability_PomPom.Run(ability_PomPom_chargeTimeMultiplier);

        ability_PowerPom.Run(0);


        if (ControlInterface.PressedThisFrame_Keyboard1_Ability1 && ability_PomPom.isReady)
        {
            ability_PomPom.Use_Start();
        }

        if (ControlInterface.PressedThisFrame_Keyboard1_Ability2)
        {
            if(ability_PowerPom.isReady)
            {
                ability_PowerPom.Use_Start();
            }
        }

        spRenderer_PowerPom.enabled = ability_PowerPom.isUsing;
    }
}