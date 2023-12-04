using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public Canvas canvas;

    [Header("Component")]
    public TextMeshProUGUI timerTxt;

    [Header("Timer Setting")]
    public float currentTime;
    public float record;
    public bool setRecord;

    private void Start()
    {
        setRecord = false;
        canvas.enabled = true;
    }
    void Update()
    {
        if (setRecord == false)
        {
            currentTime += Time.deltaTime;
            SetTimer();
        }
    }
    public void RecordTime()
    { 
        setRecord = true;
    }
    private void SetTimer()
    {       
        timerTxt.text = currentTime.ToString("0.00");
    }
}
