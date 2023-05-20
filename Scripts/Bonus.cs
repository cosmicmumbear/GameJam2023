using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    
    [SerializeField] AudioClip collectingBonus;
    [SerializeField] int scoreValue = 100;
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
       
       if(other.tag == "Player" )
       {
           StartCoroutine(Die());
           FindObjectOfType<ScoreUpdater>().AddToScore(scoreValue);
       } 
    }

    IEnumerator Die()
    {
        isActive = false;
        //myAnimator.SetTrigger("Dead"); 
        
        //AudioSource.PlayClipAtPoint(collectingBonus, Camera.main.transform.position);
        //collectingBonusEffect.Play();

        yield return new WaitForSecondsRealtime(1);

        Destroy(gameObject);
    }

            
}
