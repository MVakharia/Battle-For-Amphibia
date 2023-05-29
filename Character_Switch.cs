using UnityEngine;
using System;

public class Character_Switch : MonoBehaviour
{
    [SerializeField] private SelectedHero activeHero;
    [SerializeField] private int selectedHeroIndex = 2;
    [SerializeField] private Character _character;

    public SelectedHero ActiveHero => activeHero;

    public void SetActiveHero()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(i == selectedHeroIndex);
        }

        activeHero = (SelectedHero)selectedHeroIndex;

        if (ControlInterface.PressedThisFrame_Keyboard1_SelectPreviousHero)
        {
            if(selectedHeroIndex == 1)
            {
                selectedHeroIndex = 3;
            }
            else
            {
                selectedHeroIndex--;
            }
        }

        if (ControlInterface.PressedThisFrame_Keyboard1_SelectNextHero)
        {
            if(selectedHeroIndex == 3)
            {
                selectedHeroIndex = 1;
            }
            else
            {
                selectedHeroIndex++;
            }
        }
    }

    private void Update()
    {
        if (GameManager.Singleton.GameState != GameState.InProgress) return;

        if(_character.CurrentState == CharacterState.Dead) return;

        SetActiveHero();
    }
}