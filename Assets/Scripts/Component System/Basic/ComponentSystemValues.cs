using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponentSystemValues : MonoBehaviour
{
    public static ComponentSystemValues self;
    private void Awake() {
        self = this;
    }

    //Components
    public bool hasAppearanceComponent = true;
    public bool hasPhysicsComponent = true;
    public bool hasCollisionComponent = true;

    //Transform Component
    public float sizeX = 1.0f;
    public float sizeY = 1.0f;
    public float rotation = 0f;
    public bool alignOnPlacement = false;

    //Appearance Component
    public Color customColor;

    //Physics Component
    public float massScale = 1.0f;
    public float gravityScale = 1.0f;
}
