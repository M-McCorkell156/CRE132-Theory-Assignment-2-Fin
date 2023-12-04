using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinScreenManager : MonoBehaviour
{
    private Canvas canvas;
    public GameObject player;
    public GameObject badGuy;

    public AudioSource background;
    public AudioSource source;

    private void Start()
    {
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
}
