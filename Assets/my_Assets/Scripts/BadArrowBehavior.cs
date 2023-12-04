using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;

public class BadArrowBehavior : MonoBehaviour
{
    Rigidbody2D rb;
    Quaternion targetRotation;

    private GameObject canvas;
    private GameObject timer;

    public float rotatespeed;

    private AudioSource source;
    //public AudioClip breakClip;
    public void Awake()
    {
        //AudioListener.pause = false;
        rb = GetComponent<Rigidbody2D>();

        canvas = GameObject.Find("GameOverScreen");
        timer = GameObject.Find("TimerManager");
    }
    private void FixedUpdate()
    {

        Vector3 gravity = GameObject.Find("Ground Position").transform.position;

        //Vector2 gravityDirection; //Use the direction you calculated
        targetRotation = Quaternion.LookRotation(new Vector3(0, 0, rb.transform.position.z), gravity);
        transform.rotation = Quaternion.Slerp(rb.transform.rotation, targetRotation, rotatespeed * Time.fixedDeltaTime);
        //Debug.Log(rb.transform.rotation);       

    }


    private void OnTriggerEnter2D(Collider2D collider)
    {
        source = GetComponent<AudioSource>();
        if (collider.gameObject.tag == "Ground" || collider.gameObject.tag == "Platform")
        {
            source.Play();
            Destroy(this.gameObject,0.06f);
            
        }
        if (collider.gameObject.tag == "Player")
        {
            Destroy(collider.gameObject);

            canvas.GetComponent<ScreenManager>().GameOver();
            timer.GetComponent<Timer>().RecordTime();  
        }
    }
}
