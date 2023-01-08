using UnityEngine;
using System.Collections;

public class StandEffect : MonoBehaviour
{
    private bool isWork = false;

    void Start(){
        Start_Blink();
    }

    public void Start_Blink()
    {
        StartCoroutine(Blink());
    }

    IEnumerator Blink()
    {
        while (true)
        {
            isWork = !isWork;
            if (isWork)
            {
                Debug.Log("Light---ON");
                this.gameObject.SetActive(true);
            }
            else
            {
                Debug.Log("Lightoff");
                this.gameObject.SetActive(false);
            }
            Debug.Log(isWork);
            yield return .3f;
            
        }    
    }
}
