using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cutdown : MonoBehaviour
{
    [SerializeField] private GameObject gameOverDisplay;
    [SerializeField] Text timerText;
    [SerializeField] AudioClip cutdownSFX;
    
    void Start()
    {
        gameOverDisplay.gameObject.SetActive(false);
    }
 
    public void CutdownOn(float timer)
    {
        gameOverDisplay.gameObject.SetActive(true);
        timerText.text = Mathf.FloorToInt(timer).ToString();
     
         //   AudioSource.PlayClipAtPoint(cutdownSFX, Camera.main.transform.position);

             
    }
    public void CutdownOff()
    {
        gameOverDisplay.gameObject.SetActive(false);
             
    }
}
