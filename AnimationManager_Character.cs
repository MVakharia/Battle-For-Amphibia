using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager_Character : AnimationManager
{
    const string Character_SetUpPosition = "Character_SetUpPosition";

    const string Character_Idle = "Character_Idle";

    public override void PlayAnimation()
    {
        throw new System.NotImplementedException();
    }

    public void PlayAnimation_SetUpPosition()
    {
        AnimationStateChanger.ChangeAnimationState(Animator, Character_SetUpPosition);
    }

    public void PlayAnimation_Idle()
    {
        AnimationStateChanger.ChangeAnimationState(Animator, Character_Idle);
    }
}
