using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacePowder : MonoBehaviour
{
    public GameObject selectedObject;

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKey(Keybinds.usePrimaryToolFunction) && InputHelper.GetObjectUnderMouse2D == null){
            Instantiate(selectedObject, InputHelper.MouseWorldPos, Quaternion.identity);
        }
        if(Input.GetKey(Keybinds.useSecondaryToolFunction) && InputHelper.GetObjectUnderMouse2D.GetComponent<Destroyable>() != null){
                Destroy(InputHelper.GetObjectUnderMouse2D.transform.root.gameObject);
        }
    }
}
