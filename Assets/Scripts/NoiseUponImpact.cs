using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseUponImpact : MonoBehaviour
{
    AudioSource source;

    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(!source.isPlaying){
            source.volume = Mathf.Clamp01(collision.relativeVelocity.magnitude / 40);
            source.Play();
        }
    }
}
