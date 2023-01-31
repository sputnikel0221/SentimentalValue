using UnityEngine;

[System.Serializable]
public class Dialogue
{
    public string character;
    public string[] contexts; //대사 내용은 배열, 여러번 문장들을 말하기 위함
}


[System.Serializable]
public class DialogueEvent{
    public string dname; //dialogue 이름 / 즉 문장들을 모아놓고 어떤 것에 대한 대화내용인지
    public Vector2 line; //vector2는 2개의 float 변수를 가지게 된다.
    public Dialogue[] dialogues;
}
