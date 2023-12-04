using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretTrophy : MonoBehaviour
{
    private Canvas canvas;
    private int MainCount;

    private void Start()
    {
        MainCount = 0;
        canvas = GetComponent<Canvas>();
        canvas.enabled = false;
    }

    public void SecretUnlock()
    {
        if (CountKill(0) == 0)
        {
            canvas.enabled = true;
        }
    }   
    public int CountKill(int count)
    {
        return MainCount += count;       
    }
}
