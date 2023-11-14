using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    private float currentTime;
    [SerializeField] private bool smash,invincible;
    public enum BallState
    {
        Prepare,
        Playing,
        Died,
        Finish
    }
    [HideInInspector] public BallState ballState=BallState.Prepare;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if(ballState==BallState.Playing)
        {
            if (Input.GetMouseButtonDown(0))
            {
                smash = true;
            }
            if (Input.GetMouseButtonUp(0))
            {
                smash = false;
            }
            if (invincible)
            {
                currentTime -= Time.deltaTime * 0.35f;
            }
            else
            {
                if (smash)
                {
                    currentTime += Time.deltaTime * 0.8f;
                }
                else
                {
                    currentTime -= Time.deltaTime * 0.5f;
                }
            }
            if (currentTime >= 1)
            {
                currentTime = 1;
                invincible = true;
            }
            else
            {
                currentTime = 0;
                invincible = false;
            }
        }
        if(ballState==BallState.Prepare)
        {
            if(Input.GetMouseButtonDown(0))
            {
                ballState = BallState.Playing;
            }
        }
        if(ballState==BallState.Finish)
        {
            if(Input.GetMouseButtonDown(0))
            {
                FindObjectOfType<LevelSpawner>().NextLevel();
            }    
        }
        

    }
    private void FixedUpdate()
    {
        
        if (ballState==BallState.Playing)
        {
            if (Input.GetMouseButtonDown(0))
            {
                smash = true;
                rb.velocity = new Vector3(0f, -100 * Time.deltaTime * 7, 0f);
            }    
                
        }
        if(rb.velocity.y>5f)
        {
            rb.velocity = new Vector3(rb.velocity.x, 5f, rb.velocity.z);
        }    
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (!smash)
        {
            rb.velocity=new Vector3(0f,50* Time.deltaTime*5, 0f);
        }
        else
        {
            if(invincible)
            {
                if (collision.gameObject.CompareTag("enemy") == true || collision.gameObject.CompareTag("plane") == true)
                {
                    collision.transform.parent.GetComponent<StackController>().ShatterAllParts();
                }    
            }
            else
            {
                if (collision.gameObject.CompareTag("enemy") == true)
                {
                    collision.transform.parent.GetComponent<StackController>().ShatterAllParts();
                }
                if (collision.gameObject.CompareTag("plane") == true)
                {
                    Debug.Log("Game Over");
                    //Destroy(gameObject);
                }
            }
           
        }   
        if(collision.gameObject.CompareTag("Finish") && ballState==BallState.Playing)
        {
            ballState = BallState.Finish;
        }    

    }
    private void OnCollisionStay(Collision collision)
    {
        if (!smash || collision.gameObject.CompareTag("Finish")==true)
        {

            rb.velocity = new Vector3(0f, 50 * Time.deltaTime * 5, 0f);
        }
    }
}
