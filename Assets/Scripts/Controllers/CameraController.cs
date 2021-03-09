using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float speed;
    private Vector3 origin; // place where mouse is first pressed
    private Vector3 difference; // change in position of mouse relative to origin

    void Update(){

        if(InputHelper.MouseOverUIObject){ return;}

        if(Input.GetKeyDown(Keybinds.panCamera)){
            origin = MousePos();
        }
        if(Input.GetKey(Keybinds.panCamera)){
            difference = MousePos() - InputHelper.MainCamera.transform.position;
             InputHelper.MainCamera.transform.position = origin - difference;
        }

        float moveInputX = Input.GetAxisRaw("Horizontal") * speed;
        float moveInputY = Input.GetAxisRaw("Vertical") * speed; 
        InputHelper.MainCamera.transform.Translate(new Vector3(moveInputX, moveInputY, 0)  * speed * Time.unscaledDeltaTime);

        if(!InputHelper.MouseOverUIObject){
            float scrollInput = Input.GetAxisRaw("Mouse ScrollWheel") * speed;
            ZoomOrthoCamera(InputHelper.MainCamera.ScreenToWorldPoint(Input.mousePosition), scrollInput);

            if(InputHelper.MainCamera.orthographicSize < 3f){
                InputHelper.MainCamera.orthographicSize = 3f;
            }
        }
    }

    void ZoomOrthoCamera(Vector3 zoomTowards, float amount)
     {
         // Calculate how much we will have to move towards the zoomTowards position
         float multiplier = (1.0f / InputHelper.MainCamera.orthographicSize * amount);
        InputHelper.MainCamera.orthographicSize-=amount;

        if(InputHelper.MainCamera.orthographicSize > 3f){
            // Move camera
            InputHelper.MainCamera.transform.position += (zoomTowards - transform.position) * multiplier;  
        }
     }

    Vector3 MousePos()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
