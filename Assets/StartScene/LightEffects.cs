using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LightEffects : MonoBehaviour
{
    [SerializeField] GameObject LightPanel;

    private float fadeTime;
    private float accel = 0.4f;

    public void Start_Fade()
    {
        StartCoroutine(Fade());
    }

    //fadeOUT
    IEnumerator Fade()
    {
        LightPanel.SetActive(true);
        Color c = LightPanel.GetComponent<Image>().color;
        fadeTime = 0.1f;

        for (float alpha = 0.0f; alpha <= 1.1f; alpha += 0.005f)
        {
            c.a = alpha;
            LightPanel.GetComponent<Image>().color = c;

            if(c.a >= 1){
                yield return new WaitForSeconds(0.1f);  
                NextScene();
            }

            fadeTime = fadeTime * accel;
            yield return new WaitForSeconds(fadeTime);   
        }    
    }


    void NextScene()
    {
        SceneManager.LoadScene("Room");
    }
}
