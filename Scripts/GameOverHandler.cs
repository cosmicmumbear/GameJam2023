using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverHandler : MonoBehaviour
{

    [SerializeField] private GameObject gameOverDisplay;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject bonusSpawner;
    [SerializeField] private GameObject gameSesion;
    
    

 
    public void EndGame()
    {
        gameOverDisplay.gameObject.SetActive(true);
        bonusSpawner.gameObject.SetActive(false);
        player.gameObject.SetActive(false);
        
           
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadLevel2()
    {
        SceneManager.LoadScene(4);
    }
    public void LoadLevel3()
    {
        SceneManager.LoadScene(6);
    }    

    public void LoadYouWin()
    {
        SceneManager.LoadScene(5);
    }
}
