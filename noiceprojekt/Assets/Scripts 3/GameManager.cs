using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Threading;
using TMPro;
public class GameManager : MonoBehaviour
{
    [Header("Game Variables")]
    public PlayerController player;
    public float time;
    public bool timeActive;


    [Header("GameUI")]
    public TMP_Text gameUI_score;
    public TMP_Text gameUI_health;
    public TMP_Text gameUI_time;


    [Header("Countdown UI")]
    public TMP_Text countdownText;
    public int countdown;

    [Header("EndScreens UI")]

    [Header("Screens")]
    public GameObject countdownUI;
    public GameObject gameUI;
    public GameObject endUI;
    // Start is called before the first frame update
    void Start()
    {
        timeActive = false;
        player = GameObject.Find("Dr.Pill").GetComponent<PlayerController>();

        time = 0;

        player.enabled = false;

        StartCoroutine(CountDownRoutine());

    }

    IEnumerator CountDownRoutine()
    {
        countdownText.gameObject.SetActive(true);
        countdown = 3;
        while (countdown > 0)
        {
            countdownText.text = countdown.ToString();
            yield return new WaitForSeconds(1f);
            countdown--;
        }
        countdownText.text = "GO!";
        yield return new WaitForSeconds(1f);

        player.enabled = true;

        startGame();
    }

    void startGame()
    {
        SetScreen(gameUI);
        timeActive = true;
    }
   
   public void endGame()
    {
        timeActive = false;

        player.enabled = false;

        //SetScreen(countdownUI);

    }

  
    // Update is called once per frame
    void Update()
    {
        time = time + Time.deltaTime;


        gameUI_score.text = "OwO's:" + player.coincount;
        gameUI_health.text = "Health: " + player.health;
        gameUI_time.text = "Time: " + (time * 10).ToString("F2");
     } 
        
    public void SetScreen(GameObject screen)
    {
        Debug.Log("Test");
        gameUI.SetActive(false);
        countdownUI.SetActive(false);

        screen.SetActive(true);
    }
}