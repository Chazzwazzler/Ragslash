//The class containing important things for all tool classes

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolController : MonoBehaviour
{
    public enum Tools{buildTool, dragTool, selectionTool, glueTool, followTool};
    public static Tools currentlySelectedTool = Tools.buildTool;
    
    public void changeTool(ToolSelector toolToChangeTo){
        currentlySelectedTool = toolToChangeTo.toolToSelect;
    }
}
