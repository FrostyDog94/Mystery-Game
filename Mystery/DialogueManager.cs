using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Queue<string> sentences;
    public Text name;
    public Text speechText;
    public GameObject dialogueCanvas;
    public InputField textInput;
    public PlayerInteract playerInteract;
    public Conversation conversation;
    

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            promptInput(textInput.text, conversation);
            textInput.text = "";
            textInput.ActivateInputField();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            EndDialogue();
        }
    }

    public void StartDialogue(Dialogue dialogue)
    {
        dialogueCanvas.SetActive(true);
        name.text = dialogue.name;
        sentences.Clear();
       

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            //EndDialogue();
            textInput.gameObject.SetActive(true);
            textInput.ActivateInputField();
     
            return;
        }
        string sentence = sentences.Dequeue();
        speechText.text = sentence;
    }

    void EndDialogue()
    {
        dialogueCanvas.SetActive(false);
        //sentences.Clear();
        playerInteract.dialogueOpen = false;
        textInput.gameObject.SetActive(false);
    }

    public void promptInput(string inputPhrase, Conversation conversation)
    {
        inputPhrase = textInput.text;
        
        

        foreach (Conversation.ConversationEntry c in conversation.convos)
        {
            if (inputPhrase == c.phrase)
            {
                speechText.text = c.response;
                Debug.Log("It works");
                
            }
            if (inputPhrase == "bye")
            {
                EndDialogue();
            }
            
        }
    }


}
