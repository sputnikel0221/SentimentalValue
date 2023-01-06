using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkingManager : MonoBehaviour
{
    [SerializeField] private Transform tf_Dialog_Bar;
    [SerializeField] private Transform tf_Person_Bar;

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

            ShowDialog();
        }
    }
        
    void ShowDialog(){
        //todo: 현재 대화 위치 기록한 CSV
        //코루틴 사용하여 대기시간을 주는 방식으로 해도 될 듯
        //타이핑 효과는 어떻게?
        
    }

    void SkipDialog(){
        //todo: 대화 스킵
    }
}
