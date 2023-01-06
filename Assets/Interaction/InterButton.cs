using UnityEngine.EventSystems;
using UnityEngine;

public class InterButton : MonoBehaviour
{
    //*SINGLETON
    private static InterButton instance = null;
    void Awake()
    {
        if (null == instance)
        {
            instance = this;

            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    //일단 사용자가 적도록 하기, 나중에 dictionary length바탕으로 받아오도록
    //모든 Canvas의 개수
    [SerializeField]
    private int canvasCount;

    //*View Canvas which has same tag with switch
    public void ButtonClicked()
    {
        //https://etst.tistory.com/32 - ChangeCanvas가 Mono라서 생기는 문제
        //ChangeCanvas change_canvas = new ChangeCanvas();
        ChangeCanvas change_canvas = this.gameObject.AddComponent<ChangeCanvas>();

        //gameObject = currnent clicked Button 
        GameObject gameObject = EventSystem.current.currentSelectedGameObject;

        switch (gameObject.tag)
        {
            //TODO - Main으로 오는 버튼 생성하기. - 나중에 dic으로 숫자로 바꿀 수 있지만, 일단 하드코딩
            case "Main":
                change_canvas.Change(gameObject, canvasCount, 0);
                break;
            case "Cabinet":
                change_canvas.Change(gameObject, canvasCount, 1);
                break;
            case "Bed":
                change_canvas.Change(gameObject, canvasCount, 2);
                break;
            case "Computer":
                change_canvas.Change(gameObject, canvasCount, 3);
                break;
            case "Door":
                change_canvas.Change(gameObject, canvasCount, 4);
                break;
        }
    }
}


