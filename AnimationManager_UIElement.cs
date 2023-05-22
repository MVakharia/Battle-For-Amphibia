using System.Collections;
using UnityEngine;

public class AnimationManager_UIElement : AnimationManager
{
    #region Methods
    public override void PlayAnimation_Idle() => throw new System.NotImplementedException();
    public override void PlayAnimation_FadeIn_1s() => AnimationStateChanger.ChangeAnimationState(Animator, State_FadeIn_1s_ToString);
    public override void PlayAnimation_FadeOut_1s() => AnimationStateChanger.ChangeAnimationState(Animator, State_FadeOut_1s_ToString);
    #endregion
}