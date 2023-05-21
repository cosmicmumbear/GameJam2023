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
}
