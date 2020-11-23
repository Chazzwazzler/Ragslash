using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blood : MonoBehaviour
{
    public GameObject bloodParticleSystem;
    void OnJointBreak2D()
    {
       GameObject bloodInstantiated = (GameObject)Instantiate(bloodParticleSystem, transform.position, Quaternion.identity);
       bloodInstantiated.transform.parent = gameObject.transform;
    }
}
