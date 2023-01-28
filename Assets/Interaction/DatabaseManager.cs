using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatabaseManager : MonoBehaviour
{
    //singleton
    public static DatabaseManager instance;

    [SerializeField] string csv_FileName;
    Dictionary<int, Dialogue> dialogueDic = new Dictionary<int, Dialogue>();

    //데이터 파싱 전부 저장이 되었는가 알려주는 변수
    public static bool isFinish = false;

    void Awake()
    {
        //singleton
        if (instance == null)
        {
            instance = this;

            //현재 DatabaseManager와 DialogueParser를 같은 객체에 넣을 것이기에 가능한 구문
            DialogueParser theParser = GetComponent<DialogueParser>();

            //parse를 통해 가져온 모든 Dialogue들을 Dictionary화 시킨다. 주의할 것은 인덱스를 1부터 잡았다.
            Dialogue[] dialogues = theParser.Parse(csv_FileName);
            for (int i = 0; i < dialogues.Length; i++)
            {
                dialogueDic.Add(i + 1, dialogues[i]);
            }
            isFinish = true; //* 전부다 끝나면 isFinish를 true로 만든다. 굳이 하는 이유는??
        }
    }

    public Dialogue[] GetDialogue(int _StartNum, int _EndNum)
    {
        List<Dialogue> getterDialogue = new List<Dialogue>(); //배열의 크기를 정확히 모를때, 유동적일 때 -  list

        //? Dic 인덱스에 주의하며 사용
        for (int i = 0; i <= _EndNum - _StartNum; i++)
        {
            getterDialogue.Add(dialogueDic[_StartNum+i]);
        }
        return getterDialogue.ToArray();
    }

}
