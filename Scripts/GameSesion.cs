using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSesion : MonoBehaviour
{
        void Awake()
        {
        int numGameSessions = FindObjectsOfType<GameSesion>().Length;
        if(numGameSessions > 1)
            {
                Destroy(gameObject);
            } 
            else 
            {
                DontDestroyOnLoad(gameObject);
            }
        } 
}
