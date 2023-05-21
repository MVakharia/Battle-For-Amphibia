using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu_GameObjectAnimator : MonoBehaviour
{
    private static MainMenu_GameObjectAnimator singleton;

    public static MainMenu_GameObjectAnimator Singleton
    {
        get
        {
            if (singleton == null)
            {
                singleton = GameObject.FindGameObjectWithTag("Animation Manager").GetComponent<MainMenu_GameObjectAnimator>();
            }
            return singleton;
        }
    }

    [SerializeField]
    MainMenuManager _mainMenuManager;

    const string UI_Image_FadeIn_1s = "UI_Image_FadeIn_1s";

    const string UI_Image_FadeOut_1s = "UI_Image_FadeOut_1s";

    [SerializeField]
    Animator fadingPanelAnimator;

    public IEnumerator Routine_PlayGameButton ()
    {
        StartCoroutine(PlayAnimation_FadingPanel_FadeIn_1s());

        yield return new WaitForSeconds(1F);

        SceneManager.LoadScene("Menu-Game Cutscene");
    }

    public IEnumerator Routine_QuitGameButton ()
    {
        StartCoroutine(PlayAnimation_FadingPanel_FadeIn_1s());

        yield return new WaitForSeconds(1F);

        Application.Quit();
    }

    public IEnumerator Routine_OpenScene ()
    {
        StartCoroutine(PlayAnimation_FadingPanel_FadeOut_1s());

        yield return new WaitForSeconds(1);
    }

    public IEnumerator PlayAnimation_FadingPanel_FadeIn_1s ()
    {
        fadingPanelAnimator.gameObject.SetActive(true);

        AnimationStateChanger.ChangeAnimationState(fadingPanelAnimator, UI_Image_FadeIn_1s);

        yield return null;
    }

    public IEnumerator PlayAnimation_FadingPanel_FadeOut_1s ()
    {
        AnimationStateChanger.ChangeAnimationState(fadingPanelAnimator, UI_Image_FadeOut_1s);

        yield return new WaitForSeconds(1);

        fadingPanelAnimator.gameObject.SetActive(false);
    }

    public void Start()
    {
        StartCoroutine(Routine_OpenScene());
    }
}
