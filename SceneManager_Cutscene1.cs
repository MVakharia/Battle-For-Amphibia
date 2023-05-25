using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManager_Cutscene1 : MonoBehaviour
{
    private static SceneManager_Cutscene1 singleton;

    public static SceneManager_Cutscene1 Singleton
    {
        get
        {
            if (singleton == null)
            {
                singleton = GameObject.FindGameObjectWithTag("Animation Manager").GetComponent<SceneManager_Cutscene1>();
            }
            return singleton;
        }
    }

    [SerializeField] Animator animator_Menu;
    [SerializeField] Animator animator_FadingPanel;
    [SerializeField] Animator animator_CalamityTrio;
    [SerializeField] AnimationManager_UIElement aniManager_FadingPanel;

    const string ShowElements_TutorialMenu = "ShowElements_TutorialMenu";
    const string Cutscene_CalamityTrio_FlyBy = "Cutscene_CalamityTrio_FlyBy";

    [SerializeField]
    private Toggle skipTutorial;

    public void PlayTutorialButton()
    {
        StartCoroutine(Routine_PlayTutorialButton());
    }

    public void SkipTutorialButton()
    {
        StartCoroutine(Routine_SkipTutorialButton());
    }

    public void ReturnButton()
    {
        StartCoroutine(Routine_ReturnToMainMenuButton());
    }

    public IEnumerator Routine_OpenScene ()
    {
        aniManager_FadingPanel.gameObject.SetActive(true);

        aniManager_FadingPanel.PlayAnimation_FadeOut_1s();

        yield return new WaitForSeconds(1);

        PlayAnimation_CalamityTrio_FlyBy();

        yield return new WaitForSeconds(2);

        Routine_ShowTutorialMenu();
    }

    public void PlayAnimation_CalamityTrio_FlyBy ()
    {
        AnimationStateChanger.ChangeAnimationState(animator_CalamityTrio, Cutscene_CalamityTrio_FlyBy);
    }

    public void Routine_ShowTutorialMenu ()
    {
        AnimationStateChanger.ChangeAnimationState(animator_Menu, ShowElements_TutorialMenu);
    }

    public IEnumerator Routine_PlayTutorialButton ()
    {
        yield return null;
    }

    public IEnumerator Routine_SkipTutorialButton ()
    {
        aniManager_FadingPanel.PlayAnimation_FadeIn_1s();

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene("Game");
    }

    public IEnumerator Routine_ReturnToMainMenuButton ()
    {
        aniManager_FadingPanel.PlayAnimation_FadeIn_1s();

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene("Main Menu");
    }

    public void Start()
    {
        StartCoroutine(Routine_OpenScene());
    }
}