using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager_Credits : MonoBehaviour
{
    public void Button_Return ()
    {
        StartCoroutine(Routine_Button_Return());
    }

    public void Button_Credits_Next ()
    {
        StartCoroutine(Routine_Button_Credits_Next());
    }

    public void Button_Credits_Previous ()
    {
        StartCoroutine(Routine_Button_Credits_Previous());
    }

    [SerializeField] Animator fadingPanelAnimator;
    [SerializeField] AnimationManager_UIElement aniManager_FadingPanel;

    private IEnumerator Routine_Button_Return ()
    {
        fadingPanelAnimator.gameObject.SetActive(true);

        aniManager_FadingPanel.PlayAnimation_FadeIn_1s();

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene("Main Menu");
    }

    private IEnumerator Routine_Button_Credits_Next ()
    {
        yield return new WaitForSeconds(1);
    }

    private IEnumerator Routine_Button_Credits_Previous()
    {
        yield return new WaitForSeconds(1);
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