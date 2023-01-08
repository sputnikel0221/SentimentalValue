using UnityEngine;

public class Buttons : MonoBehaviour
{
    public void StartBtn(){
        Debug.Log("Start!");
        
        this.gameObject.GetComponent<LightEffects>().Start_Fade();
    }

    public void OptBtn(){
        Debug.Log("opt");
        //Todo: SetActive Option UI
    }

    public void EndBtn(){
        Debug.Log("end");

        //? 모든환경에서의 END 설정
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #elif UNITY_WEBPLAYER
        Application.OpenURL(webplayerQuitURL);
        #else
        Application.Quit();
        #endif
    }

}
