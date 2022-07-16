using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacks : MonoBehaviour
{
    public int DiceNumber;

    void Update()
    {
        if (Input.GetAxisRaw("Fire1") == 1)
        {
            Attack();
        }
    }

    void Attack()
    {
        if (DiceNumber == 1) return;
        if (DiceNumber == 2)
        {

        }
    }
}
