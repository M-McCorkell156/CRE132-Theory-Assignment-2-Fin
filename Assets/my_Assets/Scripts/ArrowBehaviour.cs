using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class ArrowBehaviour : MonoBehaviour

{
    private Animator animator;

    Rigidbody2D rb;
    Quaternion targetRotation;


    public float rotatespeed;

    private AudioSource source;

    private GameObject secret;


    public void Awake()
    {
        animator = GetComponent<Animator>();
        secret = GameObject.Find("SecretTrophy");
        rb = GetComponent<Rigidbody2D>();
        source = GetComponent<AudioSource>();
    }
    private void FixedUpdate()
    {   
        //source = AudioSource.find
         Vector3 gravity = GameObject.Find("Ground Position").transform.position;

         //Vector2 gravityDirection; //Use the direction you calculated
         targetRotation = Quaternion.LookRotation(new Vector3(0, 0, rb.transform.position.z), gravity);
        if (targetRotation != null) 
         transform.rotation = Quaternion.Slerp(rb.transform.rotation, targetRotation, rotatespeed * Time.fixedDeltaTime);
         //Debug.Log(rb.transform.rotation);       
        
    }

    
    private void OnTriggerEnter2D(Collider2D collider)
    {   
        if (collider.gameObject.tag == "Ground" || collider.gameObject.tag == "Platform")
        {
            rb.velocity = Vector3.zero;
            animator.SetBool("isBreak", true);
            source.Play();           
        }
        if(collider.gameObject.tag == "BadGuy")
        {
            Destroy(collider.gameObject);
            secret.GetComponent<SecretTrophy>().CountKill(1);
        }       
    }

    private void BreakArrow()
    {
        Destroy(this.gameObject);
    }
}
