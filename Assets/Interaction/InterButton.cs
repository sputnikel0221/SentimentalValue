using UnityEngine.EventSystems;
using UnityEngine;

public class InterButton : MonoBehaviour
{
    //*SINGLETON
    private static InterButton instance = null;
    private GameObject gameObject_cv;
    ChangeCanvas cv;
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

    //*View Canvas which has same tag with switch
    public void ButtonClicked()
    {
        //https://etst.tistory.com/32 - ChangeCanvas가 Mono라서 생기는 문제
        //Mono라는 것은 오브젝트에 달라붙는 스크립트이고, 해당 오브젝트에서 가져와야하는데
        //AddComponent로 붙여버리면 된다, 하지만 컴퍼넌트가 무한 증식하는데.. 
        //아래 구문으로 해결
        if (cv==null){
            cv = this.gameObject.AddComponent<ChangeCanvas>();
        } else cv = this.gameObject.GetComponent<ChangeCanvas>();

        //gameObject = currnent clicked Button 
        GameObject gameObject = EventSystem.current.currentSelectedGameObject;

        cv.Change(gameObject, cv.TakeDicCount(), cv.TakeIntValue(gameObject.tag));
    }
}


