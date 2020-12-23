using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toolBar : MonoBehaviour
{
    public enum toolSelected{
        dragTool,
        buildTool,
        rotateTool,
        scaleTool,
        selectTool,
        selectionBoxTool,
        glueTool
    }
    public toolSelected currentToolSelected = toolSelected.buildTool;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1)){
            currentToolSelected = toolSelected.buildTool;
        }
        if(Input.GetKeyDown(KeyCode.Alpha2)){
            currentToolSelected = toolSelected.dragTool;
        }
        if(Input.GetKeyDown(KeyCode.Alpha3)){
            currentToolSelected = toolSelected.glueTool;
        }
    }

    public void selectDragTool(){
        currentToolSelected = toolSelected.dragTool;
    }
    public void selectBuildTool(){
        currentToolSelected = toolSelected.buildTool;
    }
    public void selectGlueTool(){
        currentToolSelected = toolSelected.glueTool;
    }
}
