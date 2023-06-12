using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager_InGame : MonoBehaviour
{
    private static SceneManager_InGame singleton;

    public static SceneManager_InGame Singleton
    {
        get
        {
            if (singleton == null)
            {
                singleton = GameObject.FindGameObjectWithTag("Animation Manager").GetComponent<SceneManager_InGame>();
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

    [SerializeField] AudioManager_InGame audioManager_InGame;

    public IEnumerator Routine_RoundStart ()
    {
        aniManager_FadingPanel_Black.gameObject.SetActive(true);

        aniManager_FadingPanel_Black.PlayAnimation_FadeOut_1s();

        yield return new WaitForSeconds(1);

        aniManager_FadingPanel_Black.gameObject.SetActive(false);

        //play the animation for the characters flying in and taking their positions. 

        yield return new WaitForSeconds(RoundStartAnimationLength);

        //aniManager_Character.GetComponent<Character_Switch>().SetActiveHero();

        //aniManager_Character.PlayAnimation_Idle();

        GameManager.Singleton.SetGameState(GameState.InProgress);

        aniManager_Character.GetComponent<Character_Rendering>().SetPropertiesOnRoundStart();
    }

    public IEnumerator Routine_GameOver ()
    {
        audioManager_InGame.StopBGM();

        aniManager_GameOverText.gameObject.SetActive(true);

        gameOverMenu.SetActive(true);

        aniManager_GameOverText.PlayAnimation_FadeIn_1s();

        yield return new WaitForSeconds(1);

        audioManager_InGame.PlayBGM_GameOver();

        yield return new WaitForSeconds(2);

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

        SceneManager.LoadScene("Main Menu");

        Time.timeScale = 1;

        yield return null;
    }

    private void Awake()
    {
        GameObject _ = GameObject.FindGameObjectWithTag("Character");

        if(_ != null)
        {
            aniManager_Character = _.GetComponent<AnimationManager_Character>();
        }
        else
        {
            Debug.LogError("Couldn't find Character ANimation Manager.");
        }
    }

    private void Start()
    {
        StartCoroutine(Routine_RoundStart());
    }
}