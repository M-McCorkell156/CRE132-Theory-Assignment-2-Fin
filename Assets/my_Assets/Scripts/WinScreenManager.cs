using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class WinScreenManager : MonoBehaviour
{
    private Canvas canvas;
    public GameObject player;
    public GameObject badGuy;

    private GameObject secret;

    private GameObject winCanvas;
    private GameObject timer;
    private int coinCount;

    public AudioSource background;
    public AudioSource source;

    private void Start()
    {
        coinCount = 0;

        timer = GameObject.Find("TimerManager");
        winCanvas = GameObject.Find("YouWinScreen");
        secret = GameObject.Find("SecretTrophy");

        UnityEngine.UI.Button restart = GameObject.Find("RePlayButton").GetComponent<Button>();
        canvas = GetComponent<Canvas>();
        canvas.enabled = false;

        restart.onClick.AddListener(Reset);
    }
    public void GameWin()
    {
        background.Pause();
        source.Play();
        Destroy(player);
        Destroy(badGuy);
        canvas.enabled = true;
    }

    private void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void CountCoin (int count)
    {
        //coinCount = 11;
        coinCount += count;
        Debug.Log(count);
        if (coinCount >= 12)
        {
            secret.GetComponent<SecretTrophy>().SecretUnlock();
            timer.GetComponent<Timer>().RecordTime();
            canvas.GetComponent<WinScreenManager>().GameWin();
        }
    }
}
