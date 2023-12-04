using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ChangeColour : MonoBehaviour
{

    [SerializeField] SpriteRenderer SpR;
    [SerializeField] int delay;
    void Start()
    {
        InvokeRepeating("Wait", 1, delay);       
    }

    void Wait()
    {
        SpR.color = new Color(Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0, 1f));
    }

    void Update()
    {
        
    }


}
