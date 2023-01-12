using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using Random = UnityEngine.Random;

public class StandEffect : MonoBehaviour
{
    private bool isWork = false;
    int amount;
    const float DefaultAlpha = 0.15f;

    void Start()
    {

        StartCoroutine(Blink());
    }

    IEnumerator Blink()
    {
        //for Exception - Infinite Loop
        int loopNum = 0;
        Color c = this.gameObject.GetComponent<Image>().color;

        while (true)
        {
            amount = Random.Range(100, 1000);
            Debug.Log(amount);
            Debug.Log((DefaultAlpha / amount));

            // 작동중이 아니면, 전등을 킨다.
            if (isWork == false)
            {
                c.a = DefaultAlpha;
                this.gameObject.GetComponent<Image>().color = c;
                isWork = true;
            }

            // 작동중이 이라면, 전등을 끈다.
            //  1) Alpha값을 0.15에서 0까지 랜덤만큼 비례하여 감소시킨다.
            else
            {
                //0.15에서 0까지 랜덤초만큼 지연을 시키려면, alpha값은 얼마만큼 바뀌어야하는가?
                //? N * waitSec = 0.15(DefaultAlpha); N=0.15(DefaultAlpha) / waitSec; 
                for (float alpha = DefaultAlpha; alpha > 0; alpha -= (DefaultAlpha / amount))
                {
                    c.a = alpha;
                    this.gameObject.GetComponent<Image>().color = c;
                    yield return new WaitForSeconds(DefaultAlpha / amount);
                }
                
                //alpha -= (DefaultAlpha / amount) 라는 값이 정확히 0이 되지 않아 없어지지 않는 경우가 존재하므로 0으로 직접 설정
                c.a = 0;
                this.gameObject.GetComponent<Image>().color = c;

                isWork = false;
            }

            //while - infinite Loop check
            if (loopNum++ > 10000){
                throw new Exception("Infinite Loop");
            }
                
            //불이 꺼지든 켜지든 실행되는 지연문으로, 100을 곱하는게 더 자연스럽다는 판단에 100을 곱함.
            //어짜피 100을 곱하든 안곱하든 0.0002527899 이런 값에 100을 곱하는 것이라 작은 값임은 같다.
            yield return new WaitForSeconds(DefaultAlpha / amount * 100);
        }
    }
}
