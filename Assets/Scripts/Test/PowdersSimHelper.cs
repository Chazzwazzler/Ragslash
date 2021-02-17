using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PowdersSimHelper
{
    public static bool CanMoveTileToPosition(Vector2 tilePosition, Vector2 direction, float checkRadius, bool checkIfOtherHasTarget){
        Vector2 movePoint = tilePosition + direction;

        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(tilePosition, checkRadius);
        foreach (var hitCollider in hitColliders)
        {
            if(checkIfOtherHasTarget && hitCollider.gameObject.GetComponent<Water>() != null){
                if(hitCollider.gameObject.GetComponent<Water>().targetPos == movePoint){
                    return false;
                }
            }
            else{
                if((Vector2) hitCollider.transform.position != tilePosition && IsWithin(hitCollider, movePoint)){
                    return false;
                }
            }
        }

        return true;
    }

    public static bool IsWithin(Collider2D collider, Vector2 point)
    {
        return (collider.ClosestPoint(point) - point).sqrMagnitude < Mathf.Epsilon * Mathf.Epsilon;
    }
}
