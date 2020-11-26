using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ragdoll : MonoBehaviour
{
    builder builder;
    Joint2D joint;

    // Start is called before the first frame update
    void Start()
    {
        builder = GameObject.Find("Game Controller").GetComponent<builder>();
        if(gameObject.GetComponent<Joint2D>()!=null){
            joint = gameObject.GetComponent<Joint2D>();
        }
        if(builder.hasJoints == false){
            Destroy(joint);
        }
        else{
            joint.breakForce += (100 * builder.strengthModifier);
        }
        if(builder.hasBlood == false){
            Destroy(gameObject.GetComponent<blood>());
        }
        Destroy(this);
    }
}
