using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Abilities_Anne : MonoBehaviour
{
    [SerializeField] private Ability ability_TennisBall;
    [SerializeField] private Ability ability_Domino;

    public Ability Ability_TennisBall => ability_TennisBall;
    public Ability Ability_Domino => ability_Domino;

    private float ability_TennisBall_chargeTimeMultiplier = 1;

    private void Update()
    {
        Ability_TennisBall.Run(ability_TennisBall_chargeTimeMultiplier);

        ability_Domino.Run(0);

        if (ControlInterface.PressedThisFrame_Keyboard1_Ability1 && ability_TennisBall.isReady)
        {
            ability_TennisBall.Use_Start();
        }

        if (ControlInterface.PressedThisFrame_Keyboard1_Ability2)
        {
            if (ability_Domino.isReady)
            {
                ability_Domino.Use_Start();
            }
        }
    }


}
