using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueParser : MonoBehaviour
{

    //File에서 Dialogue를 추출하는 함수
    public Dialogue[] Parse(string _CSVFileName)
    {
        //dialogue를 받을 list
        List<Dialogue> dialogueList = new List<Dialogue>();

        //TextAsset이란 형태로 받을 수 있는데, Resources에서 해당 파일 이름을 TextAsset형태로 Load한다.
        TextAsset csvData = Resources.Load<TextAsset>(_CSVFileName);

        //일종의 공식, 엔터 단위로 데이터를 쪼개어 string 배열로 넣는다
        //data[0] = {1,주인공,여긴 내 방이다.}
        string[] data = csvData.text.Split(new char[] { '\n' });

        //data.length는 1개 더 많음, i의 증가는 do while문에서 겸사겸사 진행한다.
        for (int i = 1; i < data.Length;)
        {
            //row[0] = 1 / row[1] = 주인공 / row[2] = 여긴 내 방이다.
            string[] row = data[i].Split(new char[] { ',' });

            //Dialogue객체를 만들어서
            Dialogue dialogue = new Dialogue();

            //캐릭터 이름 추가 
            dialogue.character = row[1];
            // Debug.Log(row[1]);

            //캐릭터 당 대화 추가
            List<string> contextList = new List<string>();
            do
            {
                contextList.Add(row[2]);    //* 이게 중요
                // Debug.Log(row[2]);

                if (++i< data.Length)
                {
                    row = data[i].Split(new char[] { ',' });
                }
                else { break; }
            }
            while (row[0].ToString() == "");


            //캐릭터 이름에 맞는 대사만을 list에 넣었으니, 해당 대사 내용만 contexts로 집어넣음
            //주인공-1 에 해당하는 dialogue가 dialogue-list에 추가가 되는 것
            //dialogue는 하나의 대화 폴더이고, dialogueList는 해당 폴더들의 상위 폴더인 셈이다
            //결국 return으로 해당 구조를 전부 array로 반환하게 된다.
            //*의문점, 마지막에 return으로 toArray를 하면 array로 다시 바뀌는데 
            //*굳이 dialogue에 context를 놓아서 구조를 갖추는 이유는 뭘까? > dialogue의 Array로 구조가 유지된다.
            dialogue.contexts = contextList.ToArray();
            dialogueList.Add(dialogue);
        }

        return dialogueList.ToArray();
    }
}


//? 배열의 크기를 정확히 모르고 유동적일 때는 List를 쓰는 것이 좋다.
//? 하지만 다른 방법도 있는데, 크기를 선언하지 않은 배열을 쓴 뒤, List로 값을 받고, List.ToArray()를 해버리면 된다.