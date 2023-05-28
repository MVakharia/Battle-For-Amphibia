using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Abilities : MonoBehaviour
{
    [Range(0, 100)]
    [SerializeField]
    private float
        abilityCharge_PomPom, abilityCharge_PomPom_Bonus, 
        abilityCharge_TennisBall, abilityCharge_TennisBall_Bonus, abilityCharge_D20;

    [Range(0, 20)]
    [SerializeField] private int d20Number;

    public float AbilityCharge_TennisBall => abilityCharge_TennisBall;
    public float AbilityCharge_TennisBall_Bonus => abilityCharge_TennisBall_Bonus;
    public float AbilityCharge_PomPom => abilityCharge_PomPom;
    public float AbilityCharge_PomPom_Bonus => abilityCharge_PomPom_Bonus;
    public float AbilityCharge_D20 => abilityCharge_D20;

    public int D20Number => d20Number;

    [SerializeField]
    private bool abilityIsReady_PomPom;

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

    }
}