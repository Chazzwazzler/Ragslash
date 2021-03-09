using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionComponentManager : MonoBehaviour
{
    public void hasCollisionComponent(bool toggle){
        ComponentSystemValues.self.hasCollisionComponent = toggle;
    }
}
