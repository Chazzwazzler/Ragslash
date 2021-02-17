//Holds all the keybinds for certain actions, along with the code that controlls the changing of them

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Keybinds
{
    public static KeyCode usePrimaryToolFunction = KeyCode.Mouse0;
    public static KeyCode useSecondaryToolFunction = KeyCode.Mouse1;

    public static KeyCode switchToBuildTool = KeyCode.Alpha1;
    public static KeyCode switchToDragTool = KeyCode.Alpha2;
    public static KeyCode switchToSelectionTool = KeyCode.Alpha3;
    public static KeyCode switchToGlueTool = KeyCode.Alpha4;
    public static KeyCode switchToFollowTool = KeyCode.Alpha5;

    public static KeyCode cameraLeft = KeyCode.A;
    public static KeyCode cameraRight = KeyCode.D;
    public static KeyCode cameraUp = KeyCode.W;
    public static KeyCode cameraDown = KeyCode.S;
    public static KeyCode panCamera = KeyCode.Mouse2;

    public static KeyCode resetScene = KeyCode.R;
}
