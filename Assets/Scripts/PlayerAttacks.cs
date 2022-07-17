using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacks : MonoBehaviour
{
    public int DiceNumber;
    [SerializeField] EnemySpawner enemySpawner;
    public float explosionRange;

    private PlayerMovement Player;
    private void Start()
    {
        enemySpawner = GameObject.Find("EnemySpawner").GetComponent<EnemySpawner>();
        Player = GetComponent<PlayerMovement>();
    }
    void Update()
    {
        if (Input.GetAxisRaw("Fire1") == 1)
        {
            Attack();
            Debug.Log("attack");
        }
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
            foreach(GameObject enemy in enemySpawner.enemyObj)
            {
                if(Vector3.Distance(this.transform.position, enemy.transform.position) <= explosionRange)
                {
                    enemy.GetComponent<EnemyMovement>().GetHit();
                }
            }
            return;
        }
    }
}
