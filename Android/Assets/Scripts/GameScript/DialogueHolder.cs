﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueHolder : MonoBehaviour
{

    public string dialogue;
    private DialogueManager dialogueManage;
    private JoyButton joybutton;

    public string[] dialogueLines;
    private PlayerController thePlayer;
    public bool activateOnStartScene;
    public bool triggerOnce;
    public bool canMoveInDialogue;

    //public static bool autoPlay = true; // TRIGGER THE DIALGOUE ONCE

    // Use this for initialization
    void Start()
    {
        dialogueManage = FindObjectOfType<DialogueManager>();
        joybutton = FindObjectOfType<JoyButton>();
        thePlayer = FindObjectOfType<PlayerController>();
        if (activateOnStartScene)
        {
            if (!dialogueManage.dialogueActive) // Restart from the first dialogue line
            {
                dialogueManage.dialogueLines = dialogueLines;
                dialogueManage.currentLine = 0;
                dialogueManage.ShowDialogue();
            }
            
        }


    }

    // Update is called once per frame
    void Update()
    {
        if (activateOnStartScene)
        {
           
            if (dialogueManage.currentLine == dialogueLines.Length - 2)
            {
                activateOnStartScene = false;
                thePlayer.canMove = true;
                Destroy(gameObject);
            }
            print("currentline" + dialogueManage.currentLine);
            print(dialogueLines.Length);
        }
        
    }
    
    /*
     * Every moment the player stays inside the box
     * We don't use OnTriggerEnter2D because it just happens ONCE
     */
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name == "Player1")
        {
            if ((Input.GetKeyUp(KeyCode.Z) || joybutton.pressed)) // joybutton.pressed
            {
                //dialogueManage.ShowBox(dialogue);
                // If dialogue is open, do not open dialogue again right after closing
                if (!dialogueManage.dialogueActive ) // Restart from the first dialogue line
                {
                    dialogueManage.dialogueLines = dialogueLines; // Switch size 
                    dialogueManage.currentLine = 0; // Reset to 0
                    dialogueManage.ShowDialogue();
                    //joybutton.pressed = false; // Cant hold button down
                }
                if (dialogueManage.dialogueActive && dialogueManage.currentLine == dialogue.Length-1)
                {
                    thePlayer.canMove = true;
                }

                //if (transform.parent.GetComponent<VillagerMovement>() != null) // if the villager even has a villagermovement script
                //{
                //    transform.parent.GetComponent<VillagerMovement>().canMove = false;
                //}
                //else
                //{

            }

           
            
            if (canMoveInDialogue)
            {
                thePlayer.canMove = true;
            }
        }


    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player1")
        {
            if (triggerOnce)
            {
                triggerOnce = false;
                dialogueManage.dialogueLines = dialogueLines;
                dialogueManage.currentLine = 0;
                dialogueManage.ShowDialogue();
                if (dialogueManage.currentLine >= dialogueLines.Length - 1)
                {

                    Destroy(gameObject);
                }
                thePlayer.canMove = true;
                //print(dialogueManage.currentLine);
                //print("Dialogeu length" + dialogueLines.Length);
            }
        }
    }
}

