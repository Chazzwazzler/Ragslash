//The tool for placing and breaking stuff, so a tool for generally building

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildTool : MonoBehaviour
{
    public GameObject selectedObject;

    void Update()
    {
        if(ToolController.currentlySelectedTool == ToolController.Tools.buildTool && !InputHelper.MouseOverUIObject){
            if(Input.GetKey(Keybinds.usePrimaryToolFunction) && InputHelper.GetObjectUnderMouse2D == null){
                Instantiate(selectedObject, InputHelper.MouseWorldPos, Quaternion.identity);
            }
            if(Input.GetKey(Keybinds.useSecondaryToolFunction) && InputHelper.GetObjectUnderMouse2D.GetComponent<Destroyable>() != null){
                for(int i = 0; i < InputHelper.GetSelectedObjects.Count; i ++){
                    if(InputHelper.GetObjectUnderMouse2D == InputHelper.GetSelectedObjects[i]){
                        while(InputHelper.GetSelectedObjects.Count > 0){
                            Destroy(InputHelper.GetSelectedObjects[0]);
                            InputHelper.GetSelectedObjects.Remove(InputHelper.GetSelectedObjects[0]);
                        }
                    }
                }
                Destroy(InputHelper.GetObjectUnderMouse2D.transform.root.gameObject);
            }
        }
    }

    public void UpdateSelectedObject(GameObject newObject){
        selectedObject = newObject;
        Debug.Log("Changed the object to place!");
    }
}
