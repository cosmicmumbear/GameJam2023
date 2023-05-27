using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkBonus : MonoBehaviour
{
    
    [SerializeField] int scoreValue = 10;
    [SerializeField] ParticleSystem collectingBonusEffect;
    [SerializeField] AudioClip bonusAudio;

    SpriteRenderer spriteRenderer;

    public bool isActive = true;
          
    GameObject player;
    
    Rigidbody2D myRigidbody;
        

    void Awake()
    {
        myRigidbody = GetComponent<Rigidbody2D>(); 
        player = GameObject.FindWithTag("Player");
        spriteRenderer = GetComponent<SpriteRenderer>(); 
    }

       
        void OnTriggerEnter2D(Collider2D other)
    {
        
       
       if(other.tag == "Player" && isActive)
       {
           FindObjectOfType<ScoreUpdater>().AddToWorkScore(scoreValue);
           isActive = false;
           StartCoroutine(Die());
           spriteRenderer.enabled = false;
       } 
       else
       {
        return;
       }
       
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
