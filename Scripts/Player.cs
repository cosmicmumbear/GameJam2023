using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    Vector2 rawInput;
    
    [SerializeField] float paddingLeft;
    [SerializeField] float paddingRight;
    [SerializeField] float paddingTop;
    [SerializeField] float paddingBottom;

    [SerializeField] AudioClip workAudio;
    [SerializeField] AudioClip lifeAudio;


    [SerializeField] ParticleSystem wallEffect;
    
    public bool isWork = true;
    CameraShake cameraShake;
          
    GameObject wall;

    Animator myAnimator;
    Rigidbody2D myRigidbody;

    Vector2 maxBounds;
    Vector2 minBounds;
  
   

    void Awake()
    {
        
        myRigidbody = GetComponent<Rigidbody2D>(); 
        wall = GameObject.FindWithTag("WALL");
        myAnimator = GetComponent<Animator>();
        cameraShake = Camera.main.GetComponent<CameraShake>();
        
      
    }

    void Start()
    {
        InitBounds();

    }

    void FixedUpdate() 
    {
       RotatePlayer(); 
    }

   
    void Update()
    {
        Move();
    }

    void InitBounds()
    {
        Camera mainCamera = Camera.main;
        minBounds = mainCamera.ViewportToWorldPoint( new Vector2(0,0));
        maxBounds = mainCamera.ViewportToWorldPoint( new Vector2(1,1));
    }

     void Move()
    {
        Vector2 delta = rawInput * moveSpeed * Time.deltaTime;
        Vector2 newPos = new Vector2();
        newPos.x = Mathf.Clamp(transform.position.x + delta.x, minBounds.x + paddingLeft , maxBounds.x - paddingRight );
        newPos.y = Mathf.Clamp(transform.position.y + delta.y, minBounds.y + paddingBottom, maxBounds.y - paddingTop );
        transform.position = newPos;
    }

    void OnMove(InputValue value)
    {
        rawInput = value.Get<Vector2>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
       if(other.tag == "WALL_Life" )
       {
           isWork = false;
           ShakeCamera();
           Debug.Log("isLife now!");
           myAnimator.SetBool("IsWork", false);
          
           //AudioSource.PlayClipAtPoint(lifeAudio, Camera.main.transform.position);

                     
       } 
       else
       {
        if(other.tag == "WALL_Work" )
        {
            isWork = true;
            ShakeCamera();
            Debug.Log("is WORKING HARD now!");
            myAnimator.SetBool("IsWork", true);
          
            //AudioSource.PlayClipAtPoint(workAudio, Camera.main.transform.position);

        }
        else
        {return;}
       }
       
    }

    void RotatePlayer()
    {
        myRigidbody.rotation += 2f;
    }

    public bool GetIsWorking()
       {
         if(isWork == true)
         {return true;}
         else
         {return false;}
       }


       void ShakeCamera()
       {
             if(cameraShake != null)
             {
                cameraShake.Play();
             }
       }
}
