using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager_Character : AnimationManager
{
    //Create a separate character specifically for cutscenes.
    //That character will be animated until the round starts,
    //then disabled so that the player-controllable character can take its place. 

    const string Character_Idle = "Character_Idle";

    const string Character_Hurt = "Character_Hurt";

    public override void PlayAnimation_FadeIn_1s()
    {
        throw new System.NotImplementedException();
    }

    public override void PlayAnimation_FadeOut_1s()
    {
        throw new System.NotImplementedException();
    }

    public override void PlayAnimation_Idle()
    {
        AnimationStateChanger.ChangeAnimationState(Animator, Character_Idle);
    }

    public void PlayAnimation_Hurt ()
    {
        AnimationStateChanger.ChangeAnimationState(Animator, Character_Hurt);
    }
}
