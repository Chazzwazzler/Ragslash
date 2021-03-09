using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniqueComponentManager : MonoBehaviour
{
    public static UniqueComponentManager self;

    private void Awake() {
        self = this;
    }
    GameObject currentlySelectedObject;
    public void ClearComponents(){
        foreach (Transform child in transform) {
            GameObject.Destroy(child.gameObject);
        }
    }
    public void ChangeComponents(GameObject[] components){
        if(BuildTool.self.selectedObject != currentlySelectedObject){
            ClearComponents();
            for (int i = 0; i < components.Length; i++)
            {   
                AddComponent(components[i]);
            }
            currentlySelectedObject = BuildTool.self.selectedObject;
        }
    }
    public void AddComponent(GameObject component){
        GameObject spawnedComponent = (GameObject)Instantiate(component,transform.position,Quaternion.identity);
        spawnedComponent.transform.SetParent(transform);
    }
}
