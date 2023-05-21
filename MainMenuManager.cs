using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void Button_Play ()
    {
        StartCoroutine(MainMenu_GameObjectAnimator.Singleton.Routine_PlayGameButton());
    }

    public void Button_Quit ()
    {
        StartCoroutine(MainMenu_GameObjectAnimator.Singleton.Routine_QuitGameButton());
    }
}