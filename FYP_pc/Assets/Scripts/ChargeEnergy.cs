using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeEnergy : MonoBehaviour
{
    static public int maxCharge = 2;
    static public int currentCharge;

    int attackNum;

    PlayerBehaviour player;
    [SerializeField] EnemyBehaviour enemy;

    // Start is called before the first frame update
    void Start()
    {
        currentCharge = 0;
        attackNum = 1;
        player = this.GetComponent<PlayerBehaviour>();
    }

    void Update()
    {
        if (currentCharge == maxCharge)
        {
            Debug.Log("Launch attack");
            player.Attack();
            currentCharge = 0;

            if (PlayerBehaviour.currentState == PlayerBehaviour.PlayerStatus.normal)
                attackNum++;
            
            Debug.Log("Enemy received attack");
            enemy.receivedAttack(player.getAttackValue());
        }
        
        if (attackNum % 5 == 0 && PlayerBehaviour.currentState == PlayerBehaviour.PlayerStatus.normal)
            PlayerBehaviour.currentState = PlayerBehaviour.PlayerStatus.super;
    }

    public void Charging()
    {
        if (currentCharge < maxCharge)
            currentCharge += 1;
        Debug.Log(currentCharge);
    }

}
