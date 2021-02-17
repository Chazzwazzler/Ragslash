using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragTool : MonoBehaviour
{
    private Vector3 screenPoint;
    private Vector3 offset;
    public GameObject objectUnderMouse;

    GameObject parentObject;

    bool draggingMouse;

    void Update()
    {
        if(ToolController.currentlySelectedTool == ToolController.Tools.dragTool  && !InputHelper.MouseOverUIObject){
            if(Input.GetKeyDown(Keybinds.usePrimaryToolFunction)){
                objectUnderMouse = InputHelper.GetObjectUnderMouse2D;
                
                for(int index = 0; index < InputHelper.GetSelectedObjects.Count; index ++){
                    if(objectUnderMouse == InputHelper.GetSelectedObjects[index]){
                        parentObject = new GameObject("Drag Parent");
                        parentObject.AddComponent(typeof(Rigidbody2D));
                        parentObject.GetComponent<Rigidbody2D>().isKinematic = true;
                        parentObject.AddComponent(typeof(Draggable));
                        for(int i = 0; i < InputHelper.GetSelectedObjects.Count; i ++){
                            InputHelper.GetSelectedObjects[i].transform.parent = parentObject.transform;
                            InputHelper.GetSelectedObjects[i].GetComponent<Rigidbody2D>().isKinematic = true;
                        }
                        objectUnderMouse = parentObject;
                    }
                }

                objectUnderMouse.GetComponent<Rigidbody2D>().isKinematic = false;

                screenPoint = Camera.main.WorldToScreenPoint(objectUnderMouse.transform.position);
                offset =  objectUnderMouse.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y,screenPoint.z));
                draggingMouse = true;

            }
            if(Input.GetKey(Keybinds.useSecondaryToolFunction) && objectUnderMouse.GetComponent<Draggable>() != null){
                objectUnderMouse.GetComponent<Rigidbody2D>().velocity = Vector3. zero;
                objectUnderMouse.GetComponent<Rigidbody2D>().angularVelocity = 0;
                objectUnderMouse.transform.Rotate(new Vector3(0,0,2), Space.World);
            }
            if(Input.GetKeyUp(Keybinds.usePrimaryToolFunction)){
                objectUnderMouse.GetComponent<Rigidbody2D>().isKinematic = false;
                draggingMouse = false;
                objectUnderMouse = null;

                Rigidbody2D[] childrenRigidbodies = parentObject.GetComponentsInChildren<Rigidbody2D>();
                for(int i = 0; i < childrenRigidbodies.Length; i ++){
                    childrenRigidbodies[i].isKinematic = false;
                }

                parentObject.transform.DetachChildren();
                Destroy(parentObject);
            }

            if(draggingMouse && objectUnderMouse.GetComponent<Draggable>() != null){
                Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
                Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;

                objectUnderMouse.GetComponent<Rigidbody2D>().velocity = (curPosition - objectUnderMouse.transform.position) * 10;
            }
        }
    }
}
