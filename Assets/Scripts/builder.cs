using UnityEngine;
using UnityEngine.UI;

public class builder : MonoBehaviour
{
    public toolBar toolBar;
    public GameObject chosenObject;

    //settings
    public ColorPicker picker;


    //rigidbody 2d
    public float gravityScale = 1;
    public float massScale = 1;
    public bool lockPosition = false;

    //collider 2d
    public bool hasCollision = true;

    //transform
    public float xScale = 1;
    public float yScale = 1;
    public float rotationAmount = 0;
    public bool alignPosition = false;

    //hinge joint 2d
    public float strengthModifier;
    public bool hasJoints = true;

    //blood
    public float bloodDurationModifier;
    public bool hasBlood = true;

    void Update() {
        if(toolBar.currentToolSelected == toolBar.toolSelected.buildTool){        
            //checks if the mouse is not over the UI
            if(gameUtilities.MouseOverUIObject != true){
                //If left click, place
                if(Input.GetMouseButton(0)){
                    //Check if anything is under the mouse
                    GameObject objectUnderMouse = gameUtilities.GetObjectUnderMouse2D();
                        //if not, place the object that is chosen
                        if(objectUnderMouse == null){
                            Vector2 mousePos = gameUtilities.MouseWorldPos;
                            GameObject placedObject = (GameObject)Instantiate(chosenObject, mousePos, Quaternion.identity);

                            //modify the components of children//

                            //rigidbody 2d
                            if(placedObject.transform.childCount > 0){
                                Rigidbody2D[] childrenRb = placedObject.GetComponentsInChildren<Rigidbody2D>();
                                for (int rbIndex = 0; rbIndex < childrenRb.Length; rbIndex++)
                                {
                                    childrenRb[rbIndex].gravityScale = gravityScale;
                                    childrenRb[rbIndex].mass = massScale;
                                    childrenRb[rbIndex].isKinematic = lockPosition;
                                }
                            }
                            placedObject.GetComponent<Rigidbody2D>().gravityScale = gravityScale;
                            placedObject.GetComponent<Rigidbody2D>().mass = massScale;
                            placedObject.GetComponent<Rigidbody2D>().isKinematic = lockPosition;
                            
                            //collider 2d
                            if(placedObject.transform.childCount > 0){
                                Collider2D[] childrenCol = placedObject.GetComponentsInChildren<Collider2D>();
                                for (int colIndex = 0; colIndex < childrenCol.Length; colIndex++)
                                {
                                    childrenCol[colIndex].isTrigger = hasCollision;
                                }
                            }
                            placedObject.GetComponent<Collider2D>().isTrigger = !hasCollision;

                            //transform
                            if(placedObject.transform.childCount > 0){
                                Transform[] childrenTransform = placedObject.GetComponentsInChildren<Transform>();
                                for (int transformIndex = 0; transformIndex < childrenTransform.Length; transformIndex++)
                                {
                                    childrenTransform[transformIndex].localScale = new Vector3(xScale, yScale, 0);
                                    childrenTransform[transformIndex].eulerAngles = new Vector3(0,0,rotationAmount);
                                }
                            }
                            placedObject.transform.position = new Vector3(Mathf.Round(placedObject.transform.position.x), Mathf.Round(placedObject.transform.position.y), 0);

                            //hinge joint 2d
                            if(placedObject.GetComponent<HingeJoint2D>()!=null || placedObject.GetComponentsInChildren<HingeJoint2D>() != null){
                                HingeJoint2D[] childrenHinge = placedObject.GetComponentsInChildren<HingeJoint2D>();
                                for (int hingeIndex = 0; hingeIndex < childrenHinge.Length; hingeIndex++)
                                {
                                    childrenHinge[hingeIndex].breakForce += (100 * strengthModifier);
                                    if(hasJoints == false){
                                        Destroy(childrenHinge[hingeIndex]);
                                    }
                                }
                                if(placedObject.GetComponent<HingeJoint2D>()!= null){
                                    placedObject.GetComponent<HingeJoint2D>().breakForce += (100 * strengthModifier);
                                    if(hasJoints == false){
                                        Destroy(placedObject.GetComponent<HingeJoint2D>());
                                    }
                                }
                            }

                            //blood
                            if(placedObject.GetComponent<blood>() != null || placedObject.GetComponentsInChildren<blood>() != null){
                                blood[] childrenBlood = placedObject.GetComponentsInChildren<blood>();
                                for(int bloodIndex = 0; bloodIndex < childrenBlood.Length; bloodIndex++){
                                    childrenBlood[bloodIndex].bloodDurationModifier = bloodDurationModifier;
                                    if(hasBlood == false){
                                        Destroy(childrenBlood[bloodIndex]);
                                    }
                                }
                                if(placedObject.GetComponent<blood>() != null){
                                    placedObject.GetComponent<blood>().bloodDurationModifier = bloodDurationModifier;
                                    if(hasBlood == false){
                                        Destroy(placedObject.GetComponent<blood>());
                                    }
                                }
                            }
                        }
                        //if so, return
                        else{
                            return;
                        }
                }
                //If right click, destroy
                if(Input.GetMouseButton(1)){
                    //Find the GameObject under the mouse
                    GameObject objectUnderMouse = gameUtilities.GetObjectUnderMouse2D();
                    if(objectUnderMouse != null){
                        //check if doesn't have the Invincible tag
                        if(objectUnderMouse.tag != "Invincible"){
                            //if so, destroy
                            Destroy(objectUnderMouse.transform.root.gameObject);
                        }
                        else{
                            //if not, return
                            return;
                        }
                    }
                }   
            }
        }
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

    public void setStrengthModifier(InputField inputField){
        strengthModifier = float.Parse(inputField.text);
    }
    public void setBloodDurationModifier(InputField inputField){
        bloodDurationModifier = float.Parse(inputField.text);
    }
    public void toggleBlood(bool toggle){
        hasBlood = toggle;
    }
    public void toggleJoints(bool toggle){
        hasJoints = toggle;
    }
}
