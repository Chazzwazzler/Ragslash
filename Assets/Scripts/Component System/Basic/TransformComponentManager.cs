using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransformComponentManager : MonoBehaviour
{ 
    public void ChangeXSize(InputField input){
        ComponentSystemValues.self.sizeX = float.Parse(input.text);
    }
    public void ChangeYSize(InputField input){
        ComponentSystemValues.self.sizeY = float.Parse(input.text);
    }
    public void ChangeRotation(InputField input){
        ComponentSystemValues.self.rotation = float.Parse(input.text);
    }
    public void ChangeAlignOnPlacement(Toggle toggle){
        ComponentSystemValues.self.alignOnPlacement = toggle;
    }
}
