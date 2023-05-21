using UnityEngine;
using UnityEngine.UI;

public class CutsceneManager : MonoBehaviour
{
    [SerializeField]
    private Toggle skipTutorial;

    public void PlayTutorialButton ()
    {
        StartCoroutine(MenuGameCutscene_GameObjectAnimator.Singleton.Routine_PlayTutorialButton());
    }

    public void SkipTutorialButton ()
    {
        StartCoroutine(MenuGameCutscene_GameObjectAnimator.Singleton.Routine_SkipTutorialButton());
    }

    public void ReturnButton ()
    {
        StartCoroutine(MenuGameCutscene_GameObjectAnimator.Singleton.Routine_ReturnToMainMenuButton());
    }
}