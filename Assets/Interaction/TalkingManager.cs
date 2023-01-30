using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalkingManager : MonoBehaviour
{
    [SerializeField] private Transform tf_Dialog_Bar;
    [SerializeField] private Transform tf_Person_Bar;


    Dialogue[] dialogues;

    static public bool isTalking = false;

    void Update()
    {
        setTalking();
    }

    public void setTalking(){
        if(isTalking==false){
            tf_Dialog_Bar.gameObject.SetActive(false);
            tf_Person_Bar.gameObject.SetActive(false);
        }
        else {
            tf_Dialog_Bar.gameObject.SetActive(true);
            tf_Person_Bar.gameObject.SetActive(true);
        }
    }
        
    public void ShowDialog(Dialogue[] p_dialogues){
        //todo: 현재 대화 위치 기록한 CSV
        //코루틴 사용하여 대기시간을 주는 방식으로 해도 될 듯
        //타이핑 효과는 어떻게?
        dialogues = p_dialogues;
        tf_Person_Bar.transform.GetChild(0).GetComponent<Text>().text = dialogues[1].contexts[1];
        tf_Dialog_Bar.transform.GetChild(0).GetComponent<Text>().text = dialogues[1].contexts[1];
        
    }

    public void SkipDialog(){
        //todo: 대화 스킵
    }
}
