using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
   
   public void LoadGame()
   {
       SceneManager.LoadScene(2);
   }

    public void LoadMainMenu()
   {
       SceneManager.LoadScene(0);
   }

     public void LoadAbout()
   {
       SceneManager.LoadScene(1);
   }

        public void LoadHowToPlay()
   {
       SceneManager.LoadScene(3);
   }

    public void LoadLevel2()
   {
       SceneManager.LoadScene(4);
   }

    
}
