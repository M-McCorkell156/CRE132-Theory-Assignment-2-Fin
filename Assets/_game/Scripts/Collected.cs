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

    public GameObject countCoin; 

    private void OnTriggerEnter2D(Collider2D collision)
    {       
        if (collision.gameObject.tag == "Player")
        {   
            countCoin.GetComponent<WinScreenManager>().CountCoin(1);
            // Play the one-shot sound effect at the specified position
            AudioSource.PlayClipAtPoint(soundEffect, this.transform.position, volume);

            Destroy(gameObject, 0.1f);

            // Instantiate the animated prefab
            GameObject instance = Instantiate(animatedPrefab, transform.position, Quaternion.identity);

            // Destroy the instance after the animation has completed
            Destroy(instance, animationLength);
        }
    }




}
