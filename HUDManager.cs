using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    [SerializeField]
    Character _character;

    [SerializeField]
    private TMP_Text d20NumberText;

    [SerializeField]
    private TMP_Text gameOverText;

    [SerializeField]
    private Animator gameOverTextAnimator;

    [SerializeField]
    private Slider healthbar;

    [SerializeField]
    private float healthBarSliderSpeed;

    [SerializeField]
    private TMP_Text scoreText;

    [SerializeField]
    private TMP_Text waveNumberText;

    // Update is called once per frame
    void Update()
    {
        d20NumberText.text = _character.D20Number.ToString();

        healthbar.value = Mathf.MoveTowards(healthbar.value, _character.HealthPercentage, Time.deltaTime * healthBarSliderSpeed);

        waveNumberText.text = GameManager.Singleton.WaveNumber.ToString();

        scoreText.text = GameManager.Singleton.Score.ToString();
    }
}
