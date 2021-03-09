using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeTool : MonoBehaviour
{
    bool isFrozen = false;
    private void Update() {
        if(!InputHelper.MouseOverUIObject){
            if(Input.GetKeyDown(KeyCode.F)){
                SwitchMode();
            }
        }
    }

    public void SwitchMode(){
        isFrozen= !isFrozen;

        if(isFrozen){
            InputHelper.GetObjectUnderMouse2D.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            InputHelper.GetObjectUnderMouse2D.GetComponent<OriginalObjectPropertiesManager>().currentRigidbodyState = RigidbodyType2D.Static;
        }
        else{
            InputHelper.GetObjectUnderMouse2D.GetComponent<Rigidbody2D>().bodyType = InputHelper.GetObjectUnderMouse2D.GetComponent<OriginalObjectPropertiesManager>().originalRigidbodyState;
            InputHelper.GetObjectUnderMouse2D.GetComponent<OriginalObjectPropertiesManager>().currentRigidbodyState = InputHelper.GetObjectUnderMouse2D.GetComponent<OriginalObjectPropertiesManager>().originalRigidbodyState;
        }
    }
}
