using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    [SerializeField] Character _character;
    [SerializeField] Character_Abilities _character_Abilities;
    [SerializeField] private TMP_Text textMesh_D20Number, textMesh_GameOver, textMesh_Score, textMesh_WaveNumber;
    [SerializeField] private Slider slider_Health, 
        slider_AbilityCharge_PomPom, slider_AbilityCharge_PomPom_Bonus, 
        slider_AbilityCharge_TennisBall, slider_AbilityCharge_TennisBall_Bonus, slider_AbilityCharge_D20;

    private float SliderValue (float sliderValue, float targetValue, float sliderSpeed)
    {
        return Mathf.MoveTowards(sliderValue, targetValue, Time.deltaTime * sliderSpeed);
    }

    private void SetText_D20() => textMesh_D20Number.text = _character_Abilities.D20Number.ToString();

    //private void SetText_Health() => slider_Health.value = Mathf.MoveTowards(slider_Health.value, _character.HealthPercentage, Time.deltaTime);

    void Update()
    {
        SetText_D20();

        slider_Health.value = SliderValue(slider_Health.value, _character.HealthPercentage, 1);

        slider_AbilityCharge_PomPom.value = SliderValue(slider_AbilityCharge_PomPom.value, _character_Abilities.AbilityCharge_PomPom, 2);

        slider_AbilityCharge_PomPom_Bonus.value = SliderValue(slider_AbilityCharge_PomPom_Bonus.value, _character_Abilities.AbilityCharge_PomPom_Bonus, 1);

        slider_AbilityCharge_TennisBall.value = SliderValue(slider_AbilityCharge_TennisBall.value, _character_Abilities.AbilityCharge_TennisBall, 1);

        slider_AbilityCharge_TennisBall_Bonus.value = SliderValue(slider_AbilityCharge_TennisBall_Bonus.value, _character_Abilities.AbilityCharge_TennisBall_Bonus, 1);

        slider_AbilityCharge_D20.value = SliderValue(slider_AbilityCharge_D20.value, _character_Abilities.AbilityCharge_D20, 1);

        textMesh_Score.text = GameManager.Singleton.Score.ToString();
    }
}
