using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGame_GameObjectAnimator : MonoBehaviour
{
    private static InGame_GameObjectAnimator singleton;

    public static InGame_GameObjectAnimator Singleton
    {
        get
        {
            if (singleton == null)
            {
                singleton = GameObject.FindGameObjectWithTag("Animation Manager").GetComponent<InGame_GameObjectAnimator>();
            }
            return singleton;
        }
    }

    private float RoundStartAnimationLength => 2;


    [SerializeField] GameObject gameOverMenu;
    [SerializeField] AnimationManager_UIElement aniManager_GameOverText;
    [SerializeField] AnimationManager_UIElement aniManager_FadingPanel_Red;
    [SerializeField] AnimationManager_UIElement aniManager_FadingPanel_Black;
    [SerializeField] AnimationManager_UIElement aniManager_GameOverMenu;
    [SerializeField] AnimationManager_Character aniManager_Character;
    [SerializeField] AnimationManager_UIElement aniManager_PauseMenu;

    public IEnumerator Routine_RoundStart ()
    {
        aniManager_FadingPanel_Black.gameObject.SetActive(true);

        aniManager_FadingPanel_Black.PlayAnimation_FadeOut_1s();

        yield return new WaitForSeconds(1);

        aniManager_FadingPanel_Black.gameObject.SetActive(false);

        //play the animation for the characters flying in and taking their positions. 

        yield return new WaitForSeconds(RoundStartAnimationLength);

        aniManager_Character.GetComponent<Character_Switch>().SetActiveHero();

        aniManager_Character.PlayAnimation_Idle();

        GameManager.Singleton.SetGameState(GameState.InProgress);

        aniManager_Character.GetComponent<Character_Rendering>().SetPropertiesOnRoundStart();
    }

    public IEnumerator Routine_GameOver ()
    {
        aniManager_GameOverText.gameObject.SetActive(true);

        gameOverMenu.SetActive(true);

        aniManager_GameOverText.PlayAnimation_FadeIn_1s();

        yield return new WaitForSeconds(3);

        aniManager_FadingPanel_Red.gameObject.SetActive(true);

        aniManager_FadingPanel_Red.PlayAnimation_FadeIn_1s();

        yield return new WaitForSeconds(1);

        aniManager_GameOverMenu.gameObject.SetActive(true);

        aniManager_GameOverMenu.PlayAnimation_FadeIn_1s();

        yield return new WaitForSeconds(1);

        aniManager_FadingPanel_Black.gameObject.SetActive(true);
    }

    public IEnumerator Routine_PauseGame ()
    {
        GameManager.Singleton.SetGameState(GameState.Paused);

        Time.timeScale = 0;

        GameManager.Singleton.EnablePauseMenu();

        //fade in the pause menu over 1 second.

        aniManager_PauseMenu.PlayAnimation_FadeIn_1s();

        yield return new WaitForSecondsRealtime(1);
    }

    public IEnumerator Routine_ResumeGame ()
    {
        //fade out the pause menu over 1 second.

        aniManager_PauseMenu.PlayAnimation_FadeOut_1s();

        yield return new WaitForSecondsRealtime(1);

        GameManager.Singleton.DisablePauseMenu();

        Time.timeScale = 1;

        GameManager.Singleton.SetGameState(GameState.InProgress);
    }

    public IEnumerator Routine_RestartGame ()
    {
        //fade in the black fading panel over 1 second. 

        aniManager_FadingPanel_Black.gameObject.SetActive(true);

        aniManager_FadingPanel_Black.PlayAnimation_FadeIn_1s();

        yield return new WaitForSecondsRealtime(1);

        SceneManager.LoadScene("Game");

        Time.timeScale = 1;

        yield return null;
    }

    public IEnumerator Routine_RetryGame()
    {
        //fade in the black fading panel over 1 second. 

        aniManager_FadingPanel_Black.gameObject.SetActive(true);

        aniManager_FadingPanel_Black.PlayAnimation_FadeIn_1s();

        yield return new WaitForSecondsRealtime(1);

        SceneManager.LoadScene("Game");

        Time.timeScale = 1;

        yield return null;
    }

    public IEnumerator Routine_QuitGame()
    {
        //Fade in the black fading panel over 1 second.

        aniManager_FadingPanel_Black.gameObject.SetActive(true);

        aniManager_FadingPanel_Black.PlayAnimation_FadeIn_1s();

        yield return new WaitForSecondsRealtime(1);

        SceneManager.LoadScene("Menu");

        Time.timeScale = 1;

        yield return null;
    }

    private void Start()
    {
        StartCoroutine(Routine_RoundStart());
    }
}