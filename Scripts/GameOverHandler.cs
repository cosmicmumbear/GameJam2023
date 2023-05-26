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
    [SerializeField] private GameObject bonusSpawner2;
    [SerializeField] private GameObject gameSesion;
    
    

 
    public void EndGame()
    {
        gameOverDisplay.gameObject.SetActive(true);
        bonusSpawner.gameObject.SetActive(false);
        bonusSpawner2.gameObject.SetActive(false);
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
}
