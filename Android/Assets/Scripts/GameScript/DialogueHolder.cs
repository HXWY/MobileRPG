﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueHolder : MonoBehaviour {

    public string dialogue;
    private DialogueManager dialogueManage;

    public string[] dialogueLines;

    public bool autoPlay;

	// Use this for initialization
	void Start () {
        dialogueManage = FindObjectOfType<DialogueManager>();
        if (autoPlay)
        {
            
            dialogueManage.dialogueLines = dialogueLines;
            dialogueManage.currentLine = 0;
            dialogueManage.ShowDialogue();
            autoPlay = false;

        }


    }
	
	// Update is called once per frame
	void Update () {
       
    }

    /*
     * Every moment the player stays inside the box
     * We don't use OnTriggerEnter2D because it just happens ONCE
     */
    private void OnTriggerStay2D(Collider2D other) 
    { 
        if (other.gameObject.name == "Player1")
        {
            if (Input.GetKeyUp(KeyCode.Z))
            {
                //dialogueManage.ShowBox(dialogue);

                if (!dialogueManage.dialogueActive) // Restart from the first dialogue line
                {
                    dialogueManage.dialogueLines = dialogueLines;
                    dialogueManage.currentLine = 0;
                    dialogueManage.ShowDialogue();
                }

                if (transform.parent.GetComponent<VillagerMovement>() != null) // if the villager even has a villagermovement script
                {
                    transform.parent.GetComponent<VillagerMovement>().canMove = false;
                }


            }
        }
    }
}
