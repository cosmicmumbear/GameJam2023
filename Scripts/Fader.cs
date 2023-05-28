using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fader : MonoBehaviour
{
    CanvasGroup canvasGroup;
    private void Start() 
    {
        canvasGroup = GetComponent<CanvasGroup>();
        StartCoroutine(FadeOutIn());
    }

    public IEnumerator FadeOutIn()
    {
        yield return FadeOut(0.8f);
        yield return FadeIn(0.5f);
    }

    IEnumerator FadeOut(float time)
    {
        while (canvasGroup.alpha < 1) 
        {
            canvasGroup.alpha += Time.deltaTime/time;
            yield return null;
        }
    }

    IEnumerator FadeIn(float time)
    {
        while (canvasGroup.alpha > 0) 
        {
            canvasGroup.alpha -= Time.deltaTime/time;
            yield return null;
        }
    }
}
