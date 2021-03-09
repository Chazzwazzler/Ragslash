using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomSpriteObject : MonoBehaviour
{
    private void Start() {
        GetComponent<SpriteRenderer>().sprite = CustomSpriteManager.self.currentCustomSprite;
        GetComponent<PixelCollider2D>().Regenerate();
    }
}
