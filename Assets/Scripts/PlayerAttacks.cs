using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacks : MonoBehaviour
{
    public int DiceNumber;
    [SerializeField] EnemySpawner enemySpawner;
    public float explosionRange;
    public GameObject bulletPrefab;
    public GameObject minePrefab;
    public float attackCooldown = 1f;
    bool cantAttack;

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
            if(cantAttack == false)
            {
                Attack();
                Debug.Log("attack");
                cantAttack = true;
            }
            
        }
    }

    void Attack()
    {
        if (DiceNumber == 1) 
        { 
            Invoke(nameof(ResetAttackTimer), attackCooldown);
            return; 
        }
        
        if (DiceNumber == 2)
        {
            Instantiate(minePrefab, transform.position, Quaternion.identity);
            Invoke(nameof(ResetAttackTimer), attackCooldown);
            return;
        }
        if (DiceNumber == 3)
        {
            Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            Invoke(nameof(ResetAttackTimer), attackCooldown);
            return;
        }
        if (DiceNumber == 4)
        {
            Player.damaged = true;
            Invoke(nameof(ResetInvulnerability), 2f);
            Invoke(nameof(ResetAttackTimer), attackCooldown);
            return;
        }
        if (DiceNumber == 5)
        {
            if (Player.livesRemaining != Player.maxHealth)
            {
                Player.livesRemaining += 1;
            }
            Invoke(nameof(ResetAttackTimer), attackCooldown);
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
            Invoke(nameof(ResetAttackTimer), attackCooldown);
            return;
        }
    }
    void ResetAttackTimer()
    {
        cantAttack = false;
    }

   void ResetInvulnerability()
    {
        Player.InvincibleForABitAfterTakingLife();
    }
}
