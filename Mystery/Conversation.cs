using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Conversation 
{
    [System.Serializable]
    public class ConversationEntry
    {
        public string phrase;

        [TextArea(3, 10)]
        public string response;
    }

    public ConversationEntry[] convos;
}
