using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabSystem : MonoBehaviour
{
    public GameObject[] allTabs;

    public void SwitchTab(GameObject tab){
        for (int i = 0; i < allTabs.Length; i++)
        {
            if(allTabs[i] != tab){
                allTabs[i].SetActive(false);
            }
            else{
                allTabs[i].SetActive(true);
            }
        }
    }
}
