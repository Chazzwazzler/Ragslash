using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhysicsComponentManager : MonoBehaviour
{
    public void hasPhysicsComponent(bool toggle){
        ComponentSystemValues.self.hasPhysicsComponent = toggle;
    }
    public void changeMass(InputField input){
        ComponentSystemValues.self.massScale = float.Parse(input.text);
    }
    public void changeGravity(InputField input){
        ComponentSystemValues.self.gravityScale = float.Parse(input.text);
    }
}
