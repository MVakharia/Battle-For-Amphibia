using UnityEngine;
using System;

public class Character_Switch : MonoBehaviour
{
    public SelectedHero ActiveHero => (SelectedHero)selectedHeroIndex;

    private int selectedHeroIndex = 1;

    [SerializeField]
    private Character _character;

    public void SetActiveHero()
    {
        if (ControlInterface.PressedThisFrame_Keyboard_SelectNextHero)
        {
            selectedHeroIndex = (selectedHeroIndex + 1) % transform.childCount;
        }

        if(ControlInterface.PressedThisFrame_Keyboard_SelectPreviousHero)
        {
            selectedHeroIndex--;

            if(selectedHeroIndex < 0)
            {
                selectedHeroIndex = transform.childCount - 1;
            }
        }

        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(i == selectedHeroIndex);
        }
    }

    private void Update()
    {
        if (GameManager.Singleton.GameState != GameState.InProgress) return;

        if(_character.CurrentState == CharacterState.Dead) return;

        SetActiveHero();
    }
}