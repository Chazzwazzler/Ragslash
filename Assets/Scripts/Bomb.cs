using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public Sprite[] bombsprites;
    public float seconds;
    int index = 0;
    public ParticleSystem explosion;

    void Start()
    {
        StartCoroutine(changesprite());
    }
    private IEnumerator changesprite()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.14f * seconds);
            index++;
            if (index <= bombsprites.Length -1)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = bombsprites[index];
            }
            else
            {
                Instantiate(explosion, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }
}
