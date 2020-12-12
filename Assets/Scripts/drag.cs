using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drag : MonoBehaviour
{
    toolBar toolBar;
    private Vector3 screenPoint;
    private Vector3 offset;
    bool isKinematicOriginal;

    void Start()
    {
        toolBar = GameObject.Find("Game Controller").GetComponent<toolBar>();
        isKinematicOriginal = GetComponent<Rigidbody2D>().isKinematic;
    }

    void OnMouseDown()
    {
        if(toolBar.currentToolSelected == toolBar.toolSelected.dragTool){
            screenPoint = Camera.main.WorldToScreenPoint(transform.position);
            offset =  transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y,screenPoint.z));
        }
    }

    void OnMouseDrag()
    {
        if(toolBar.currentToolSelected == toolBar.toolSelected.dragTool){
            Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
            GetComponent<Rigidbody2D>().MovePosition(curPosition);
            GetComponent<Rigidbody2D>().isKinematic = true;
        }
    }
    void OnMouseUp()
    {
        GetComponent<Rigidbody2D>().isKinematic = isKinematicOriginal;
    }
}
