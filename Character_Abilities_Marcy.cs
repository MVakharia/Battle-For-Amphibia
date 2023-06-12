using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Abilities_Marcy : MonoBehaviour
{
    [Range(0, 20)]
    [SerializeField] private int d20Number;

    [SerializeField] private Ability ability_Arrow;
    [SerializeField] private Ability ability_D20;

    public int D20Number => d20Number;

    public Ability Ability_Arrow => ability_Arrow;
    public Ability Ability_D20 => ability_D20;

    private float ability_Arrow_chargeTimeMultiplier = 1;

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
        ability_Arrow.Run(ability_Arrow_chargeTimeMultiplier);

        ability_D20.Run(0);

        if (ControlInterface.PressedThisFrame_Keyboard1_Ability1 && Ability_Arrow.isReady)
        {
            ability_Arrow.Use_Start();
        }

        if (ControlInterface.PressedThisFrame_Keyboard1_Ability2)
        {
            if (ability_D20.isReady)
            {
                ability_D20.Use_Start();
            }
        }
    }
}
