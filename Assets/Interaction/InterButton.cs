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
        ChangeCanvas cv = new ChangeCanvas();

        //gameObject = currnent clicked Button 
        GameObject gameObject = EventSystem.current.currentSelectedGameObject;

        cv.Change(gameObject, cv.TakeDicCount(), cv.TakeIntValue(gameObject.tag));
    }
}


