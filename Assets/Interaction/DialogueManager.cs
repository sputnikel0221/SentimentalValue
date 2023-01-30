using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    void Awake(){
        TalkingManager tk = this.GetComponent<TalkingManager>();
        TalkingManager.isTalking = true; //static변수이기 때문에 이렇게 구문이 쓰임

        tk.ShowDialog(this.transform.GetComponent<InteractionEvent>().GetDialogue_i());
    }
}

