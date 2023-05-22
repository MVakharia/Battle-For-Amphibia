using UnityEngine;

public class Buttons_InGame : MonoBehaviour
{
    public void Button_Resume() => StartCoroutine(InGame_GameObjectAnimator.Singleton.Routine_ResumeGame());
    public void Button_Restart() => StartCoroutine(InGame_GameObjectAnimator.Singleton.Routine_RestartGame());
    public void Button_Retry() => StartCoroutine(InGame_GameObjectAnimator.Singleton.Routine_RetryGame());
    public void Button_Quit() => StartCoroutine(InGame_GameObjectAnimator.Singleton.Routine_QuitGame());
}