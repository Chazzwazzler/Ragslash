using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OriginalObjectPropertiesManager : MonoBehaviour
{
    public RigidbodyType2D originalRigidbodyState;
    public RigidbodyType2D currentRigidbodyState;

    public void SetProperties(){
        originalRigidbodyState = GetComponent<Rigidbody2D>().bodyType;
        currentRigidbodyState = originalRigidbodyState;
    }
}
