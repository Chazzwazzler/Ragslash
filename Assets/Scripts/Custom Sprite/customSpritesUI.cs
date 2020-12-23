using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class customSpritesUI : MonoBehaviour
{
    public GameObject imagePrefab;
    List<Sprite> customSprites;
    // Start is called before the first frame update
    void Start()
    {
        customSprites = loadImages.CustomSprites();
        for(int i = 0; i < customSprites.Count; i++){
            GameObject spawnedImage = (GameObject)Instantiate(imagePrefab, transform.position, Quaternion.identity);
            spawnedImage.transform.SetParent(gameObject.transform);
            spawnedImage.GetComponent<Image>().overrideSprite = customSprites[i];
            spawnedImage.GetComponent<customSpriteUIButton>().customSprite = customSprites[i];
        }
    }
}
