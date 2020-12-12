using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class glue : MonoBehaviour
{
    toolBar toolBar;
    public GameObject firstObject = null;
    public GameObject secondObject = null;

    void Start()
    {
        toolBar = GameObject.Find("Game Controller").GetComponent<toolBar>();
    }

    void Update()
    {
        if(toolBar.currentToolSelected == toolBar.toolSelected.glueTool){
            if(Input.GetKeyDown(KeyCode.Return)){
                firstObject = null;
                secondObject = null;
            }
            if(Input.GetMouseButtonDown(0)){
                Vector2 touchPostion = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                RaycastHit2D hit2D = Physics2D.Raycast(touchPostion, Vector2.zero);

                if(firstObject == null && hit2D.collider.gameObject.tag != "Invincible"){
                    firstObject = hit2D.collider.gameObject;
                }
                else if(secondObject == null && hit2D.collider.gameObject.tag != "Invincible"){
                    secondObject = hit2D.collider.gameObject;
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
