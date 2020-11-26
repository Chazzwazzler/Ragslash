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

    public void selectDragTool(){
        currentToolSelected = toolSelected.dragTool;
    }
    public void selectBuildTool(){
        currentToolSelected = toolSelected.buildTool;
    }
    public void selectRotateTool(){
        currentToolSelected = toolSelected.rotateTool;
    }
    public void selectScaleTool(){
        currentToolSelected = toolSelected.scaleTool;
    }
    public void selectSelectTool(){
        currentToolSelected = toolSelected.selectTool;
    }
    public void selectSelectionBoxTool(){
        currentToolSelected = toolSelected.selectionBoxTool;
    }
    public void selectGlueTool(){
        currentToolSelected = toolSelected.glueTool;
    }
}
