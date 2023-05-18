using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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

    // Update is called once per frame
    void Update()
    {
        d20NumberText.text = _character.D20Number.ToString();
    }
}
