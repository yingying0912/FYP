using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public enum EnemyStatus { idle, attack, dead};

    static public int enemyHP = 2;
    static public int enemyCurrentHP;

    public static EnemyStatus enemyStatus;

    [SerializeField] float attackSpeed;
    float currentTime = 0;
    int attackNum;
    int attackDamage;

    Animator animator;

    [SerializeField] PlayerBehaviour player;

    // Start is called before the first frame update
    void Start()
    {
        enemyCurrentHP = enemyHP;
        enemyStatus = EnemyStatus.idle;
        animator = GetComponent<Animator>();
        attackNum = 0;
        attackDamage = 0;
    }

    void Update()
    {
        if (enemyStatus == EnemyStatus.idle || enemyStatus == EnemyStatus.attack)
            checkStatus();
        switch (enemyStatus)
        {
            case EnemyStatus.idle:
                break;
            case EnemyStatus.attack:
                attackPlayer();
                break;
            case EnemyStatus.dead:
                animator.Play("Die");
                GameManager.gameState = GameManager.GameStatus.win;
                break;
        }
    }

    public void receivedAttack(int damageReceived)
    {
        Debug.Log("Receive damage animation");
        enemyCurrentHP -= damageReceived;
        Debug.Log("Enemy current HP:" + enemyCurrentHP);
        animator.Play("GetHit");
    }

    void checkStatus()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= attackSpeed)
        {
            enemyStatus = EnemyStatus.attack;
            currentTime = 0;
        }
        else
            enemyStatus = EnemyStatus.idle;
            
        if (enemyCurrentHP <= 0)
            enemyStatus = EnemyStatus.dead;
    }

    void attackPlayer()
    {
        attackNum += 1;
        if (attackNum == 1 || attackNum == 2)
        {
            attackDamage = 1;
            animator.Play("Attack01");
        }
        else if (attackNum == 3)
        {
            attackDamage = 2;
            animator.Play("Attack02ST");
        }
        else if (attackNum == 4)
        {
            attackDamage = 3;
            animator.Play("Attack03");
            attackNum = 0;
        }
        player.receivedDamage(attackDamage);
    }
}
