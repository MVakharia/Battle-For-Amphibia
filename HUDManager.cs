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
public class HUD_Element_Ability : HUD_Element_Sliding
{
    public TMP_Text TMP_Text;
    public RawImage rawImg;

    public void SetCooldownText(CooldownDisplayType type, Ability ability)
    {
        if (ability.isCharging)
        {
            if (type == CooldownDisplayType.Timer)
            {
                TMP_Text.text = (1 - ability.chargeTime).ToString("0");
            }
            else if (type == CooldownDisplayType.Percentage)
            {
                TMP_Text.text = (100 * ability.chargeTime).ToString("0");
            }
        }
        else
        {
            TMP_Text.text = "";
        }
    }

    public void ToggleIconVisibility (bool enableCheck)
    {
        rawImg.enabled = enableCheck;
    }
}

[System.Serializable]
public class HUD_Element_Sliding
{
    public Slider slider;
    
    public void SetSliderValue(float targetValue, float sliderSpeed, bool enableCheck)
    {
        if (enableCheck)
        {
            slider.value = Mathf.MoveTowards(slider.value, targetValue, Time.deltaTime * sliderSpeed);
        }
        else
        {
            slider.value = targetValue;
        }
    }
}

public class HUDManager : MonoBehaviour
{
    [SerializeField] Character _character;
    [SerializeField] Character_Abilities _character_Abilities;
    [SerializeField] private TMP_Text textMesh_D20Number, textMesh_GameOver, textMesh_Score, textMesh_WaveNumber;


    [SerializeField] private HUD_Element_Sliding hudElement_health;

    [SerializeField]
    private HUD_Element_Ability hudElement_PomPom, hudElement_PowerPom, hudElement_TennisBall, hudElement_Domino, hudElement_Arrow, hudElement_D20;

    

    

    private void SetText_D20() => 
        textMesh_D20Number.text = _character_Abilities.D20Number.ToString();

    private void SetSliderValue_Health() =>
        hudElement_health.SetSliderValue(_character.HealthPercentage, 1, true);


    private void SetSliderValue_Ability_PomPom() => hudElement_PomPom.SetSliderValue(
            _character_Abilities.Ability_PomPom.chargeTime, 1, _character_Abilities.Ability_PomPom.isCharging);

    private void SetIconState_Ability_PomPom () => hudElement_PomPom.ToggleIconVisibility(!_character_Abilities.Ability_PomPom.isCharging);
    private void SetTimerText_Ability_PomPom () => hudElement_PomPom.SetCooldownText(CooldownDisplayType.Timer,
            _character_Abilities.Ability_PomPom);


    private void SetIconState_Ability_PowerPom() => hudElement_PowerPom.ToggleIconVisibility(!_character_Abilities.Ability_PowerPom.isCharging);

    private void SetSliderValue_Ability_PowerPom() =>
        hudElement_PowerPom.SetSliderValue(
            _character_Abilities.Ability_PowerPom.chargeTime, 1, _character_Abilities.Ability_PowerPom.isCharging);

    private void SetPercentageText_Ability_PowerPom() =>
        hudElement_PowerPom.SetCooldownText(CooldownDisplayType.Percentage,
            _character_Abilities.Ability_PowerPom);



    private void SetSliderValue_Ability_TennisBall () =>
        hudElement_TennisBall.SetSliderValue(
            _character_Abilities.Ability_TennisBall.chargeTime, 1, _character_Abilities.Ability_TennisBall.isCharging);

    private void SetIconState_Ability_TennisBall () => 
        hudElement_TennisBall.rawImg.enabled = !_character_Abilities.Ability_TennisBall.isCharging;

    private void SetTimerText_Ability_TennisBall() =>
        hudElement_TennisBall.SetCooldownText(CooldownDisplayType.Timer, 
            _character_Abilities.Ability_TennisBall);




    private void SetSliderValue_Ability_Domino () =>
        hudElement_Domino.SetSliderValue(
            _character_Abilities.Ability_Domino.chargeTime, 1, _character_Abilities.Ability_Domino.isCharging);

    private void SetIconState_Ability_Domino() => hudElement_Domino.ToggleIconVisibility(!_character_Abilities.Ability_Domino.isCharging);

    private void SetPercentageText_Ability_Domino() => hudElement_Domino.SetCooldownText(CooldownDisplayType.Percentage,
        _character_Abilities.Ability_Domino);



    private void SetSliderValue_Ability_Arrow() =>
        hudElement_Arrow.SetSliderValue(_character_Abilities.Ability_Arrow.chargeTime, 1, _character_Abilities.Ability_Arrow.isCharging);

    private void SetIconState_Ability_Arrow() => hudElement_Arrow.ToggleIconVisibility(!_character_Abilities.Ability_Arrow.isCharging);

    private void SetTimerText_Ability_Arrow() => hudElement_Arrow.SetCooldownText(CooldownDisplayType.Timer, _character_Abilities.Ability_Arrow);



    private void SetSliderValue_Ability_D20 () =>
        hudElement_D20.SetSliderValue(_character_Abilities.Ability_D20.chargeTime, 1, _character_Abilities.Ability_D20.isCharging);

    private void SetIconState_Ability_D20() => hudElement_D20.ToggleIconVisibility(!_character_Abilities.Ability_D20.isCharging);

    private void SetTimerText_Ability_D20() => hudElement_D20.SetCooldownText(CooldownDisplayType.Timer, _character_Abilities.Ability_D20);



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

        SetIconState_Ability_TennisBall();

        SetTimerText_Ability_TennisBall();



        SetSliderValue_Ability_Domino();

        SetIconState_Ability_Domino();

        SetPercentageText_Ability_Domino();


        SetSliderValue_Ability_Arrow();

        SetIconState_Ability_Arrow();

        SetTimerText_Ability_Arrow();


        SetSliderValue_Ability_D20();

        SetIconState_Ability_D20();

        SetTimerText_Ability_D20();

        textMesh_Score.text = GameManager.Singleton.Score.ToString();
    }
}
