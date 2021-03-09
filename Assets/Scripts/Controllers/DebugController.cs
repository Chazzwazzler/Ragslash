using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugController : MonoBehaviour
{
    bool opened; 
    
    string currentCommand;
    List<string> previousCommands = new List<string>();

    public GameObject console;
    public InputField commandField;

    [Header("Command Variables")]
    public GameObject purpleGuy;
    public GameObject secretAgent;
    public GameObject furry;
    public GameObject unamusedGuy;
    public GameObject littleMike;
    public GameObject tiredGuy;
    public GameObject sadGuy;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.BackQuote)){
            ToggleConsole();
        }

        ConsoleCommands(currentCommand);
    }

    public void ConsoleCommands(string command){

        if(command == "The man behind the slaughter"){
            BuildTool.self.UpdateSelectedObject(purpleGuy);
        }
        if(command == "Secret agent"){
            BuildTool.self.UpdateSelectedObject(secretAgent);
        }
        if(command == "OWO"){
            BuildTool.self.UpdateSelectedObject(furry);
        }
        if(command == "My disappointment is immeasurable"){
            BuildTool.self.UpdateSelectedObject(unamusedGuy);
        }
        if(command == "I want my mommy"){
            BuildTool.self.UpdateSelectedObject(littleMike);
        }
        if(command == "Just five more minutes"){
            BuildTool.self.UpdateSelectedObject(tiredGuy);
        }
        if(command == "*Crying noises*"){
            BuildTool.self.UpdateSelectedObject(sadGuy);
        }
        

        currentCommand = null;
    }

    public void ToggleConsole()
    {
        opened = !opened;
        console.SetActive(opened);
    }

    public void SetCommand(){
        previousCommands.Add(currentCommand);
        currentCommand = commandField.text;
    }
}
