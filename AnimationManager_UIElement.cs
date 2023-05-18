using System.Collections;
using UnityEngine;

public class AnimationManager_UIElement : AnimationManager
{
    public override void PlayAnimation()
    {
        AnimationStateChanger.ChangeAnimationState(Animator, State);
    }
}