using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuGameCutscene_GameObjectAnimator : MonoBehaviour
{
    private static MenuGameCutscene_GameObjectAnimator singleton;

    public static MenuGameCutscene_GameObjectAnimator Singleton
    {
        get
        {
            if (singleton == null)
            {
                singleton = GameObject.FindGameObjectWithTag("Animation Manager").GetComponent<MenuGameCutscene_GameObjectAnimator>();
            }
            return singleton;
        }
    }

    [SerializeField]
    CutsceneManager _cutsceneManager;

    [SerializeField]
    Animator animator_Menu;

    [SerializeField]
    Animator animator_FadingPanel;

    [SerializeField]
    Animator animator_CalamityTrio;

    const string ShowElements_TutorialMenu = "ShowElements_TutorialMenu";

    const string UI_Image_FadeOut_1s = "UI_Image_FadeOut_1s";

    const string UI_Image_FadeIn_1s = "UI_Image_FadeIn_1s";

    const string Cutscene_CalamityTrio_FlyBy = "Cutscene_CalamityTrio_FlyBy";

    public IEnumerator Routine_OpenScene ()
    {
        StartCoroutine(PlayAnimation_UI_Image_FadeOut_1s());

        yield return new WaitForSeconds(1);

        StartCoroutine(PlayAnimation_CalamityTrio_FlyBy());

        yield return new WaitForSeconds(2);

        StartCoroutine(Routine_ShowTutorialMenu());
    }

    public IEnumerator PlayAnimation_CalamityTrio_FlyBy ()
    {
        AnimationStateChanger.ChangeAnimationState(animator_CalamityTrio, Cutscene_CalamityTrio_FlyBy);

        yield return null;
    }

    public IEnumerator PlayAnimation_UI_Image_FadeOut_1s ()
    {
        AnimationStateChanger.ChangeAnimationState(animator_FadingPanel, UI_Image_FadeOut_1s);

        yield return null;
    }

    public IEnumerator PlayAnimation_UI_Image_FadeIn_1s()
    {
        AnimationStateChanger.ChangeAnimationState(animator_FadingPanel, UI_Image_FadeIn_1s);

        yield return null;
    }

    public IEnumerator Routine_ShowTutorialMenu ()
    {
        AnimationStateChanger.ChangeAnimationState(animator_Menu, ShowElements_TutorialMenu);

        yield return null;
    }

    public IEnumerator Routine_PlayTutorialButton ()
    {
        //StartCoroutine(PlayAnimation_UI_Image_FadeIn_1s());

        yield return new WaitForSeconds(1);

        //load tutorial level
    }

    public IEnumerator Routine_SkipTutorialButton ()
    {
        StartCoroutine(PlayAnimation_UI_Image_FadeIn_1s());

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene("Game");
    }

    public IEnumerator Routine_ReturnToMainMenuButton ()
    {
        StartCoroutine(PlayAnimation_UI_Image_FadeIn_1s());

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene("Menu");
    }

    public void Start()
    {
        StartCoroutine(Routine_OpenScene());
    }
}