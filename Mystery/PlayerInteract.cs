using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public DialogueManager dm;
    public bool dialogueOpen;
    
    // Start is called before the first frame update
    void Start()
    {
        dm = FindObjectOfType<DialogueManager>();
        dialogueOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * 5, Color.green);
        RaycastHit hit;
        Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 5f);
        if (Input.GetMouseButtonDown(1))
        { if (dialogueOpen == false)
            {
                hit.transform.GetComponent<DialogueTrigger>().TriggerDialogue();
                dialogueOpen = true;
            } else if (dialogueOpen == true)
            {
                dm.DisplayNextSentence();
            }
        }

    }
}
