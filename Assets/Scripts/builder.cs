using UnityEngine;
using System;
using UnityEngine.UI;

public class builder : MonoBehaviour
{
    public toolBar toolBar;
    public GameObject chosenObject;

    //Custom Sprite
    public bool usesCustomSprite;
    public Sprite customSprite;

    //Components
    public bool hasAppearanceComponent = true;
    public bool hasPhysicsComponent = true;
    public bool hasCollisionComponent = true;
    public bool hasAlignmentComponent = false;
    public bool hasLayerComponent = false;

    //Transform Component
    public float sizeX = 1.0f;
    public float sizeY = 1.0f;
    public float rotation = 0f;

    //Appearance Component
    public Color customColor;
    public ColorPicker colorPicker;

    //Physics Component
    public float massScale = 1.0f;
    public float gravityScale = 1.0f;

    //Layer Component
    public int layer;

    //Ragdol Component
    public float bloodDurationModifier = 1f;
    public bool hasBlood = true;
    public bool hasJoints = true;

    void Update() {
        customColor = colorPicker.CurrentColor;
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
                            
                            //appearance component
                            if(!hasAppearanceComponent){
                                if(placedObject.GetComponent<SpriteRenderer>() != null){
                                    Destroy(placedObject.GetComponent<SpriteRenderer>());
                                }
                                SpriteRenderer[] renderers = placedObject.GetComponentsInChildren<SpriteRenderer>();
                                for(int i = 0; i < renderers.Length; i++){
                                    Destroy(renderers[i]);
                                }
                            }
                            if(placedObject.GetComponent<SpriteRenderer>() != null){
                                placedObject.GetComponent<SpriteRenderer>().material.color = customColor;
                            }
                            SpriteRenderer[] rendererColors = placedObject.GetComponentsInChildren<SpriteRenderer>();
                            for(int i = 0; i < rendererColors.Length; i++){
                                rendererColors[i].material.color = customColor;
                            }

                            //physics component
                            if(placedObject.GetComponent<Rigidbody2D>() != null){
                                placedObject.GetComponent<Rigidbody2D>().isKinematic = !hasPhysicsComponent;
                                placedObject.GetComponent<Rigidbody2D>().gravityScale = gravityScale;
                                placedObject.GetComponent<Rigidbody2D>().mass = massScale;
                            }
                            Rigidbody2D[] physicsActives = placedObject.GetComponentsInChildren<Rigidbody2D>();
                            for(int i = 0; i < physicsActives.Length; i++){
                                physicsActives[i].isKinematic = !hasPhysicsComponent;
                                physicsActives[i].gravityScale = gravityScale;
                                physicsActives[i].mass = massScale;
                            }

                            //collision component
                            if(placedObject.GetComponent<Collider2D>() != null){
                                placedObject.GetComponent<Collider2D>().isTrigger = !hasCollisionComponent;
                            }
                            Collider2D[] colliderActives = placedObject.GetComponentsInChildren<Collider2D>();
                            for(int i = 0; i < colliderActives.Length; i++){
                                colliderActives[i].isTrigger = !hasCollisionComponent;
                            }

                            //alignment component
                            if(hasAlignmentComponent){
                                placedObject.transform.position = new Vector2((float)Math.Round(placedObject.transform.position.x),(float)Math.Round(placedObject.transform.position.y));
                            }

                            //transform component
                            placedObject.transform.localScale = new Vector2(sizeX, sizeY);
                            placedObject.transform.rotation = Quaternion.Euler(0,0,rotation);

                            //layer component
                            if(hasLayerComponent){
                                placedObject.GetComponent<SpriteRenderer>().sortingOrder = layer;
                                SpriteRenderer[] renderers = placedObject.GetComponentsInChildren<SpriteRenderer>();
                                for(int i = 0; i < renderers.Length; i++){
                                    renderers[i].sortingOrder = layer;
                                }
                            }

                            //custom sprite
                            if(usesCustomSprite){
                                placedObject.GetComponent<SpriteRenderer>().sprite = customSprite;
                                Destroy(placedObject.GetComponent<PolygonCollider2D>());

                                if(hasCollisionComponent){
                                    placedObject.AddComponent(typeof(PolygonCollider2D));
                                }
                            }

                            //ragdoll
                            blood[] bloodComponents = placedObject.GetComponentsInChildren<blood>();
                            for(int i = 0; i < bloodComponents.Length; i++){
                                bloodComponents[i].bloodDurationModifier = bloodDurationModifier;
                                if(!hasBlood){
                                    Destroy(bloodComponents[i]);
                                }
                            }
                            
                            if(!hasJoints){
                                HingeJoint2D[] hingeComponents = placedObject.GetComponentsInChildren<HingeJoint2D>();
                                for(int i = 0; i < hingeComponents.Length; i++){
                                    Destroy(hingeComponents[i]);
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

    //has components
    public void HasAppearanceComponent(bool hasComponent){
        hasAppearanceComponent = hasComponent;
    }
    public void HasPhysicsComponent(bool hasComponent){
        hasPhysicsComponent = hasComponent;
    }
    public void HasCollisionComponent(bool hasComponent){
        hasCollisionComponent = hasComponent;
    }
    public void HasAlignmentComponent(bool hasComponent){
        hasAlignmentComponent = hasComponent;
    }
    public void HasLayerComponent(bool hasComponent){
        hasLayerComponent = hasComponent;
    }

    //physics component
    public void changeMassScale(InputField input){
        massScale = float.Parse(input.text);
    }
    public void changeGravityScale(InputField input){
        gravityScale = float.Parse(input.text);
    }

    //transform component
    public void changeXSize(InputField input){
        sizeX = float.Parse(input.text);
    }
    public void changeYSize(InputField input){
        sizeY = float.Parse(input.text);
    }
    public void changeRotation(InputField input){
        rotation = float.Parse(input.text);
    }

    //layer component
    public void changeLayer(InputField input){
        layer = int.Parse(input.text);
    }

    //ragdoll component
    public void changeHasBlood(Toggle toggle){
        hasBlood = toggle;
    }
    public void changeHasJoints(Toggle toggle){
        hasJoints = toggle;
    }
    public void changeBloodDurationModifier(InputField input){
        bloodDurationModifier = float.Parse(input.text);
    }

    //custom sprite
    public void UsesCustomSprite(bool useSprite){
        usesCustomSprite = useSprite;
    }
    public void ChangeCustomSprite(Sprite changedCustomSprite){
        customSprite = changedCustomSprite;
    }
}
