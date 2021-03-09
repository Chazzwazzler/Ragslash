using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomSpriteManager : MonoBehaviour
{
    public static CustomSpriteManager self;

    public Sprite currentCustomSprite;

    public GameObject customSpriteButton;

    List<Sprite> customSprites;

    void Start() {
        self = this;
        customSprites = LoadCustomImages.CustomSprites();
        for(int i = 0; i < customSprites.Count; i++){
            GameObject spawnedImage = (GameObject)Instantiate(customSpriteButton, transform.position, Quaternion.identity);
            spawnedImage.transform.SetParent(gameObject.transform);
            spawnedImage.GetComponent<Image>().overrideSprite = customSprites[i];
            spawnedImage.GetComponent<CustomSpriteButton>().customSprite = customSprites[i];
        }
    }
}
