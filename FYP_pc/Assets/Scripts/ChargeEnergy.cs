using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeEnergy : MonoBehaviour
{
    [SerializeField] int maxCharge;
    int currentCharge;

    int attackNum;

    PlayerBehaviour player;
    [SerializeField] EnemyBehaviour enemy;

    // Start is called before the first frame update
    void Start()
    {
        currentCharge = 0;
        attackNum = 0;
        player = this.GetComponent<PlayerBehaviour>();
    }

    void Update()
    {
        if (currentCharge == maxCharge)
        {
            Debug.Log("Launch attack");
            player.Attack();
            currentCharge = 0;

            if (player.currentState == PlayerBehaviour.PlayerStatus.normal)
                attackNum++;
            
            Debug.Log("Enemy received attack");
            enemy.receivedAttack(player.getAttackValue());
        }
        
        if (attackNum % 5 == 0 && player.currentState == PlayerBehaviour.PlayerStatus.normal)
            player.currentState = PlayerBehaviour.PlayerStatus.super;
    }

    public void Charging()
    {
        if (currentCharge < maxCharge)
            currentCharge += 1;
        Debug.Log(currentCharge);
    }

}
