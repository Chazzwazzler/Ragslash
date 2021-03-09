//The tool for placing and breaking stuff, so a tool for generally building

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildTool : MonoBehaviour
{
    public GameObject selectedObject;

    public static BuildTool self;

    private void Start() {
        self = this;
    }

    void Update()
    {
        if(ToolController.currentlySelectedTool == ToolController.Tools.buildTool && !InputHelper.MouseOverUIObject){
            
            if(ComponentSystemValues.self.alignOnPlacement == false){
                if(Input.GetKey(Keybinds.usePrimaryToolFunction)&& InputHelper.GetObjectUnderMouse2D == null){
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
            else{
                if(Input.GetKey(Keybinds.usePrimaryToolFunction)&& InputHelper.GetObjectAtPosition2D(CalculateClosest(InputHelper.MouseWorldPos)) == null){
                    Instantiate(selectedObject, CalculateClosest(InputHelper.MouseWorldPos), Quaternion.identity); 
                }
                if(Input.GetKey(Keybinds.useSecondaryToolFunction) && InputHelper.GetObjectAtPosition2D(CalculateClosest(InputHelper.MouseWorldPos)).GetComponent<Destroyable>() != null){
                    for(int i = 0; i < InputHelper.GetSelectedObjects.Count; i ++){
                        if(InputHelper.GetObjectAtPosition2D(CalculateClosest(InputHelper.MouseWorldPos)) == InputHelper.GetSelectedObjects[i]){
                            while(InputHelper.GetSelectedObjects.Count > 0){
                                Destroy(InputHelper.GetSelectedObjects[0]);
                                InputHelper.GetSelectedObjects.Remove(InputHelper.GetSelectedObjects[0]);
                            }
                        }
                    }
                    Destroy(InputHelper.GetObjectAtPosition2D(CalculateClosest(InputHelper.MouseWorldPos)).transform.root.gameObject);
                }
            }
        }
    }

    public void UpdateSelectedObject(GameObject newObject){
        selectedObject = newObject;

        if(selectedObject.GetComponent<UniqueComponents>() != null){
            UniqueComponentManager.self.ChangeComponents(selectedObject.GetComponent<UniqueComponents>().components);
        }
        else{
            UniqueComponentManager.self.ChangeComponents(null);
        }
        
        Debug.Log("Changed the object to place!");
    }

    public Vector2 CalculateClosest(Vector2 pos)
    {
        float xRemainder = pos.x % ComponentSystemValues.self.sizeX;
        float yRemainder = pos.y % ComponentSystemValues.self.sizeY;
        
        float yOffset = (yRemainder >= ComponentSystemValues.self.sizeY * 0.5f) ? ComponentSystemValues.self.sizeY - yRemainder : -yRemainder;
        float xOffset = (xRemainder >= ComponentSystemValues.self.sizeX * 0.5f) ? ComponentSystemValues.self.sizeX - xRemainder : -xRemainder;

        float yOffset2 = ComponentSystemValues.self.sizeY == 1 ? 0 : ComponentSystemValues.self.sizeY * ComponentSystemValues.self.sizeY;
        float xOffset2 = ComponentSystemValues.self.sizeX == 1 ? 0 : ComponentSystemValues.self.sizeY * ComponentSystemValues.self.sizeY;
        
        return new Vector2(pos.x + xOffset + xOffset2, pos.y + yOffset + yOffset2);
    }
}
