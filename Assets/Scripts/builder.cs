using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class builder : MonoBehaviour
{
    public GameObject chosenObject;

    //settings
    public float gravityScale = 1;
    public float massScale = 1;
    public bool hasCollision = true;

    public float xScale = 1;
    public float yScale = 1;
    public float rotationAmount = 0;
    public bool lockPosition = false;
    public bool alignPosition = false;

    void Update() {
        GameObject objectUnderMouse = CheckForObjectUnderMouse();
        if(Input.GetMouseButton(0) && objectUnderMouse == null && EventSystem.current.IsPointerOverGameObject() == false){
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            GameObject placedObject = (GameObject)Instantiate(chosenObject, mousePos, Quaternion.identity);
            
            //settings - gravity
            if(placedObject.GetComponent<Rigidbody2D>() != null){
                if(placedObject.transform.childCount > 0){
                    foreach (Transform child in placedObject.transform)
                    {
                        if(child.gameObject.GetComponent<Rigidbody2D>() != null){
                            child.gameObject.GetComponent<Rigidbody2D>().gravityScale = gravityScale;
                        }
                        else if(child.childCount > 0){
                            foreach (Transform child2 in child)
                            {
                                child2.gameObject.GetComponent<Rigidbody2D>().gravityScale = gravityScale;
                            }
                        }
                    }
                }
                placedObject.GetComponent<Rigidbody2D>().gravityScale = gravityScale;
            }

            //settings - mass
            if(placedObject.GetComponent<Rigidbody2D>() != null){
                if(placedObject.transform.childCount > 0){
                    foreach (Transform child in placedObject.transform)
                    {
                        if(child.gameObject.GetComponent<Rigidbody2D>() != null){
                            child.gameObject.GetComponent<Rigidbody2D>().mass = massScale;
                        }
                        else if(child.childCount > 0){
                            foreach (Transform child2 in child)
                            {
                                child2.gameObject.GetComponent<Rigidbody2D>().mass = massScale;
                            }
                        }
                    }
                }
                placedObject.GetComponent<Rigidbody2D>().mass = massScale;
            }

            //settings - collision
            if(placedObject.GetComponent<Collider2D>() != null && hasCollision == false){
                if(placedObject.transform.childCount > 0){
                    foreach (Transform child in placedObject.transform)
                    {
                        if(child.gameObject.GetComponent<Collider2D>() != null){
                            placedObject.GetComponent<Collider2D>().isTrigger = true;
                        }
                        else if(child.childCount > 0){
                            foreach (Transform child2 in child)
                            {
                                placedObject.GetComponent<Collider2D>().isTrigger = true;
                            }
                        }
                    }
                }
                placedObject.GetComponent<Collider2D>().isTrigger = true;
            }

            //settings - scale
            placedObject.transform.localScale = new Vector3(xScale,yScale,0);

            //settings - rotation
            placedObject.transform.eulerAngles = new Vector3(0,0,rotationAmount);

            //setings - lock position
            if(lockPosition == true && placedObject.GetComponent<Rigidbody2D>() != null){
                Destroy(placedObject.GetComponent<Rigidbody2D>());
            }

            //settings - align position
            if(alignPosition == true){
                placedObject.transform.position = new Vector3(Mathf.Round(placedObject.transform.position.x),Mathf.Round(placedObject.transform.position.y), 0);
            }

        }

        if(Input.GetMouseButton(1) && objectUnderMouse != null && objectUnderMouse.tag != "Invincible"){
            if(objectUnderMouse.transform.root != null){
                Destroy(objectUnderMouse.transform.root.gameObject);
            }
            else{
                Destroy(objectUnderMouse);
            }
        }
    }

    GameObject CheckForObjectUnderMouse()
    {
        Vector2 touchPostion = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        RaycastHit2D hit2D = Physics2D.Raycast(touchPostion, Vector2.zero);
    
        return hit2D.collider != null ? hit2D.collider.gameObject : null;
    }

    public void changeSelectedObject(GameObject objectToChangeTo){
        chosenObject = objectToChangeTo;
    }

    //settings 
    public void setMass(InputField inputField){
        massScale = float.Parse(inputField.text);
    }
    public void setGravityModifier(InputField inputField){
        gravityScale = float.Parse(inputField.text);
    }
    public void toggleCollision(bool toggle){
        hasCollision = toggle;
    }
    
    public void setXScale(InputField inputField){
        xScale = float.Parse(inputField.text);
    }
    public void setYScale(InputField inputField){
        yScale = float.Parse(inputField.text);
    }
    public void setRotationAmount(InputField inputField){
        rotationAmount = float.Parse(inputField.text);
    }
    public void togglePositionLock(bool toggle){
        lockPosition = toggle;
    }
    public void toggleAlignment(bool toggle){
        alignPosition = toggle;
    }
}
