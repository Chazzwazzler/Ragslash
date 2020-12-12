using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bloodStain : MonoBehaviour
{
    public GameObject bloodStainObject;
    void OnParticleCollision(GameObject other)
    {
        GameObject bloodStainSpawned = (GameObject)Instantiate(bloodStainObject, other.transform.position, Quaternion.Euler(0,0,Random.Range(-360,360)));
        bloodStainSpawned.transform.parent = gameObject.transform.parent;
    }
}
