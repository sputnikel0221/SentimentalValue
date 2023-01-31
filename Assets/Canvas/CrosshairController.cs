using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class CrosshairController : MonoBehaviour
{

    //Crosshair의 transform(위치정보)을 저장
    [SerializeField] private Transform tf_Crosshair;

    //room for find Currnet room Canvas
    [SerializeField] private GameObject room;
    GraphicRaycaster graphicRaycaster;
    PointerEventData pointerEventData;
    ChangeCanvas cv;

    //crosshair text
    [SerializeField] private Transform tf_Crossimage;
    [SerializeField] private Transform tf_Crosstext;

    void Awake()
    {
        // cv = new ChangeCanvas();
        cv = gameObject.GetComponent<ChangeCanvas>();
        tf_Crossimage.gameObject.SetActive(false);
        tf_Crosstext.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        CrosshairMove();
        CheckOnButton();
    }

    //local은 부모기준 상대 포지션, 즉 UI 캔버스로부터 얼마나 떨어져있나
    void CrosshairMove()
    {
        tf_Crosshair.localPosition = new Vector2(Input.mousePosition.x - (Screen.width / 2),
                                                Input.mousePosition.y - (Screen.height / 2));
    }


    //*if mouse is on the button, then change crosshair color
    void CheckOnButton()
    {
        //Get Current Active Room Canvas
        int c_index = cv.GetCurrnetCanvas();
        Canvas current_room = room.transform.GetChild(c_index).gameObject.GetComponent<Canvas>();

        //set
        graphicRaycaster = current_room.GetComponent<GraphicRaycaster>();
        pointerEventData = new PointerEventData(null);

        //get on mouse information
        pointerEventData.position = Input.mousePosition;
        List<RaycastResult> results = new List<RaycastResult>();
        graphicRaycaster.Raycast(pointerEventData, results);

        //if top object is button, then print log
        if (results.Count > 0)
        {
            //result의 최상위인 button component만 인식
            if (results[0].gameObject.transform.GetComponent<Button>())
            {
                tf_Crosshair.GetComponent<Image>().color = new Color32(255, 0, 250, 255);
                tf_Crossimage.gameObject.SetActive(true);
                tf_Crosstext.gameObject.SetActive(true);
                // Debug.Log("This is a Button");

                //Change CrossHair Text
                ChangeCrossText(cv.TakeStringValue(results[0].gameObject.transform.GetComponent<Button>().tag));
            }
            else
            {
                tf_Crosshair.GetComponent<Image>().color = new Color32(0, 0, 0, 255);
                tf_Crossimage.gameObject.SetActive(false);
                tf_Crosstext.gameObject.SetActive(false);
            }
        }
    }

    void ChangeCrossText(string space)
    {
        tf_Crosstext.GetComponent<Text>().text = space;
    }

}
