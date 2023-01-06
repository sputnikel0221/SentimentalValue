using UnityEngine;
using System.Collections.Generic;

public class ChangeCanvas : MonoBehaviour
{
    public static int thisCanvas = 0;

    public struct Room
    {
        int index;
        string text;

        public Room(int x, string y)
        {
            this.index = x;
            this.text = y;
        }
    }
    public static Dictionary<string, Room> roomDic = new Dictionary<string, Room>();

    void Awake()
    {
        if(roomDic.Count == 0){
            Debug.Log("Dictionary Setting");
            InitializeDic();
        }
                
    }

    //*Find Root Object and Start WORK1, WORK2
    public void Change(GameObject gameObject, int canvasCount, int i)
    {
        GameObject root = gameObject.transform.root.gameObject;

        SetActiveFalseAll(root, canvasCount);
        SetActiveTrue(root, i);
    }

    //*WORK1 - make all canvases SetActive(false)
    void SetActiveFalseAll(GameObject p_root, int p_canvasCount)
    {
        for (int i = 0; i < p_canvasCount; i++)
        {
            p_root.transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    //*WORK2 - make just one canvas SetActive(true)
    void SetActiveTrue(GameObject p_root, int p_i)
    {
        p_root.transform.GetChild(p_i).gameObject.SetActive(true);
        thisCanvas = p_i;
    }

    public int GetCurrnetCanvas()
    {
        return thisCanvas;
    }

    //? 여기에 Room들을 추가하면 된다.
    void InitializeDic()
    {
        roomDic.Add("Main", new Room(0,"메인"));
        roomDic.Add("Cabinet", new Room(1,"전시장"));
        roomDic.Add("Bed", new Room(2,"침대"));
        roomDic.Add("Computer", new Room(3,"컴퓨터"));
        roomDic.Add("Door", new Room(4,"문"));
    }
}
