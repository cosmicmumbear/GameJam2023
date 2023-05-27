using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cutdown : MonoBehaviour
{
    [SerializeField] private GameObject gameOverDisplay;
    [SerializeField] Text timerText;

     
    public AudioClip[] countdownSound;


    
    void Start()
    {
        gameOverDisplay.gameObject.SetActive(false);
        StartCoroutine(PlaySoundEvery(1.0f, 3));
    }
 
    public void CutdownOn(float timer)
    {
        gameOverDisplay.gameObject.SetActive(true);
        timerText.text = Mathf.FloorToInt(timer).ToString();
        
    }
    public void CutdownOff()
    {
        gameOverDisplay.gameObject.SetActive(false);
             
    }

    public void SoundCutdownEffect()
    {
        StartCoroutine(PlaySoundEvery(1.0f, 3));
    }

    IEnumerator PlaySoundEvery(float t, int times)
    {
        yield return new WaitForSeconds(26);
        
        for(int i=0;i<times;i++)
        {
            GetComponent<AudioSource>().PlayOneShot(countdownSound [i]);
            yield return new WaitForSeconds(t);
        }
 
    //GetComponent<AudioSource>().PlayOneShot(roundsUpSound);
    }
}
