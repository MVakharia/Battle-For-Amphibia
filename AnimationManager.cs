using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AnimationStates
{
    None,
}

public enum AnimationStates_FadeIn_1s
{
    None, TMPro_Font_FadeIn_1s, Button_Retry_FadeIn_1s, UI_Image_FadeIn_1s, Button_Quit_FadeIn_1s
}

public enum AnimationStates_FadeOut_1s
{
    None, UI_Image_FadeOut_1s,
}

public abstract class AnimationManager : MonoBehaviour
{
    [SerializeField]
    protected AnimationStates states;

    [SerializeField]
    protected AnimationStates_FadeIn_1s states_FadeIn_1s;

    [SerializeField]
    protected AnimationStates_FadeOut_1s states_FadeOut_1s;

    protected string State_FadeIn_1s_ToString()
    {
        return states_FadeIn_1s switch
        {
            AnimationStates_FadeIn_1s.TMPro_Font_FadeIn_1s => "TMPro_Font_FadeIn_1s",
            AnimationStates_FadeIn_1s.Button_Retry_FadeIn_1s => "Button_Retry_FadeIn_1s",
            AnimationStates_FadeIn_1s.UI_Image_FadeIn_1s => "UI_Image_FadeIn_1s",
            AnimationStates_FadeIn_1s.Button_Quit_FadeIn_1s => "Button_Quit_FadeIn_1s",

            _ => ""
        };
    }

    protected string State_FadeOut_1s_ToString ()
    {
        return states_FadeOut_1s switch
        {
            AnimationStates_FadeOut_1s.UI_Image_FadeOut_1s => "UI_Image_FadeOut_1s",
            _ => ""
        };
    }

    [SerializeField]
    protected Animator animator;

    public void Animator_Disable() => animator.enabled = false;
    public void Animator_Enable() => animator.enabled = true;

    public Animator Animator
    {
        get
        {
            if(animator == null)
            {
                animator = GetComponent<Animator>();
            }
            return animator;
        }
    }

    public abstract void PlayAnimation_Idle();
    public abstract void PlayAnimation_FadeIn_1s();
    public abstract void PlayAnimation_FadeOut_1s();
}