using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class objectInteraction : MonoBehaviour
{
    toolBar toolBar;


    //selection box
    public Canvas canvas;
    public Image selectionBox; 
    private Vector3 startScreenPos;
    private BoxCollider worldCollider;
    private RectTransform rt; 
    private bool isSelecting;
    public Collider2D[] currentlySelectedObjects;
    

    void Start()
    {
        toolBar = GameObject.Find("Game Controller").GetComponent<toolBar>();

        if (canvas == null)
            canvas = FindObjectOfType<Canvas>();
 
        if (selectionBox != null)
        {
            //We need to reset anchors and pivot to ensure proper positioning
            rt = selectionBox.GetComponent<RectTransform>();
            rt.pivot = Vector2.one * .5f;
            rt.anchorMin = Vector2.one * .5f;
            rt.anchorMax = Vector2.one * .5f;
            selectionBox.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if(gameUtilities.ToolBar.currentToolSelected == toolBar.toolSelected.selectionBoxTool){
            if (Input.GetMouseButtonDown(0))
            {
                if (selectionBox == null)
                    return;
                //Storing these variables for the selectionBox
                startScreenPos = Input.mousePosition;
                isSelecting = true;
            }
    
            //If we never set the selectionBox variable in the inspector, we are simply not able to drag the selectionBox to easily select multiple objects. 'Regular' selection should still work
            if (selectionBox == null)
                return;
    
            //We finished our selection box when the key is released
            if (Input.GetMouseButtonUp(0))
            {
                Collider2D[] selectedColliders = Physics2D.OverlapBoxAll(rt.transform.TransformPoint(rt.transform.position), new Vector2(rt.transform.localScale.x, rt.transform.localScale.y), 0);  
                for(int i = 0; i < selectedColliders.Length; i++){
                   selectedColliders[i].isTrigger = true;
                }
                isSelecting = false;
            }
    
            selectionBox.gameObject.SetActive(isSelecting);
    
            if (isSelecting)
            {
                Bounds b = new Bounds();
                //The center of the bounds is inbetween startpos and current pos
                b.center = Vector3.Lerp(startScreenPos, Input.mousePosition, 0.5f);
                //We make the size absolute (negative bounds don't contain anything)
                b.size = new Vector3(Mathf.Abs(startScreenPos.x - Input.mousePosition.x),
                    Mathf.Abs(startScreenPos.y - Input.mousePosition.y),
                    0);
    
                //To display our selectionbox image in the same place as our bounds
                rt.position = b.center;
                rt.sizeDelta = canvas.transform.InverseTransformVector(b.size);

            }
        }
    }

}
