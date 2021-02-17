using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    public Vector2 targetPos;

    public float waitTime;

    private void Start() {
        transform.position = new Vector3(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y), 0);

        StartCoroutine("UpdateTile");
    }

    public IEnumerator UpdateTile(){
        while(true){
            yield return new WaitForSeconds(waitTime);

            if(PowdersSimHelper.CanMoveTileToPosition(transform.position, Vector2.down, 1f, false) && PowdersSimHelper.CanMoveTileToPosition(transform.position, Vector2.down, 2f, true)){
                targetPos = (Vector2)transform.position + Vector2.down;
            }
            else if(PowdersSimHelper.CanMoveTileToPosition(transform.position, new Vector2(-1,-1), 1f, false) && PowdersSimHelper.CanMoveTileToPosition(transform.position, new Vector2(-1,-1), 2f, true)){
                targetPos = (Vector2)transform.position + new Vector2(-1,-1);
            }
            else if(PowdersSimHelper.CanMoveTileToPosition(transform.position, new Vector2(1,-1), 1f, false) && PowdersSimHelper.CanMoveTileToPosition(transform.position, new Vector2(1,-1), 2f, true)){
                targetPos = (Vector2)transform.position + new Vector2(1,-1);
            }
            else if(PowdersSimHelper.CanMoveTileToPosition(transform.position, new Vector2(-1,0), 1f, false) && PowdersSimHelper.CanMoveTileToPosition(transform.position, new Vector2(-1,0), 2f, true)){
                targetPos = (Vector2)transform.position + Vector2.left;
            }
            else if(PowdersSimHelper.CanMoveTileToPosition(transform.position, new Vector2(1,0), 1f, false) && PowdersSimHelper.CanMoveTileToPosition(transform.position, new Vector2(1,0), 2f, true)){
                targetPos = (Vector2)transform.position + Vector2.right;
            }

            transform.position = targetPos;
        }
    }
}
