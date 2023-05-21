using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUpdater: MonoBehaviour
{
    int workScore = 0;
    int lifeScore = 0;
    float timer = 15;
    [SerializeField] Text timerText;
    [SerializeField] Text workScoreText;
    [SerializeField] Text lifeScoreText;
    
    GameOverHandler gameOverHandler;
    Cutdown cutdown;
  
       
    void Start() 
    {
       workScoreText.text = workScore.ToString();
       lifeScoreText.text = lifeScore.ToString();
      
    }

    void Update()
    {           
       if(timer > 1)
       {
           timer -= Time.deltaTime;
           timerText.text = Mathf.FloorToInt(timer).ToString();
       
            if(timer < 4 )
            {  
               
                cutdown = FindObjectOfType<Cutdown>();
                cutdown.CutdownOn(timer);
            }
       }
       else
       {
           cutdown.CutdownOff();
           gameOverHandler = FindObjectOfType<GameOverHandler>();
           gameOverHandler.EndGame();
       }

    }
      
    public void AddToWorkScore(int workPointsToAdd)
    {
        workScore += workPointsToAdd;
        workScoreText.text = workScore.ToString();
    }

    public void AddToLifeScore(int lifePointsToAdd)
    {
        lifeScore += lifePointsToAdd;
        lifeScoreText.text = lifeScore.ToString();
    }

    public int GetLifeScore()
    {
        return lifeScore;
    }

    public int GetWorkScore()
    {
        return workScore;
    }
}
