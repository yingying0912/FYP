using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public enum PlayerStatus { normal, super, dead };

    [SerializeField] int maxHP;
    int currentHp;
    public PlayerStatus currentState;

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
                attackValue = 0;
                damageValue = 0;
                break;
        }

        
    }

    public void Attack()
    {
        Debug.Log("Attack Animation");
    }

    public int getAttackValue()
    {
        return attackValue;
    }

    void checkTime()
    {
        if (currentTime >= superDuration)
            currentState = PlayerStatus.normal;
        else
            currentTime += Time.deltaTime;
    }
}
