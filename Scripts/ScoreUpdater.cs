using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUpdater: MonoBehaviour
{
    public int workScore = 0;
    public int lifeScore = 0;
    public float gameScore = 0;
    
    float timer = 15f;
    [SerializeField] Text timerText;
    [SerializeField] Text workScoreText;
    [SerializeField] Text lifeScoreText;
    [SerializeField] Text gameScoreText;
    
    
    GameOverHandler gameOverHandler;
    Cutdown cutdown;

  
  
       
    void Start() 
    {
       workScoreText.text = workScore.ToString();
       lifeScoreText.text = lifeScore.ToString();
       gameScoreText.text = gameScore.ToString();
    }

    void Update()
    {    
          if (workScore + lifeScore > 0)
          {
            int total = workScore + lifeScore;
            float abs = Mathf.Abs(workScore - lifeScore);
            gameScore = (1-Mathf.FloorToInt(abs/total)) * 100;
            gameScoreText.text = gameScore.ToString();
            
            
          } 

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

       
}
