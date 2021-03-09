using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTool : MonoBehaviour
{
    public GameObject followObject;
    public Camera mainCamera;

    void Update()
    {
        if(followObject != null){
            mainCamera.transform.position = new Vector3(followObject.transform.position.x,followObject.transform.position.y, mainCamera.transform.position.z);
        }
        if(ToolController.currentlySelectedTool == ToolController.Tools.followTool){
            if(Input.GetKeyDown(Keybinds.usePrimaryToolFunction) && !InputHelper.MouseOverUIObject){
                followObject = InputHelper.GetObjectUnderMouse2D;
            }
        }
    }
}
