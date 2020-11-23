using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dropdown : MonoBehaviour
{
    public GameObject[] openObjects;
    public GameObject[] closeObjects;

    public void openAndClose(){
        for (int i = 0; i < openObjects.Length; i++)
        {
            openObjects[i].SetActive(true);
        }
        for (int i = 0; i < closeObjects.Length; i++)
        {
            closeObjects[i].SetActive(false);
        }
    }
}
