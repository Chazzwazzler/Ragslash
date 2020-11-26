using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blood : MonoBehaviour
{
    builder builder;
    public GameObject bloodParticleSystem;

    void Start()
    {
        builder = GameObject.Find("Game Controller").GetComponent<builder>();
    }
    void OnJointBreak2D()
    {
        GameObject bloodInstantiated = (GameObject)Instantiate(bloodParticleSystem, transform.position, Quaternion.identity);
        var main = bloodInstantiated.GetComponent<ParticleSystem>().main;
        main.duration += builder.bloodDurationModifier;
        bloodInstantiated.transform.parent = gameObject.transform;
        bloodInstantiated.GetComponent<ParticleSystem>().Play();
        transform.parent = null;
        Destroy(this);
    }
}
