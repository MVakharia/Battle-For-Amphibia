using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager_FadingPanel_Red : AnimationManager
{
    const string UI_Image_FadeOut_1s = "UI_Image_FadeOut_1s";

    const string UI_Image_FadeIn_1s = "UI_Image_FadeIn_1s";

    public void PlayAnimation_FadeOut()
    {
        AnimationStateChanger.ChangeAnimationState(Animator, UI_Image_FadeOut_1s);
    }

    public override void PlayAnimation()
    {
        AnimationStateChanger.ChangeAnimationState(Animator, UI_Image_FadeIn_1s);
    }
}
