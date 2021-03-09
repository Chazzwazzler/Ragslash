using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    bool paused = false;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            pauseGame();
        }

        if(Input.GetKeyDown(KeyCode.Tab) && !Input.GetKey(KeyCode.LeftShift))
        {
            Time.timeScale *= 2;
        }
        else if(Input.GetKeyDown(KeyCode.Tab) && Input.GetKey(KeyCode.LeftShift)){
            Time.timeScale /= 2;
        }
    }

    public void pauseGame()
    {
         paused = !paused;
         if (paused == true)
         {
             Time.timeScale = 0;
         } 
         else
         {
             Time.timeScale = 1;
         }
    }
}
