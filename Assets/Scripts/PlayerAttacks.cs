using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacks : MonoBehaviour
{
    public int DiceNumber;

    private PlayerMovement Player;

    void Update()
    {
        if (Input.GetAxisRaw("Fire1") == 1)
        {
            Attack();
        }
        Player = GetComponent<PlayerMovement>();
    }

    void Attack()
    {
        if (DiceNumber == 1) return;
        if (DiceNumber == 2)
        {
            return;
        }
        if (DiceNumber == 3)
        {
            return;
        }
        if (DiceNumber == 4)
        {
            return;
        }
        if (DiceNumber == 5)
        {
            if (Player.livesRemaining != Player.maxHealth)
            {
                Player.livesRemaining += 1;
            }
            return;
        }
        if (DiceNumber == 6)
        {
            return;
        }
    }
}
