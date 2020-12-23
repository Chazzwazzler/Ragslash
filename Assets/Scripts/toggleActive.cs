using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toggleActive : MonoBehaviour
{
    public GameObject activeTogglingObject;
        
    public void toggleEnabled()
    {
         activeTogglingObject.SetActive(!activeTogglingObject.activeSelf);
    }
}
