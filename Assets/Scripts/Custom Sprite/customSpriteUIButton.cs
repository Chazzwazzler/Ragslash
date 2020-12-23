using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class customSpriteUIButton : MonoBehaviour
{
    public Sprite customSprite;
    public builder Builder;

    void Start()
    {
        Builder = gameUtilities.Builder;
        gameObject.GetComponent<Button>().onClick.AddListener(setCustomSprite);
    }

    public void setCustomSprite(){
        Builder.ChangeCustomSprite(customSprite);
        Builder.UsesCustomSprite(true);
    }
}
