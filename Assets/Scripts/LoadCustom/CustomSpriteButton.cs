using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomSpriteButton : MonoBehaviour
{
    public Sprite customSprite;
    public GameObject Object;
    
    public void SetCustomSprite(){
        CustomSpriteManager.self.currentCustomSprite = customSprite;
    }

    public void SetSelectedObject(){
        BuildTool.self.UpdateSelectedObject(Object);
    }
}
