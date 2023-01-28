using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    //인스펙터 창에 보기 쉽게 그냥 띄우는 것
    [Tooltip("캐릭터 이름")]
    public string character;

    //대사 내용은 배열, 여러번 문장들을 말하기 위함

    
    public string[] contexts;
}


//Dialogue가 여러개가 있어야 dialogue event가 된다.
[System.Serializable]
public class DialogueEvent{
    public Dialogue[] dialogues;

    //vector2는 2개의 float 변수를 가지게 된다.
    public Vector2 line;

    //dialogue 이름 / 즉 문장들을 모아놓고 어떤 것에 대한 대화내용인지
    public string dname;
}
