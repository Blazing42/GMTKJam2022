using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ExitMenuUIcontroller : MonoBehaviour
{
    TimerandKillSave timerandKillSave;
    public TextMeshProUGUI timer;
    public TextMeshProUGUI kills;

    // Start is called before the first frame update
    void Start()
    {
        timerandKillSave = GameObject.Find("TimerandKillSave").GetComponent<TimerandKillSave>();
        timer.text = "You Survived: " + timerandKillSave.timer;
        kills.text = "You Killed " + timerandKillSave.kills.ToString() + " enemys";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
