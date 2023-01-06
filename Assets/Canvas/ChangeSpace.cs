using UnityEngine.UI;
using UnityEngine;

public class ChangeSpace : MonoBehaviour
{
    [SerializeField] private Transform tf_infotext;

    ChangeCanvas cv;
    static int c_index;

    void Awake()
    {
        cv = gameObject.GetComponent<ChangeCanvas>();
    }

    // Update is called once per frame
    void Update()
    {
        ChangeInfo();
    }

    void ChangeInfo()
    {
        switch (c_index = cv.GetCurrnetCanvas())
        {
            case 0:
                tf_infotext.GetComponent<Text>().text = "메인";
                break;
            case 1:
                tf_infotext.GetComponent<Text>().text = "전시장";
                break;
            case 2:
                tf_infotext.GetComponent<Text>().text = "침대";
                break;
            case 3:
                tf_infotext.GetComponent<Text>().text = "컴퓨터";
                break;
            case 4:
                tf_infotext.GetComponent<Text>().text = "문";
                break;
        }
    }

    int GetCurrnetCanvas(){
        return c_index;
    }
}
