using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateChanger : MonoBehaviour
{
    private static string currentState;

    public static void ChangeAnimationState (Animator _animator, string newState)
    {
        if (currentState == newState) return;

        _animator.Play(newState);

        currentState = newState;
    }
}