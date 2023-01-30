using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalkingManager : MonoBehaviour
{
    [SerializeField] private Transform tf_Dialog_Bar;
    [SerializeField] private Transform tf_Person_Bar;

    //File에서 파싱한 전체 대화를 여기 담음
    Dialogue[] dialogues;

    static public bool isTalking = false;

    //대화 인덱스값들
    static public int i_dia;
    static public int i_cont;

    //다음 cont를 출력할지를 위한 변수
    static public bool d_stop;

    //핵심코드
    void Update()
    {
        setTalking();
        if (isTalking)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //space누를 시, 다음 문장 실행
                d_stop = false;

                if (++i_cont < dialogues[i_dia].contexts.Length)
                {
                    StartCoroutine(TypeWriter());
                }
                else
                {
                    if (++i_dia < dialogues.Length)
                    {
                        i_cont = 0;
                        StartCoroutine(TypeWriter());
                    }
                    else
                    {
                        //todo : enddialogue
                    }

                }
            }
        }
    }

    public void setTalking()
    {
        if (isTalking == false)
        {
            tf_Dialog_Bar.gameObject.SetActive(false);
            tf_Person_Bar.gameObject.SetActive(false);
        }
        else
        {
            tf_Dialog_Bar.gameObject.SetActive(true);
            tf_Person_Bar.gameObject.SetActive(true);
        }
    }

    public void ShowDialog(Dialogue[] p_dialogues)
    {
        //todo: 현재 대화 위치 기록한 CSV
        //코루틴 사용하여 대기시간을 주는 방식으로 해도 될 듯
        //타이핑 효과는 어떻게?

        tf_Person_Bar.transform.GetChild(0).GetComponent<Text>().text = "";
        tf_Dialog_Bar.transform.GetChild(0).GetComponent<Text>().text = "";
        isTalking = false;
        dialogues = p_dialogues;

        StartCoroutine(TypeWriter());
    }

    IEnumerator TypeWriter()
    {
        isTalking = true;

        //?문제있도록 증가시킨 값을 if문을 취하는 것이 아니라, 증가시키기 전에 판별을 해야한다. update문으로..
        // if (dialogues[i_dia].contexts[i_cont] == null)
        // {
        //     Debug.Log("시ㅣ작");
        //     i_cont = 0;
        //     i_dia++;
        //     Debug.Log("끝");
        // }

        tf_Person_Bar.transform.GetChild(0).GetComponent<Text>().text = dialogues[i_dia].character;
        tf_Dialog_Bar.transform.GetChild(0).GetComponent<Text>().text = dialogues[i_dia].contexts[i_cont];
        Debug.Log(i_dia);
        Debug.Log(i_cont);

        d_stop = true;

        yield return null;
    }


    public void SkipDialog()
    {
        //todo: 대화 스킵
    }
}
