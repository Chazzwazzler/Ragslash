using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AppearanceComponentManager : MonoBehaviour
{
    public void hasAppearanceComponent(bool toggle){
        ComponentSystemValues.self.hasAppearanceComponent = toggle;
    }
    public void changeColor(ColorPicker picker){
        ComponentSystemValues.self.customColor = picker.CurrentColor;
    }
}
