using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectComponentManager : MonoBehaviour
{
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

    private void Start() {
        hasAppearanceComponent = ComponentSystemValues.self.hasAppearanceComponent;
        hasPhysicsComponent =  ComponentSystemValues.self.hasPhysicsComponent;
        hasCollisionComponent =  ComponentSystemValues.self.hasCollisionComponent;

        sizeX = ComponentSystemValues.self.sizeX;
        sizeY = ComponentSystemValues.self.sizeY;
        rotation = ComponentSystemValues.self.rotation;
        alignOnPlacement = ComponentSystemValues.self.alignOnPlacement;

        customColor = ComponentSystemValues.self.customColor;

        massScale = ComponentSystemValues.self.massScale;
        gravityScale = ComponentSystemValues.self.gravityScale;

        GetComponent<SpriteRenderer>().enabled = hasAppearanceComponent;
        GetComponent<Rigidbody2D>().isKinematic = !hasPhysicsComponent;
        GetComponent<Collider2D>().isTrigger = !hasCollisionComponent;

        transform.localScale = new Vector2(sizeX, sizeY);
        transform.eulerAngles = new Vector3(0,0, rotation);

        GetComponent<SpriteRenderer>().color = customColor;

        GetComponent<Rigidbody2D>().mass = GetComponent<Rigidbody2D>().mass * massScale;
        GetComponent<Rigidbody2D>().gravityScale = gravityScale;

        GetComponent<OriginalObjectPropertiesManager>().SetProperties();
    }
}
