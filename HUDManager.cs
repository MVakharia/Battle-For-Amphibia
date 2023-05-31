using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public enum CooldownDisplayType
{
    Timer, Percentage
}

[System.Serializable]
public class HUD_Element_Ability 
{
    public Slider slider_Cooldown;
    public TMP_Text TMP_Text_Cooldown;
    public RawImage rawImg_Icon;
}

public class HUDManager : MonoBehaviour
{
    [SerializeField] Character _character;
    [SerializeField] Character_Abilities _character_Abilities;
    [SerializeField] private TMP_Text textMesh_D20Number, textMesh_GameOver, textMesh_Score, textMesh_WaveNumber;
    [SerializeField] private Slider slider_Health;

    [SerializeField]
    private HUD_Element_Ability hudElement_PomPom, hudElement_PowerPom, hudElement_TennisBall, hudElement_Domino, hudElement_Arrow, hudElement_D20;

    private float SliderValue(float sliderValue, float targetValue, float sliderSpeed, bool enableCheck)
    {
        if (enableCheck)
        {
            return Mathf.MoveTowards(sliderValue, targetValue, Time.deltaTime * sliderSpeed);
        }
        return targetValue;
    }

    private string CooldownText (CooldownDisplayType type, bool displayCheck, float chargeTime)
    {
        if(displayCheck)
        {
            if(type == CooldownDisplayType.Timer)
            {
                return (1 - chargeTime).ToString("0");
            }
            if(type == CooldownDisplayType.Percentage)
            {
                return (100 * chargeTime).ToString("0");
            }
        }
        return "";
    }

    private void SetText_D20() => 
        textMesh_D20Number.text = _character_Abilities.D20Number.ToString();

    private void SetSliderValue_Health() => 
        slider_Health.value = SliderValue(slider_Health.value, _character.HealthPercentage, 1, true);


    private void SetSliderValue_Ability_PomPom() => hudElement_PomPom.slider_Cooldown.value = SliderValue(hudElement_PomPom.slider_Cooldown.value,
            _character_Abilities.Ability_PomPom.chargeTime, 2, _character_Abilities.Ability_PomPom.isCharging);
    private void SetIconState_Ability_PomPom () => hudElement_PomPom.rawImg_Icon.enabled = !_character_Abilities.Ability_PomPom.isCharging;
    private void SetTimerText_Ability_PomPom () => hudElement_PomPom.TMP_Text_Cooldown.text = CooldownText(CooldownDisplayType.Timer,
            _character_Abilities.Ability_PomPom.isCharging, _character_Abilities.Ability_PomPom.chargeTime);


    private void SetIconState_Ability_PowerPom () =>    
        hudElement_PowerPom.rawImg_Icon.enabled = !_character_Abilities.Ability_PowerPom.isCharging;

    private void SetSliderValue_Ability_PowerPom() =>
        hudElement_PowerPom.slider_Cooldown.value = SliderValue(hudElement_PowerPom.slider_Cooldown.value,
            _character_Abilities.Ability_PowerPom.chargeTime, 1, _character_Abilities.Ability_PowerPom.isCharging);

    private void SetPercentageText_Ability_PowerPom() =>
        hudElement_PowerPom.TMP_Text_Cooldown.text = CooldownText(CooldownDisplayType.Percentage,
            _character_Abilities.Ability_PowerPom.isCharging, _character_Abilities.Ability_PowerPom.chargeTime);



    private void SetSliderValue_Ability_TennisBall () =>
        hudElement_TennisBall.slider_Cooldown.value = SliderValue(hudElement_TennisBall.slider_Cooldown.value,
            _character_Abilities.Ability_TennisBall.chargeTime, 1, _character_Abilities.Ability_TennisBall.isCharging);

    private void SetIconState_Ability_TennisBall () => 

    private void SetSliderValue_Ability_Domino () =>
        slider_AbilityCharge_TennisBall_Bonus.value = SliderValue(slider_AbilityCharge_TennisBall_Bonus.value,
            _character_Abilities.Ability_Domino.chargeTime, 1, _character_Abilities.Ability_Domino.isCharging);

    void Update()
    {
        //SetText_D20();

        SetSliderValue_Health();



        SetSliderValue_Ability_PomPom();

        SetIconState_Ability_PomPom();

        SetTimerText_Ability_PomPom();



        SetSliderValue_Ability_PowerPom();

        SetIconState_Ability_PowerPom();

        SetPercentageText_Ability_PowerPom();



        SetSliderValue_Ability_TennisBall();

        





        SetSliderValue_Ability_Domino();






        slider_AbilityCharge_D20.value = SliderValue(slider_AbilityCharge_D20.value, 
            _character_Abilities.Ability_D20.chargeTime, 1, _character_Abilities.Ability_D20.isCharging);
        


        textMesh_Score.text = GameManager.Singleton.Score.ToString();
    }
}
