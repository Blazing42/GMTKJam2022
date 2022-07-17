using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class UIController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timer;
    [SerializeField] TextMeshProUGUI lives;
    [SerializeField] TextMeshProUGUI enemiesKilled;
    [SerializeField] TextMeshProUGUI attacktype;

    private float startTime;
    int killCount = 0;
    int livesLeft = 4;
    EnemySpawner enemySpawner;

    public static UIController UIControllerInstance { get; private set; }

    private void Awake()
    {
        // If there is an instance
        if (UIControllerInstance != null && UIControllerInstance != this)
        {
            Destroy(this);
        }
        else
        {
            UIControllerInstance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        enemySpawner = GameObject.Find("EnemySpawner").GetComponent<EnemySpawner>();
        timer.text = "00:00";
        enemiesKilled.text = "Kills : " + killCount;
        lives.text = "Lives : " + livesLeft;
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        float t = Time.time - startTime;
        int minutesInt = ((int)t / 60);
        string minutes = minutesInt.ToString();
        int secondsInt = (int)(t % 60);
        string seconds = secondsInt.ToString();
        timer.text = minutes + " : " + seconds;

        if(secondsInt == 0 && minutesInt > 0)
        {
            enemySpawner.TickUpDifficulty();
        }
    }

    public void LoseLife()
    {
        livesLeft--;
        lives.text = "Lives : " + livesLeft;
        if(livesLeft <= 0)
        {
            //change to lose screen etc
        }
    }

    public void TickUpKillcount()
    {
        killCount++;
        enemiesKilled.text = "Kills : " + killCount;
    }

}
