using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerandKillSave : MonoBehaviour
{
    public string timer;
    public int kills;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
    }
}
