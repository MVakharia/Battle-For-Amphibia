using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager_Button_GameOver_Quit : AnimationManager
{
    const string Button_Quit_FadeIn_1s = "Button_Quit_FadeIn_1s";

    public override void PlayAnimation()
    {
        AnimationStateChanger.ChangeAnimationState(Animator, Button_Quit_FadeIn_1s);
    }

}
