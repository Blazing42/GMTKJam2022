using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceNumber : MonoBehaviour
{
    PlayerAttacks Dice;
    [SerializeField] int side = 0;
    void Start()
    {
        Dice = GetComponentInParent<PlayerAttacks>();
    }

    void Update()
    {
        if (transform.position.y > 0.45)
        {
            Dice.DiceNumber = side;
        }
    }
}
