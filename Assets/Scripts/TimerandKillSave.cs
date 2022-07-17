using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerandKillSave : MonoBehaviour
{
    public string timer;
    public int kills;
    public static TimerandKillSave SaveInstance { get; private set; }

    private void Awake()
    {
        // If there is an instance
        if (SaveInstance != null && SaveInstance != this)
        {
            Destroy(this);
        }
        else
        {
            SaveInstance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
    }
}
