using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class consoleController : MonoBehaviour
{
    //console code
    bool opened = false; 
    
    public dropdown open;
    public dropdown close;

    public string currentCommand;
    public List<string> previousCommands = new List<string>();
    public InputField commandField;


    //stuff needed for console commands
    public GameObject BOB;
    public GameObject catBoy;
    public GameObject governmentAgent;
    public GameObject littleMike;
    public GameObject purpleGuy;
    public builder Builder;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.BackQuote)){
            openAndCloseConsole();
        }

        consoleCommands(currentCommand);
    }

    public void openAndCloseConsole()
    {
         opened = !opened;
         if (opened == true)
         {
             open.openAndClose();
             Time.timeScale = 0;
         } 
         else
         {
             close.openAndClose();
             Time.timeScale = 1;
         }
    }

    public void setCommand(){
        previousCommands.Add(currentCommand);
        currentCommand = commandField.text;
    }

    public void consoleCommands(string command){
        //Antigrav - no gravity
        if(command == "Antigrav"){
            GameObject[] gravityObjects = UnityEngine.Object.FindObjectsOfType<GameObject>();
            for (int i = 0; i < gravityObjects.Length; i++)
            {
                if(gravityObjects[i].GetComponent<Rigidbody2D>()!= null){
                    gravityObjects[i].GetComponent<Rigidbody2D>().gravityScale = 0;
                    Builder.gravityScale = 0;
                }
            }
        }
        //The fourth - spawns BOB
        if(command == "The fourth"){
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Instantiate(BOB, mousePos, Quaternion.identity);
        }
        //Delete - deletes all objects, including the ground, from the scene
        if(command == "Delete"){
            GameObject[] allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>();
            for (int i = 0; i < allObjects.Length; i++)
            {
                if(allObjects[i].GetComponent<SpriteRenderer>() != null){
                    Destroy(allObjects[i]);
                }
            }
        }
        //Supergrav - 100x gravity
        if(command == "Supergrav"){
            GameObject[] gravityObjects = UnityEngine.Object.FindObjectsOfType<GameObject>();
            for (int i = 0; i < gravityObjects.Length; i++)
            {
                if(gravityObjects[i].GetComponent<Rigidbody2D>()!= null){
                    gravityObjects[i].GetComponent<Rigidbody2D>().gravityScale = 100;
                    Builder.gravityScale = 100;
                }
            }
        }
        //Heavy - Makes everything really heavy
        if(command == "Heavy"){
            GameObject[] heavyObjects = UnityEngine.Object.FindObjectsOfType<GameObject>();
            for (int i = 0; i < heavyObjects.Length; i++)
            {
                if(heavyObjects[i].GetComponent<Rigidbody2D>()!= null){
                    heavyObjects[i].GetComponent<Rigidbody2D>().mass = 100;
                    Builder.massScale = 100;
                }
            }
        }
        //OWO - Spawns catboy
        if(command == "OWO"){
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Instantiate(catBoy, mousePos, Quaternion.identity);
        }
        //CIA - Spawns government agent
        if(command == "CIA"){
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Instantiate(governmentAgent, mousePos, Quaternion.identity);
        }
        //Smol - Spawns little mike
        if(command == "Smol"){
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Instantiate(littleMike, mousePos, Quaternion.identity);
        }
        //The man behind the slaughter
        if(command == "The man behind the slaughter"){
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Instantiate(purpleGuy, mousePos, Quaternion.identity);
        }
        currentCommand = null;
    }
}
