using UnityEngine;

#region Enums
public enum AnimationStates_FadeIn_1s
{
    None, TMPro_Font_FadeIn_1s, GameOverMenu_FadeIn, UI_Image_FadeIn_1s, PauseMenu_FadeIn
}

public enum AnimationStates_FadeOut_1s
{
    None, UI_Image_FadeOut_1s, PauseMenu_FadeOut
}
#endregion

public abstract class AnimationManager : MonoBehaviour
{
    #region Fields
    [SerializeField] protected AnimationStates_FadeIn_1s states_FadeIn_1s;
    [SerializeField] protected AnimationStates_FadeOut_1s states_FadeOut_1s;
    [SerializeField] protected Animator animator;
    #endregion

    #region Properties
    protected string State_FadeIn_1s_ToString => states_FadeIn_1s switch
    {
        AnimationStates_FadeIn_1s.TMPro_Font_FadeIn_1s => "TMPro_Font_FadeIn_1s",
        AnimationStates_FadeIn_1s.GameOverMenu_FadeIn => "GameOverMenu_FadeIn",
        AnimationStates_FadeIn_1s.UI_Image_FadeIn_1s => "UI_Image_FadeIn_1s",
        AnimationStates_FadeIn_1s.PauseMenu_FadeIn => "PauseMenu_FadeIn",

        _ => ""
    };

    protected string State_FadeOut_1s_ToString => states_FadeOut_1s switch
    {
        AnimationStates_FadeOut_1s.UI_Image_FadeOut_1s => "UI_Image_FadeOut_1s",
        AnimationStates_FadeOut_1s.PauseMenu_FadeOut => "PauseMenu_FadeOut",
        _ => ""
    };

    public Animator Animator
    {
        get
        {
            if (animator == null)
            {
                animator = GetComponent<Animator>();
            }
            return animator;
        }
        private set => animator = value;
    }
    #endregion

    #region Methods
    public void Animator_Disable() => Animator.enabled = false;
    public void Animator_Enable() => Animator.enabled = true;

    public abstract void PlayAnimation_Idle();
    public abstract void PlayAnimation_FadeIn_1s();
    public abstract void PlayAnimation_FadeOut_1s();
    #endregion
}