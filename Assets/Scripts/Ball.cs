using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private bool smash;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            smash = true;
        }
        if(Input.GetMouseButtonUp(0))
        {
            smash=false;
        }
    }
    private void FixedUpdate()
    {
        if(Input.GetMouseButtonDown(0))
        {
            smash = true;
            rb.velocity = new Vector3(0f,100 * Time.deltaTime * 7, 0f);
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
            if(collision.gameObject.CompareTag("Enemy")==true)
            {
                Destroy(collision.transform.parent.gameObject);
            }
            if (collision.gameObject.CompareTag("plane") == true)
            {
                Debug.Log("Over");
            }
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
