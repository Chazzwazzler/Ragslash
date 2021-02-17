//The class containing important things for all tool classes

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolController : MonoBehaviour
{
    public enum Tools{buildTool, dragTool, selectionTool, glueTool, followTool};
    public static Tools currentlySelectedTool = Tools.buildTool;

    void Update()
    {
        if(Input.GetKeyDown(Keybinds.switchToBuildTool)){
            currentlySelectedTool = Tools.buildTool;

            Debug.Log("Switched to the build tool!");
        }
        else if(Input.GetKeyDown(Keybinds.switchToDragTool)){
            currentlySelectedTool = Tools.dragTool;
            
            Debug.Log("Switched to the drag tool!");
        }
        else if(Input.GetKeyDown(Keybinds.switchToSelectionTool)){
            currentlySelectedTool = Tools.selectionTool;
            
            Debug.Log("Switched to the selection tool!");
        }
        else if(Input.GetKeyDown(Keybinds.switchToGlueTool)){
            currentlySelectedTool = Tools.glueTool;
            
            Debug.Log("Switched to the glue tool!");
        }
        else if(Input.GetKeyDown(Keybinds.switchToFollowTool)){
            currentlySelectedTool = Tools.followTool;
            
            Debug.Log("Switched to the follow tool!");
        }

    }

    public void changeTool(Tools changedTool){
        currentlySelectedTool = changedTool;
    }
}
