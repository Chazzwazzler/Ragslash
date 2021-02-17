using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlueTool : MonoBehaviour
{
    public GameObject firstObject = null;
    public GameObject secondObject = null;

    void Update()
    {
        if(ToolController.currentlySelectedTool == ToolController.Tools.glueTool){
            if(Input.GetKeyDown(Keybinds.useSecondaryToolFunction)){
                firstObject = null;
                secondObject = null;
            }
            if(Input.GetKeyDown(Keybinds.usePrimaryToolFunction)){
                if(InputHelper.GetSelectedObjects.Contains(InputHelper.GetObjectUnderMouse2D)){
                    for (int i = 0; i < InputHelper.GetSelectedObjects.Count; i++)
                    {
                        for (int i2 = 0;i2 < InputHelper.GetSelectedObjects.Count;i2++)
                        {
                            if(i2 != i){
                                FixedJoint2D joint2D = InputHelper.GetSelectedObjects[i2].AddComponent(typeof(FixedJoint2D)) as FixedJoint2D;
                                joint2D.connectedBody = InputHelper.GetSelectedObjects[i].GetComponent<Rigidbody2D>();
                                joint2D.dampingRatio = 1;
                                joint2D.frequency = 0;
                                joint2D.enableCollision = true;
                            }
                        }
                    }
                }
                else{
                    if(firstObject == null && InputHelper.GetObjectUnderMouse2D.tag != "Invincible"){
                        firstObject = InputHelper.GetObjectUnderMouse2D;
                    }
                    else if(secondObject == null && InputHelper.GetObjectUnderMouse2D.tag != "Invincible"){
                        secondObject = InputHelper.GetObjectUnderMouse2D;
                        FixedJoint2D joint2D = secondObject.AddComponent(typeof(FixedJoint2D)) as FixedJoint2D;
                        joint2D.connectedBody = firstObject.GetComponent<Rigidbody2D>();
                        joint2D.dampingRatio = 1;
                        joint2D.frequency = 0;
                        joint2D.enableCollision = true;
                        firstObject = secondObject;
                        secondObject = null;
                    }
                }
            }
        }
    }
}
