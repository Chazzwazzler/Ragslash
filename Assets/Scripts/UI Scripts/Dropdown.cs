using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dropdown : MonoBehaviour
{
    public GameObject objectToOpen;

    public Sprite openedSprite;
    public Sprite closedSprite;
    
    public bool changeSprite = true;

    bool isOpen = false;

    public void SwitchDropdownMode(){
        isOpen = !isOpen;

        if(isOpen){
            objectToOpen.SetActive(true);
            if(changeSprite){
                GetComponent<Image>().sprite = openedSprite;
            }
        }
        else{
            objectToOpen.SetActive(false);
            if(changeSprite){
                GetComponent<Image>().sprite = closedSprite;            
            }
        }
    }
}
