using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//place this on the event system. 
public class ControlInterface : MonoBehaviour
{
    private static Controls inputActions;

    public static bool PressedThisFrame_Keyboard1_Up => inputActions.Keyboard1.Up.WasPressedThisFrame();
    public static bool IsPressed_Keyboard1_Up => inputActions.Keyboard1.Up.IsPressed();
    public static bool ReleasedThisFrame_Keyboard1_Up => inputActions.Keyboard1.Up.WasReleasedThisFrame();

    public static bool PressedThisFrame_Keyboard1_Down => inputActions.Keyboard1.Down.WasPressedThisFrame();
    public static bool IsPressed_Keyboard1_Down => inputActions.Keyboard1.Down.IsPressed();
    public static bool ReleasedThisFrame_Keyboard1_Down => inputActions.Keyboard1.Down.WasReleasedThisFrame();

    public static bool PressedThisFrame_Keyboard1_Left => inputActions.Keyboard1.Left.WasPressedThisFrame();
    public static bool IsPressed_Keyboard1_Left => inputActions.Keyboard1.Left.IsPressed();
    public static bool ReleasedThisFrame_Keyboard1_Left => inputActions.Keyboard1.Left.WasReleasedThisFrame();

    public static bool PressedThisFrame_Keyboard1_Right => inputActions.Keyboard1.Right.WasPressedThisFrame();
    public static bool IsPressed_Keyboard1_Right => inputActions.Keyboard1.Right.IsPressed();
    public static bool ReleasedThisFrame_Keyboard1_Right => inputActions.Keyboard1.Right.WasReleasedThisFrame();

    public static bool PressedThisFrame_Keyboard1_SelectNextHero => inputActions.Keyboard1.SelectNextHero.WasPressedThisFrame();
    public static bool PressedThisFrame_Keyboard1_SelectPreviousHero => inputActions.Keyboard1.SelectPrevousHero.WasPressedThisFrame();

    public static bool PressedThisFrame_Keyboard1_Pause => inputActions.Keyboard1.Pause.WasPressedThisFrame();

    public static bool PressedThisFrame_Keyboard1_Ability1 => inputActions.Keyboard1.Ability1.WasPressedThisFrame();

    public static bool PressedThisFrame_Keyboard1_Ability2 => inputActions.Keyboard1.Ability2.WasPressedThisFrame();

    private void Start()
    {
        inputActions = new Controls();

        //inputActions.Enable();

        inputActions.Keyboard1.Enable();
    }
}
