using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionEvent : MonoBehaviour
{
    [SerializeField] DialogueEvent dialogueEvent;
    
    //해당 ID에 맞는 dialogue들을 꺼낸다.
    public Dialogue[] GetDialogue_i(){
        dialogueEvent.dialogues = DatabaseManager.instance.GetDialogue((int)dialogueEvent.line.x, (int)dialogueEvent.line.y);
        return dialogueEvent.dialogues;
    }
}

//이 라인만 어디서 가져올 수만 있다면..