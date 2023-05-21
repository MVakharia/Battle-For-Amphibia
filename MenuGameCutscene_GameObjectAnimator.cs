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
        PlayAnimation_UI_Image_FadeOut_1s();

        yield return new WaitForSeconds(1);

        PlayAnimation_CalamityTrio_FlyBy();

        yield return new WaitForSeconds(2);

        Routine_ShowTutorialMenu();
    }

    public void PlayAnimation_CalamityTrio_FlyBy ()
    {
        AnimationStateChanger.ChangeAnimationState(animator_CalamityTrio, Cutscene_CalamityTrio_FlyBy);
    }

    public void PlayAnimation_UI_Image_FadeOut_1s ()
    {
        AnimationStateChanger.ChangeAnimationState(animator_FadingPanel, UI_Image_FadeOut_1s);
    }

    public void PlayAnimation_UI_Image_FadeIn_1s()
    {
        AnimationStateChanger.ChangeAnimationState(animator_FadingPanel, UI_Image_FadeIn_1s);
    }

    public void Routine_ShowTutorialMenu ()
    {
        AnimationStateChanger.ChangeAnimationState(animator_Menu, ShowElements_TutorialMenu);
    }

    public IEnumerator Routine_PlayTutorialButton ()
    {
        //StartCoroutine(PlayAnimation_UI_Image_FadeIn_1s());

        yield return new WaitForSeconds(1);

        //load tutorial level
    }

    public IEnumerator Routine_SkipTutorialButton ()
    {
        PlayAnimation_UI_Image_FadeIn_1s();

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene("Game");
    }

    public IEnumerator Routine_ReturnToMainMenuButton ()
    {
        PlayAnimation_UI_Image_FadeIn_1s();

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene("Menu");
    }

    public void Start()
    {
        StartCoroutine(Routine_OpenScene());
    }
}