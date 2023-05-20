using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverHandler : MonoBehaviour
{

    [SerializeField] private GameObject gameOverDisplay;
       [SerializeField] private GameObject player;

 
    public void EndGame()
    {
        gameOverDisplay.gameObject.SetActive(true);
           
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
