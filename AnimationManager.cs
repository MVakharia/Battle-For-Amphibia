using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum AnimationStates
{
    None, TMPro_Font_FadeIn_1s, Button_Retry_FadeIn_1s
}

public abstract class AnimationManager : MonoBehaviour
{

    [SerializeField]
    AnimationStates states;

    protected string State => states switch
    {
        AnimationStates.TMPro_Font_FadeIn_1s => "TMPro_Font_FadeIn_1s",
        AnimationStates.Button_Retry_FadeIn_1s => "Button_Retry_FadeIn_1s",

        _ => ""
    };

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

    public abstract void PlayAnimation();
}
