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

    [SerializeField] Character_Select_Data charSelData;

    const string ShowElements_TutorialMenu = "ShowElements_TutorialMenu";
    const string Cutscene_CalamityTrio_FlyBy = "Cutscene_CalamityTrio_FlyBy";
    const string CharacterSelect = "CharacterSelect";

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

    public void Button_Sasha()
    {
        StartCoroutine(Routine_Button_Sasha());
    }

    public void Button_Anne()
    {
        StartCoroutine(Routine_Button_Anne());
    }
    public void Button_Marcy()
    {
        StartCoroutine(Routine_Button_Marcy());
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

        //Routine_ShowTutorialMenu();

        PlayAnimation_ShowCharacterSelectMenu();
    }

    public void PlayAnimation_CalamityTrio_FlyBy ()
    {
        AnimationStateChanger.ChangeAnimationState(animator_CalamityTrio, Cutscene_CalamityTrio_FlyBy);
    }

    public void PlayAnimation_ShowTutorialMenu ()
    {
        AnimationStateChanger.ChangeAnimationState(animator_Menu, ShowElements_TutorialMenu);
    }

    public void PlayAnimation_ShowCharacterSelectMenu()
    {
        AnimationStateChanger.ChangeAnimationState(animator_Menu, CharacterSelect);
    }

    public IEnumerator Routine_Button_Sasha()
    {
        //select Sasha. 

        charSelData.SelectSasha();

        aniManager_FadingPanel.PlayAnimation_FadeIn_1s();

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene("Game");
    }

    public IEnumerator Routine_Button_Anne()
    {
        //select Anne. 

        charSelData.SelectAnne();

        aniManager_FadingPanel.PlayAnimation_FadeIn_1s();

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene("Game");
    }

    public IEnumerator Routine_Button_Marcy()
    {
        //select Marcy.

        charSelData.SelectMarcy();

        aniManager_FadingPanel.PlayAnimation_FadeIn_1s();

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene("Game");
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