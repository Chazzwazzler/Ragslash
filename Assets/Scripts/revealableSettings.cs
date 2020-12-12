using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class revealableSettings : MonoBehaviour
{
    builder builder;
    public GameObject settingsUI;
    public GameObject Object;
    void Start()
    {
        builder = GameObject.Find("Game Controller").GetComponent<builder>();
    }
    void Update()
    {
        if(builder.chosenObject == Object){
            settingsUI.SetActive(true);
        }
        else{
            settingsUI.SetActive(false);
        }
    }
}
