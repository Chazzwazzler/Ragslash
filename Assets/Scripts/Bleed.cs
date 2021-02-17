using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bleed : MonoBehaviour
{
    public GameObject bloodEffect;

    private void OnJointBreak2D(Joint2D brokenJoint) {
        GameObject bloodObject = Instantiate(bloodEffect,transform.position,transform.rotation);
        bloodObject.transform.parent = transform;
    }
}
