using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blood : MonoBehaviour
{
    public float bloodDurationModifier;
    public GameObject bloodParticleSystem;

    void Start()
    {
        if(gameObject.GetComponent<HingeJoint2D>() == null){
            Destroy(this);
        }
    }
    void OnJointBreak2D()
    {
        GameObject bloodInstantiated = (GameObject)Instantiate(bloodParticleSystem, transform.position, Quaternion.identity);
        var main = bloodInstantiated.GetComponent<ParticleSystem>().main;
        main.duration += bloodDurationModifier;
        bloodInstantiated.transform.parent = gameObject.transform;
        bloodInstantiated.GetComponent<ParticleSystem>().Play();
        transform.parent = null;
        Destroy(this);
    }

}
