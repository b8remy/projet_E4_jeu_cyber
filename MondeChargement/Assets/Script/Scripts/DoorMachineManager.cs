using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DoorMachineManager : MonoBehaviour
{
    public TMP_Text DisplayedCode;

    private string Code;

    public string CorrectCode = "5678";

    DoorMachine doorMachine;

    OpenUI openUI;


    // Start is called before the first frame update
    void Start()
    {
        Code = DisplayedCode.text;

        doorMachine = GameObject.FindGameObjectWithTag("Door").GetComponent<DoorMachine>();
        openUI = GameObject.FindGameObjectWithTag("UI").GetComponent<OpenUI>();
    }

    public void OnButtonClick(string button) {

        if (!doorMachine.isDoorOpened) {
            if (button == "Delete") {
            if (Code.Length > 0) {
                Code = Code.Substring(0, Code.Length -1);
                UpdateDisplayedText(Code);
            }
        }
        else if (button == "Submit"){
            
            if (Code.Length != 4) {
                Debug.Log("Code faux");
            } else if (Code != CorrectCode) {
                Debug.Log("Code faux");
            } else {
                Debug.Log("Code Bon");
                openUI.Resume();
                StartCoroutine(doorMachine.OpenDoorCoroutine());
            }
        }
        else {
            if (Code.Length < 4) {
                Code += button;
                UpdateDisplayedText(Code);
            }
        }
        }

        
    }

    public void UpdateDisplayedText(string code)
    {
        DisplayedCode.text = code; // Met à jour le texte avec le code fourni en argument
    }

    private void Update () {
        if(Input.GetKeyDown(KeyCode.Escape)) {
            openUI.Resume();
        }
    }
}
