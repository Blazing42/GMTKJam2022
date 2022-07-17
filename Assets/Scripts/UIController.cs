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
    bool timeGoing;
    EnemySpawner enemySpawner;
    

    // Start is called before the first frame update
    void Start()
    {
        enemySpawner = GameObject.Find("EnemySpawner").GetComponent<EnemySpawner>();
        timer.text = "00:00";
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


}
