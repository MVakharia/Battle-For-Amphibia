using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionInterface : MonoBehaviour
{
    public int InGame_Y_Movement()
    {
        if (ControlInterface.IsPressed_Keyboard_Up)
        {
            if (transform.position.y > GameManager.Singleton.UpperBounds)
            {
                return 0;
            }

            return 1;
        }
        if (ControlInterface.IsPressed_Keyboard_Down)
        {
            if (transform.position.y < GameManager.Singleton.LowerBounds)
            {
                return 0;
            }

            return -1;
        }
        return 0;
    }

    public int InGame_X_Movement()
    {
        if (ControlInterface.IsPressed_Keyboard_Right)
        {
            if (transform.position.x > GameManager.Singleton.RightBounds)
            {
                return 0;
            }

            return 1;
        }
        if (ControlInterface.IsPressed_Keyboard_Left)
        {
            if (transform.position.x < GameManager.Singleton.LeftBounds)
            {
                return 0;
            }
            return -1;

        }
        return 0;
    }

    public Vector2 MovementVector()
    {
        Vector2 vec = new Vector2(InGame_X_Movement(), InGame_Y_Movement());

        float mag = vec.magnitude;

        if (mag > 1)
        {
            vec /= mag;
        }

        return vec;
    }
}