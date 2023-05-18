using System.Collections;
using System.Collections.Generic;
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

    //const string TMPro_Font_FadeIn_1s = "TMPro_Font_FadeIn_1s";

    /*const string Mesh_FadeOut_1s = "Mesh_FadeOut_1s";

    const string Mesh_FadeIn_1s = "Mesh_FadeIn_1s";*/

    /*
    const string UI_Image_FadeOut_1s = "UI_Image_FadeOut_1s";

    const string UI_Image_FadeIn_1s = "UI_Image_FadeIn_1s";
    */
    /*
    const string Character_SetUpPosition = "Character_SetUpPosition";

    const string Character_Idle = "Character_Idle";

    //const string Button_Retry_FadeIn_1s = "Button_Retry_FadeIn_1s";

    //const string Button_Quit_FadeIn_1s = "Button_Quit_FadeIn_1s";

    /*
    [SerializeField]
    Animator animator_GameOver;
    */

    [SerializeField]
    GameObject gameOverMenu;

    [SerializeField]
    AnimationManager_UIElement aniManager_GameOver;

    [SerializeField]
    AnimationManager_FadingPanel_Red aniManager_FadingPanel_Red;
    /*
    [SerializeField]
    Animator animator_FadingPanel_Red;
    */

    [SerializeField]
    AnimationManager_UIElement aniManager_Button_Retry;

    [SerializeField]
    AnimationManager_Button_GameOver_Quit aniManager_Button_GameOver_Quit;

    [SerializeField]
    AnimationManager_Character aniManager_Character;

    [SerializeField]
    Animator animator_FadingPanel_Black;

    [SerializeField]
    Animator animator_Character;

    [SerializeField]
    Animator animator_Button_Retry;

    [SerializeField]
    Animator animator_Button_Quit;

    /*
    public IEnumerator PlayAnimation_GameOver_FadeIn()
    {
        animator_GameOver.gameObject.SetActive(true);

        AnimationStateChanger.ChangeAnimationState(animator_GameOver, TMPro_Font_FadeIn_1s);

        yield return null;
    }
    */
    /*
    public IEnumerator PlayAnimation_Retry_FadeIn ()
    {
        AnimationStateChanger.ChangeAnimationState(animator_Button_Retry, Button_Retry_FadeIn_1s);

        yield return null;
    }
    */

    /*
    public IEnumerator PlayAnimation_Quit_FadeIn()
    {
        AnimationStateChanger.ChangeAnimationState(animator_Button_Quit, Button_Quit_FadeIn_1s);

        yield return null;
    }
    */

    /*
    public IEnumerator PlayAnimation_FadingPanel_Red_FadeOut ()
    {
        AnimationStateChanger.ChangeAnimationState(animator_FadingPanel_Red, UI_Image_FadeOut_1s);

        yield return null;
    }

    public IEnumerator PlayAnimation_FadingPanel_Red_FadeIn()
    {
        AnimationStateChanger.ChangeAnimationState(animator_FadingPanel_Red, UI_Image_FadeIn_1s);

        yield return null;
    }
    */
    /*
    public IEnumerator PlayAnimation_Character_SetUpPosition ()
    {
        AnimationStateChanger.ChangeAnimationState(animator_Character, Character_SetUpPosition);

        yield return null;
    }

    public IEnumerator PlayAnimation_Character_Idle ()
    {
        AnimationStateChanger.ChangeAnimationState(animator_Character, Character_Idle);

        yield return null;
    }
    */

    

    public IEnumerator Routine_RoundStart ()
    {
        aniManager_FadingPanel_Red.PlayAnimation_FadeOut();

        yield return new WaitForSeconds(1);

        aniManager_Character.PlayAnimation_SetUpPosition();

        yield return new WaitForSeconds(2);

        animator_Character.GetComponent<Character_Switch>().SetActiveHero();

        aniManager_Character.PlayAnimation_Idle();

        aniManager_Character.Animator_Disable();

        GameManager.Singleton.StartRound();

        animator_Character.GetComponent<Character_Rendering>().SetPropertiesOnRoundStart();
    }

    public IEnumerator Routine_GameOver ()
    {
        aniManager_GameOver.gameObject.SetActive(true);

        gameOverMenu.SetActive(true);

        aniManager_GameOver.PlayAnimation();

        yield return new WaitForSeconds(3);

        aniManager_FadingPanel_Red.PlayAnimation();

        yield return new WaitForSeconds(1);

        animator_Button_Retry.gameObject.SetActive(true);

        aniManager_Button_Retry.PlayAnimation();

        yield return new WaitForSeconds(0.5F);

        animator_Button_Quit.gameObject.SetActive(true);

        aniManager_Button_GameOver_Quit.PlayAnimation();
    }

    public IEnumerator Routine_PauseGame ()
    {
        Time.timeScale = 0;

        //change game state to Paused. 

        GameManager.Singleton.EnablePauseMenu();

        //fade in the pause menu over 1 second. 

        yield return new WaitForSeconds(1);
    }

    public IEnumerator Routine_ResumeGame ()
    {
        //fade out the pause menu over 1 second.

        yield return new WaitForSecondsRealtime(1);

        GameManager.Singleton.DisablePauseMenu();

        Time.timeScale = 1;

        //change game state to In Progress. 
    }

    public IEnumerator Routine_RestartGame ()
    {
        //fade in the black fading panel over 1 second. 

        yield return new WaitForSecondsRealtime(1);

        SceneManager.LoadScene("Game");

        Time.timeScale = 1;

        yield return null;
    }

    public IEnumerator Routine_RetryGame()
    {
        //fade in the black fading panel over 1 second. 

        yield return new WaitForSecondsRealtime(1);

        SceneManager.LoadScene("Game");

        Time.timeScale = 1;

        yield return null;
    }

    public IEnumerator Routine_QuitGame()
    {
        //Fade in the black fading panel over 1 second.

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