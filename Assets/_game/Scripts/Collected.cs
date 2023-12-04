using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class Collected : MonoBehaviour
{
    public GameObject animatedPrefab;  // Assign your animated prefab here in the Unity Editor
    public float animationLength;  // The length of the animation in seconds

    public AudioClip soundEffect;  // The sound effect to be played, set in the Unity Editor
    public float volume = 1.0f;    // Volume level, ranging from 0.0 to 1.0

    public int counter;

    private int killCount;
    private GameObject secret; 

    private GameObject canvas;
    private GameObject timer;

    void Start()
    {
        timer = GameObject.Find("TimerManager");
        canvas = GameObject.Find("YouWinScreen");
        secret = GameObject.Find("SecretTrophy");
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision");

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {   
            counter = 11;
            counter ++;
            //Debug.Log(counter);
            //PlayerAttributes.AddHealth(10.0f);

            // Play the one-shot sound effect at the specified position
            AudioSource.PlayClipAtPoint(soundEffect, this.transform.position, volume);

            Destroy(gameObject, 0.1f);
            // instatiate a sprite animation effect prefab
            // Instantiate the animated prefab
            GameObject instance = Instantiate(animatedPrefab, transform.position, Quaternion.identity);

            // Destroy the instance after the animation has completed
            Destroy(instance, animationLength);
            if (counter >= 12) 
            {
                secret.GetComponent<SecretTrophy>().SecretUnlock();
                timer.GetComponent<Timer>().RecordTime();
                canvas.GetComponent<WinScreenManager>().GameWin();
            }
        }
    }




}
