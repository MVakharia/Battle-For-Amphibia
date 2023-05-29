using System.Collections;
using UnityEngine;

public class Character_Abilities : MonoBehaviour
{
    [SerializeField] Character_Switch _character_Switch;

    [Range(0, 1)]
    [SerializeField]
    private float  abilityChargeTime_PomPom_Bonus, 
        abilityChargeTime_TennisBall, abilityChargeTime_TennisBall_Bonus, abilityChargeTime_D20;

    [Range(0, 20)]
    [SerializeField] private int d20Number;

    [SerializeField] private float maxCharge;

    public float AbilityCharge_TennisBall => abilityChargeTime_TennisBall;
    public float AbilityCharge_TennisBall_Bonus => abilityChargeTime_TennisBall_Bonus;
    public float AbilityCharge_PomPom_Bonus => abilityChargeTime_PomPom_Bonus;
    public float AbilityCharge_D20 => abilityChargeTime_D20;
    public int D20Number => d20Number;

    public float AbilityCharge_PomPom => abilityChargeTime_PomPom;
  
    [SerializeField] private bool ability_IsReady_PomPom;    
    [SerializeField] private bool ability_IsUsing_PomPom;
    [SerializeField] private float abilityChargeTime_PomPom;
    [SerializeField] private float abilityChargeDuration_PomPom;
    [SerializeField] private bool ability_IsCharging_PomPom;
    [SerializeField] private bool ability_IsChanneling_PomPom;

    private bool AbilityNotYetCharged_PomPom => abilityChargeTime_PomPom < abilityChargeDuration_PomPom;
    private bool AbilityCharge_IsFull_PomPom => abilityChargeTime_PomPom >= abilityChargeDuration_PomPom;


    private void Ability_Charge_PomPom() => abilityChargeTime_PomPom += Time.deltaTime;
    private void Ability_StartCharging_PomPom() => ability_IsCharging_PomPom = true;
    private void Ability_StopCharging_PomPom() => ability_IsCharging_PomPom = false;
    private void Ability_ResetCharge_PomPom() => abilityChargeTime_PomPom = 0;

    [SerializeField] private float abilityChannelTime;
    [SerializeField] private float abilityChannelDuration;

    private void Ability_Channel_PomPom() => abilityChannelTime += Time.deltaTime;

    [SerializeField] private float abilityUseTime_PomPom;
    [SerializeField] private float abilityUseDuration_PomPom;

    private void Ability_CountUse_PomPom() => abilityUseTime_PomPom += Time.deltaTime;
    private void ReadyAbility_PomPom() => ability_IsReady_PomPom = true;
    private void UnreadyAbility_PomPom() => ability_IsReady_PomPom = false;
    private void Ability_StartUsing_PomPom () => ability_IsUsing_PomPom = true;
    private void Ability_StopUsing_PomPom() => ability_IsUsing_PomPom = false;

    private void Ability_ResetUse_PomPom() => abilityUseTime_PomPom = 0;

    private bool Ability_FinishedUsing_PomPom => abilityUseTime_PomPom > abilityUseDuration_PomPom;

    private IEnumerator RollD20(float delay)
    {
        while (true)
        {
            d20Number = Random.Range(1, 21);

            yield return new WaitForSeconds(delay);
        }
    }

    private void Ability_PomPom ()
    {
        Ability_CountUse_PomPom();
    }

    private void Start()
    {
        StartCoroutine(RollD20(1));
    }

    private void Update()
    {
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
        
        if(ControlInterface.PressedThisFrame_Keyboard1_Ability1)
        {
            if (ability_IsReady_PomPom && _character_Switch.ActiveHero == SelectedHero.Sasha)
            {
                Ability_StartUsing_PomPom();
            }
        }
    }
}