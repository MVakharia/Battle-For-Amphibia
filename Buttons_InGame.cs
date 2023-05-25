using UnityEngine;

public class Buttons_InGame : MonoBehaviour
{
    public void Button_Resume() => StartCoroutine(SceneManager_InGame.Singleton.Routine_ResumeGame());
    public void Button_Restart() => StartCoroutine(SceneManager_InGame.Singleton.Routine_RestartGame());
    public void Button_Retry() => StartCoroutine(SceneManager_InGame.Singleton.Routine_RetryGame());
    public void Button_Quit() => StartCoroutine(SceneManager_InGame.Singleton.Routine_QuitGame());
}