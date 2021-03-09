using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionTool : MonoBehaviour
{
    public GameObject selectionBox;
    Vector3 origin;
    public List<GameObject> selectedObjects;

    void Update()
    {  
        if(InputHelper.MouseOverUIObject){return;}

        if(ToolController.currentlySelectedTool == ToolController.Tools.selectionTool){
            if(Input.GetKeyDown(Keybinds.usePrimaryToolFunction)){
                selectionBox.transform.position = InputHelper.MouseWorldPos;
                origin = MousePos();
                selectionBox.SetActive(true);
                for(int i = 0; i < selectedObjects.Count; i++){
                    selectedObjects[i].GetComponent<SpriteRenderer>().material.color = new Color(selectedObjects[i].GetComponent<SpriteRenderer>().material.color.r,selectedObjects[i].GetComponent<SpriteRenderer>().material.color.g,selectedObjects[i].GetComponent<SpriteRenderer>().material.color.b, 1f);
                }
                selectedObjects = new List<GameObject>();
            }
            if(Input.GetKey(Keybinds.usePrimaryToolFunction)){
                Vector3 midpoint = Vector3.Lerp(origin, MousePos(), 0.5f);
                selectionBox.transform.position = new Vector3(midpoint.x, midpoint.y, 0);
                selectionBox.transform.localScale = new Vector3(Mathf.Abs(origin.x - MousePos().x), Mathf.Abs(origin.y - MousePos().y), 1);
            }
            if(Input.GetKeyUp(Keybinds.usePrimaryToolFunction)){
                Collider2D[] selectedColliders = Physics2D.OverlapBoxAll(selectionBox.transform.position, selectionBox.transform.localScale, selectionBox.transform.rotation.z);
                for(int i = 0; i < selectedColliders.Length; i++){
                    if(selectedColliders[i].GetComponent<Selectable>() != null){
                        selectedColliders[i].gameObject.GetComponent<SpriteRenderer>().material.color = new Color(selectedColliders[i].gameObject.GetComponent<SpriteRenderer>().material.color.r,selectedColliders[i].gameObject.GetComponent<SpriteRenderer>().material.color.g,selectedColliders[i].gameObject.GetComponent<SpriteRenderer>().material.color.b, 0.6f);
                        selectedObjects.Add(selectedColliders[i].gameObject);
                    }
                }
                selectionBox.SetActive(false);
            }
        }
        else{
            selectionBox.SetActive(false);
        }     
    }

    Vector3 MousePos()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
