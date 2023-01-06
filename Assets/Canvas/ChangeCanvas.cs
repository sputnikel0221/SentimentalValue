using UnityEngine;

public class ChangeCanvas : MonoBehaviour
{
    //*Find Root Object and Start WORK1, WORK2
    public void Change(GameObject gameObject, int canvasCount, int i){

        GameObject root = gameObject.transform.root.gameObject;

        SetActiveFalseAll(root, canvasCount);
        SetActiveTrue(root, i);
    }

    //*WORK1 - make all canvases SetActive(false)
    void SetActiveFalseAll(GameObject p_root, int p_canvasCount){
        for(int i=0;i<p_canvasCount;i++){
            p_root.transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    //*WORK2 - make just one canvas SetActive(true)
    void SetActiveTrue(GameObject p_root, int p_i){
        p_root.transform.GetChild(p_i).gameObject.SetActive(true);
    }
}
