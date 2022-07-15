using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinDice : MonoBehaviour
{
    public float spinSpeed = 2f;
    void Update()
    {
        transform.Rotate(new Vector3(0, 1, 0), Time.deltaTime * spinSpeed);
    }
}
