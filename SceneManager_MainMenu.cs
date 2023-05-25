using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager_MainMenu : MonoBehaviour
{
    public void Button_Play() => StartCoroutine(Routine_PlayGameButton());
    public void Button_Controls() => StartCoroutine(Routine_ControlsMenuButton());
    public void Button_Credits() => StartCoroutine(Routine_CreditsButton());
    public void Button_Quit() => StartCoroutine(Routine_QuitGameButton());

    private static SceneManager_MainMenu singleton;

    public static SceneManager_MainMenu Singleton
    {
        get
        {
            if (singleton == null)
            {
                singleton = GameObject.FindGameObjectWithTag("Scene Manager").GetComponent<SceneManager_MainMenu>();
            }
            return singleton;
        }
    }

    [SerializeField] Animator fadingPanelAnimator;
    [SerializeField] AnimationManager_UIElement aniManager_FadingPanel;

    private IEnumerator Routine_PlayGameButton()
    {
        fadingPanelAnimator.gameObject.SetActive(true);

        aniManager_FadingPanel.PlayAnimation_FadeIn_1s();

        yield return new WaitForSeconds(1F);

        SceneManager.LoadScene("Menu-Game Cutscene");
    }

    private IEnumerator Routine_ControlsMenuButton()
    {
        fadingPanelAnimator.gameObject.SetActive(true);

        aniManager_FadingPanel.PlayAnimation_FadeIn_1s();

        yield return new WaitForSeconds(1F);

        SceneManager.LoadScene("Controls Menu");
    }

    private IEnumerator Routine_CreditsButton()
    {
        fadingPanelAnimator.gameObject.SetActive(true);

        aniManager_FadingPanel.PlayAnimation_FadeIn_1s();

        yield return new WaitForSeconds(1F);

        SceneManager.LoadScene("Credits");
    }

    private IEnumerator Routine_QuitGameButton()
    {
        fadingPanelAnimator.gameObject.SetActive(true);

        aniManager_FadingPanel.PlayAnimation_FadeIn_1s();

        yield return new WaitForSeconds(1F);

        Application.Quit();
    }

    private IEnumerator Routine_OpenScene()
    {
        aniManager_FadingPanel.PlayAnimation_FadeOut_1s();

        yield return new WaitForSeconds(1);

        fadingPanelAnimator.gameObject.SetActive(false);
    }

    private void Awake()
    {
        fadingPanelAnimator.gameObject.SetActive(true);
    }

    private void Start()
    {
        StartCoroutine(Routine_OpenScene());
    }
}