using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public enum PlayerStatus { normal, super, dead };

    static public int maxHP = 10;
    static public int currentHp;
    static public PlayerStatus currentState;

    int attackValue;
    int damageValue;

    float superDuration = 10f;
    float currentTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        currentHp = maxHP;
        currentState = PlayerStatus.normal;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentState == PlayerStatus.normal || currentState == PlayerStatus.super)
            checkStatus();

        switch (currentState)
        {
            case PlayerStatus.normal:
                attackValue = 1;
                damageValue = 2;
                break;
            case PlayerStatus.super:
                attackValue = 2;
                damageValue = 1;
                checkTime();
                break;
            case PlayerStatus.dead:
                GameManager.gameState = GameManager.GameStatus.lose;
                break;
        }
    }

    public void Attack()
    {
        Debug.Log("Attack Animation");
        Debug.Log("AttackDamage: " + attackValue);
        Debug.Log("Player Status: " + currentState);
    }

    public int getAttackValue()
    {
        return attackValue;
    }

    void checkTime()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= superDuration)
        {
            currentState = PlayerStatus.normal;
            currentTime = 0;
        }  
    }

    public void receivedDamage(int damage)
    {
        currentHp -= damage * damageValue;
    }

    void checkStatus()
    {
        if (currentHp <= 0)
            currentState = PlayerStatus.dead;
    }
}
