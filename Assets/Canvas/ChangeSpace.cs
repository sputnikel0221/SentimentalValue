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

    //*change Room space using Dict List
    void ChangeInfo()
    {
        c_index = cv.GetCurrnetCanvas();
        tf_infotext.GetComponent<Text>().text = cv.TakeStringValue(cv.TakeKey(c_index));
    }

}
