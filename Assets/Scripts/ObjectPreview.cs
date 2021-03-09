using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPreview : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    public BuildTool buildTool;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(ToolController.currentlySelectedTool == ToolController.Tools.buildTool){
            spriteRenderer.sprite = buildTool.selectedObject.GetComponent<SpriteRenderer>().sprite;
        }
        else{
            spriteRenderer.sprite = null;
        }
        transform.localScale = new Vector2(ComponentSystemValues.self.sizeX, ComponentSystemValues.self.sizeY);
        if(ComponentSystemValues.self.alignOnPlacement){
            transform.position = buildTool.CalculateClosest(InputHelper.MouseWorldPos);
        }
        else{
            transform.position = InputHelper.MouseWorldPos;
        }
    }
}
