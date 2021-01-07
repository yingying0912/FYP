using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] int enemyHP;
    int enemyCurrentHP;

    // Start is called before the first frame update
    void Start()
    {
        enemyCurrentHP = enemyHP;
    }

    public void receivedAttack(int damageReceived)
    {
        Debug.Log("Receive damage animation");
        enemyCurrentHP -= damageReceived;
        Debug.Log("Enemy current HP:" + enemyCurrentHP);
    }
}
