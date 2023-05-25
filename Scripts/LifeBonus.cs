using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeBonus : MonoBehaviour
{
    
    
    [SerializeField] int scoreValue = 10;
    [SerializeField] ParticleSystem collectingBonusEffect;
    [SerializeField] AudioClip bonusAudio;

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
           StartCoroutine(Die());
       } 
       else{        return;       }
       
    }

    IEnumerator Die()
    {
        
        collectingBonusEffect.Play();
        AudioSource.PlayClipAtPoint(bonusAudio, Camera.main.transform.position);

        yield return new WaitForSeconds(1);
        
        Destroy(gameObject);
    }
    private void OnBecameInvisible() 
      {
       Destroy(gameObject);
      }
            
}
