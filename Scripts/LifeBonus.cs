using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeBonus : MonoBehaviour
{
    
    [SerializeField] AudioClip collectingBonus;
    [SerializeField] int scoreValue = 10;
    [SerializeField] ParticleSystem collectingBonusEffect;

    public bool isActive = true;
          
    GameObject player;
    //Animator myAnimator;
    Rigidbody2D myRigidbody;
    

    void Awake()
    {
       // myAnimator = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>(); 
        player = GameObject.FindWithTag("Player");
    }

       
    void OnTriggerEnter2D(Collider2D other)
    {
       
       if(other.tag == "Player")
       {
           
           FindObjectOfType<ScoreUpdater>().AddToLifeScore(scoreValue);
           FindObjectOfType<ScoreUpdater>().CalcGameScore();
           Destroy(gameObject);
       } 
       
    }

            
}
