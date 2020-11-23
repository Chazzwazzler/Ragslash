using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    public Camera mainCamera;
    public float speed;
    void Update(){
        float moveInputX = Input.GetAxisRaw("Horizontal") * speed;
        float moveInputY = Input.GetAxisRaw("Vertical") * speed; 
        mainCamera.transform.Translate(new Vector3(moveInputX, moveInputY, 0)  * speed * Time.unscaledDeltaTime);

        float scrollInput = Input.GetAxisRaw("Mouse ScrollWheel") * speed;
        ZoomOrthoCamera(mainCamera.ScreenToWorldPoint(Input.mousePosition), scrollInput);

        if(mainCamera.orthographicSize < 0.1f){
            mainCamera.orthographicSize = 0.1f;
        }
    }

    void ZoomOrthoCamera(Vector3 zoomTowards, float amount)
     {
         // Calculate how much we will have to move towards the zoomTowards position
         float multiplier = (1.0f / mainCamera.orthographicSize * amount);
 
         // Move camera
         mainCamera.transform.position += (zoomTowards - transform.position) * multiplier;  

         mainCamera.orthographicSize-=amount;
     }
}
