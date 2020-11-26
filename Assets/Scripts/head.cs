using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class head : MonoBehaviour
{
    private void OnJointBreak2D()
    {
        transform.DetachChildren();
    }
}
