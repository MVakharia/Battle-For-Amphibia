using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//place this on the event system. 
public class ControlInterface : MonoBehaviour
{
    private static Controls inputActions;

    public static bool PressedThisFrame_Keyboard_Up => inputActions.Keyboard.Up.WasPressedThisFrame();
    public static bool IsPressed_Keyboard_Up => inputActions.Keyboard.Up.IsPressed();
    public static bool ReleasedThisFrame_Keyboard_Up => inputActions.Keyboard.Up.WasReleasedThisFrame();

    public static bool PressedThisFrame_Keyboard_Down => inputActions.Keyboard.Down.WasPressedThisFrame();
    public static bool IsPressed_Keyboard_Down => inputActions.Keyboard.Down.IsPressed();
    public static bool ReleasedThisFrame_Keyboard_Down => inputActions.Keyboard.Down.WasReleasedThisFrame();

    public static bool PressedThisFrame_Keyboard_Left => inputActions.Keyboard.Left.WasPressedThisFrame();
    public static bool IsPressed_Keyboard_Left => inputActions.Keyboard.Left.IsPressed();
    public static bool ReleasedThisFrame_Keyboard_Left => inputActions.Keyboard.Left.WasReleasedThisFrame();

    public static bool PressedThisFrame_Keyboard_Right => inputActions.Keyboard.Right.WasPressedThisFrame();
    public static bool IsPressed_Keyboard_Right => inputActions.Keyboard.Right.IsPressed();
    public static bool ReleasedThisFrame_Keyboard_Right => inputActions.Keyboard.Right.WasReleasedThisFrame();

    public static bool PressedThisFrame_Keyboard_SelectNextHero => inputActions.Keyboard.SelectNextHero.WasPressedThisFrame();
    public static bool PressedThisFrame_Keyboard_SelectPreviousHero => inputActions.Keyboard.SelectPrevousHero.WasPressedThisFrame();

    public static bool PressedThisFrame_Keyboard_Pause => inputActions.Keyboard.Pause.WasPressedThisFrame();

    private void Start()
    {
        inputActions = new Controls();

        inputActions.Enable();
    }
}
