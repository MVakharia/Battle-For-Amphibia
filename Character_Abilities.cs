using System.Collections;
using UnityEngine;

public class Character_Abilities : MonoBehaviour
{
    [SerializeField] Character_Switch _character_Switch;

    [Range(0, 20)]
    [SerializeField] private int d20Number;

    [SerializeField] private float maxCharge;
    
    public int D20Number => d20Number;

    [SerializeField] private Ability ability_PomPom;
    [SerializeField] private Ability ability_PowerPom;
    [SerializeField] private Ability ability_TennisBall;
    [SerializeField] private Ability ability_Domino;
    [SerializeField] private Ability ability_Arrow;
    [SerializeField] private Ability ability_D20;

    [SerializeField] private SpriteRenderer spRenderer_PowerPom;

    public Ability Ability_PomPom => ability_PomPom;
    public Ability Ability_PowerPom => ability_PowerPom;

    public Ability Ability_TennisBall => ability_TennisBall;
    public Ability Ability_Domino => ability_Domino;

    public Ability Ability_Arrow => ability_Arrow;
    public Ability Ability_D20 => ability_D20;

    private float ability_PomPom_chargeTimeMultiplier = 1;

    private IEnumerator RollD20(float delay)
    {
        while (true)
        {
            d20Number = Random.Range(1, 21);

            yield return new WaitForSeconds(delay);
        }
    }

    private void Start()
    {
        StartCoroutine(RollD20(1));
    }

    private void Update()
    {
        ability_PomPom.Run(ability_PomPom_chargeTimeMultiplier);

        ability_PowerPom.Run(0);

        if(ControlInterface.PressedThisFrame_Keyboard1_Ability1)
        {
            if (ability_PomPom.isReady && _character_Switch.ActiveHero == SelectedHero.Sasha)
            {
                ability_PomPom.Use_Start();
            }

            if(ability_TennisBall.isReady && _character_Switch.ActiveHero == SelectedHero.Anne)
            {
                ability_TennisBall.Use_Start();
            }

            if(Ability_Arrow.isReady && _character_Switch.ActiveHero == SelectedHero.Marcy)
            {
                ability_Arrow.Use_Start();
            }
        }

        if(ControlInterface.PressedThisFrame_Keyboard1_Ability2)
        {
            if(ability_PowerPom.isReady && _character_Switch.ActiveHero == SelectedHero.Sasha)
            {
                ability_PowerPom.Use_Start();
            }

            if (ability_Domino.isReady && _character_Switch.ActiveHero == SelectedHero.Anne)
            {
                ability_Domino.Use_Start();
            }

            if (ability_D20.isReady && _character_Switch.ActiveHero == SelectedHero.Marcy)
            {
                ability_D20.Use_Start();
            }
        }

        spRenderer_PowerPom.enabled = ability_PowerPom.isUsing;
    }
}















/*
 In update:

if(ControlInterface.PressedThisFrame_Keyboard1_Ability1)
        {
            if (
ability_PomPom.isReady && _character_Switch.ActiveHero == SelectedHero.Sasha)
            {
    ability_PomPom.Use_Start();

    //Ability_StartUsing_PomPom();
}
        }
 */

/*
        if(!ability_PomPom.isUsing)
        {
            if(ability_PomPom.NotYetCharged)
            {
                ability_PomPom.Charge_Start();
            }

            if(ability_PomPom.isCharging)
            {
                ability_PomPom.Charge_CountTime();
            }

            if(ability_PomPom.FullyCharged)
            {
                ability_PomPom.Charge_Stop();

                ability_PomPom.SetAsReady();
            }
        }

        if(ability_PomPom.isUsing)
        {
            ability_PomPom.Charge_ResetTime();

            ability_PomPom.UnsetAsReady();

            ability_PomPom.Use_CountTime();

            if(ability_PomPom.FinishedUsing)
            {
                ability_PomPom.Use_Stop();

                ability_PomPom.Use_ResetTime();
            }
        }
        */



/*
if(!ability_IsUsing_PomPom)
{
    if (AbilityNotYetCharged_PomPom)
    {
        Ability_StartCharging_PomPom();
    }

    if (ability_IsCharging_PomPom)
    {
        Ability_Charge_PomPom();
    }

    if (AbilityCharge_IsFull_PomPom)
    {
        Ability_StopCharging_PomPom();

        ReadyAbility_PomPom();
    }
}

if(ability_IsUsing_PomPom)
{
    Ability_ResetCharge_PomPom();

    UnreadyAbility_PomPom();

    Ability_PomPom();

    if(Ability_FinishedUsing_PomPom)
    {
        Ability_StopUsing_PomPom();

        Ability_ResetUse_PomPom();
    }
}

 */